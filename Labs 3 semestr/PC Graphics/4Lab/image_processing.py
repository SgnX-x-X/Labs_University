import numpy as np
from PIL import Image, ImageDraw


def rgb_to_grayscale(img_rgb: np.ndarray) -> np.ndarray:
    """Перевод RGB в полутоновое изображение (Rec. 601)."""
    if img_rgb.ndim == 2:
        return img_rgb.astype(np.uint8)
    r = img_rgb[:, :, 0].astype(np.float32)
    g = img_rgb[:, :, 1].astype(np.float32)
    b = img_rgb[:, :, 2].astype(np.float32)
    gray = 0.299 * r + 0.587 * g + 0.114 * b
    return np.clip(np.round(gray), 0, 255).astype(np.uint8)


def threshold_binarization(gray: np.ndarray, threshold: int = 128) -> np.ndarray:
    """Пороговая бинаризация."""
    return np.where(gray >= threshold, 255, 0).astype(np.uint8)


def sawtooth_contrast_scaling(gray: np.ndarray, num_peaks: int = 3) -> np.ndarray:
    """Пилообразное контрастное масштабирование."""
    num_peaks = max(1, int(num_peaks))
    gray_f = gray.astype(np.float32)
    period = 256.0 / num_peaks
    val_in_period = np.fmod(gray_f, period)
    scaled = (val_in_period / (period - 1.0 if period > 1.0 else 1.0)) * 255.0
    return np.clip(np.round(scaled), 0, 255).astype(np.uint8)


def linear_mask_filter_replicate_border(
    gray: np.ndarray,
    kernel: np.ndarray,
    A: float = 0.0,
    B: float = 1.0,
    take_abs: bool = True
) -> np.ndarray:
    """Линейная масочная фильтрация с дублированием крайних рядов."""
    H, W = gray.shape
    kh, kw = kernel.shape
    pad_h, pad_w = kh // 2, kw // 2
    padded = np.pad(gray.astype(np.float32), ((pad_h, pad_h), (pad_w, pad_w)), mode='edge')
    out = np.zeros((H, W), dtype=np.float32)
    k_rot = np.flip(np.flip(kernel, 0), 1)

    for i in range(kh):
        for j in range(kw):
            w = k_rot[i, j]
            if w != 0:
                out += w * padded[i:i + H, j:j + W]

    out = A + B * out
    if take_abs:
        out = np.abs(out)
    return np.clip(np.round(out), 0, 255).astype(np.uint8)


def create_structuring_element(shape: str = 'square', size: int = 3) -> np.ndarray:
    """Создание структурирующего элемента (ядра)."""
    size = max(3, int(size))
    if size % 2 == 0:
        size += 1
    r = size // 2
    if shape.lower() == 'square':
        return np.ones((size, size), dtype=np.uint8)
    elif shape.lower() == 'cross':
        kernel = np.zeros((size, size), dtype=np.uint8)
        kernel[r, :] = 1
        kernel[:, r] = 1
        return kernel
    elif shape.lower() == 'disk':
        y, x = np.ogrid[-r:r+1, -r:r+1]
        return ((x * x + y * y) <= (r * r + 0.5)).astype(np.uint8)
    return np.ones((size, size), dtype=np.uint8)


def morphological_erosion(
    binary: np.ndarray,
    kernel: np.ndarray,
    anchor: tuple[int, int] | None = None
) -> np.ndarray:
    """Морфологическое сужение (эрозия)."""
    H, W = binary.shape
    kh, kw = kernel.shape
    if anchor is None:
        ax, ay = kw // 2, kh // 2
    else:
        ax = max(0, min(kw - 1, anchor[0]))
        ay = max(0, min(kh - 1, anchor[1]))

    padded = np.pad(binary, ((ay, kh - 1 - ay), (ax, kw - 1 - ax)), mode='constant', constant_values=0)
    ky, kx = np.where(kernel == 1)
    out = np.full((H, W), 255, dtype=np.uint8)
    for dy, dx in zip(ky, kx):
        out = np.minimum(out, padded[dy:dy + H, dx:dx + W])
    return out


def hough_line_vectorization(
    edge_img: np.ndarray,
    orig_rgb: np.ndarray | None = None,
    vote_threshold: int | None = None,
    threshold_ratio: float = 0.35,
    min_line_len: int = 20,
    max_line_gap: int = 8,
    theta_step_deg: float = 1.0,
    max_lines: int = 40
) -> tuple[np.ndarray, list[dict], np.ndarray]:
    """Векторизация растровых контуров методом Хафа."""
    H, W = edge_img.shape
    ys, xs = np.where(edge_img > 0)
    if len(xs) == 0:
        empty_acc = np.zeros((100, 180), dtype=np.uint8)
        base = orig_rgb.copy() if orig_rgb is not None else np.stack([edge_img] * 3, axis=-1)
        return empty_acc, [], base

    thetas_deg = np.arange(0, 180, theta_step_deg)
    thetas_rad = np.deg2rad(thetas_deg)
    diag_len = int(np.ceil(np.hypot(H, W)))
    num_rhos = 2 * diag_len + 1
    num_thetas = len(thetas_deg)

    cos_t = np.cos(thetas_rad)
    sin_t = np.sin(thetas_rad)

    accumulator = np.zeros((num_rhos, num_thetas), dtype=np.int32)
    for x, y in zip(xs, ys):
        rhos = np.round(x * cos_t + y * sin_t).astype(int) + diag_len
        valid = (rhos >= 0) & (rhos < num_rhos)
        for t_idx, r_idx in enumerate(rhos):
            if valid[t_idx]:
                accumulator[r_idx, t_idx] += 1

    max_votes = int(accumulator.max())
    if vote_threshold is None:
        vote_threshold = max(10, int(max_votes * threshold_ratio))

    acc_vis = np.log1p(accumulator.astype(np.float32))
    acc_max = acc_vis.max()
    acc_vis = (acc_vis / acc_max * 255.0).astype(np.uint8) if acc_max > 0 else acc_vis.astype(np.uint8)

    peaks_r, peaks_t = np.where(accumulator >= vote_threshold)
    peak_points = []
    win = 4
    for r_idx, t_idx in zip(peaks_r, peaks_t):
        val = accumulator[r_idx, t_idx]
        r_min, r_max = max(0, r_idx - win), min(num_rhos, r_idx + win + 1)
        t_min, t_max = max(0, t_idx - win), min(num_thetas, t_idx + win + 1)
        if val == accumulator[r_min:r_max, t_min:t_max].max():
            peak_points.append((val, r_idx - diag_len, thetas_deg[t_idx], thetas_rad[t_idx]))

    peak_points.sort(key=lambda p: p[0], reverse=True)
    if max_lines is not None and max_lines > 0:
        peak_points = peak_points[:max_lines]

    palette = [
        (255, 60, 60), (60, 220, 60), (60, 140, 255), (255, 200, 40),
        (230, 80, 240), (40, 230, 230), (255, 120, 40), (180, 255, 60)
    ]

    segments = []
    overlay = orig_rgb.copy() if orig_rgb is not None else np.stack([edge_img] * 3, axis=-1)
    line_idx = 0

    for votes, rho, t_deg, t_rad in peak_points:
        c, s = np.cos(t_rad), np.sin(t_rad)
        dist = np.abs(xs * c + ys * s - rho)
        on_line = dist <= 1.8
        if not np.any(on_line):
            continue

        pts_x = xs[on_line]
        pts_y = ys[on_line]
        proj = -pts_x * s + pts_y * c
        sort_order = np.argsort(proj)
        pts_x, pts_y, proj = pts_x[sort_order], pts_y[sort_order], proj[sort_order]

        seg_start = 0
        for i in range(1, len(proj)):
            if proj[i] - proj[i - 1] > max_line_gap:
                p1 = (int(pts_x[seg_start]), int(pts_y[seg_start]))
                p2 = (int(pts_x[i - 1]), int(pts_y[i - 1]))
                length = float(np.hypot(p2[0] - p1[0], p2[1] - p1[1]))
                if length >= min_line_len:
                    segments.append({
                        "id": len(segments) + 1,
                        "x1": p1[0], "y1": p1[1],
                        "x2": p2[0], "y2": p2[1],
                        "length": round(length, 1),
                        "theta_deg": round(t_deg, 1),
                        "rho": round(rho, 1),
                        "color": palette[line_idx % len(palette)]
                    })
                    line_idx += 1
                seg_start = i

        p1 = (int(pts_x[seg_start]), int(pts_y[seg_start]))
        p2 = (int(pts_x[-1]), int(pts_y[-1]))
        length = float(np.hypot(p2[0] - p1[0], p2[1] - p1[1]))
        if length >= min_line_len:
            segments.append({
                "id": len(segments) + 1,
                "x1": p1[0], "y1": p1[1],
                "x2": p2[0], "y2": p2[1],
                "length": round(length, 1),
                "theta_deg": round(t_deg, 1),
                "rho": round(rho, 1),
                "color": palette[line_idx % len(palette)]
            })
            line_idx += 1

    pil_overlay = Image.fromarray(overlay)
    draw = ImageDraw.Draw(pil_overlay)
    for seg in segments:
        draw.line([(seg["x1"], seg["y1"]), (seg["x2"], seg["y2"])], fill=seg["color"], width=3)
        r_node = 3
        draw.ellipse([seg["x1"] - r_node, seg["y1"] - r_node, seg["x1"] + r_node, seg["y1"] + r_node], fill=(255, 255, 255), outline=seg["color"], width=2)
        draw.ellipse([seg["x2"] - r_node, seg["y2"] - r_node, seg["x2"] + r_node, seg["y2"] + r_node], fill=(255, 255, 255), outline=seg["color"], width=2)

    return acc_vis, segments, np.array(pil_overlay)
