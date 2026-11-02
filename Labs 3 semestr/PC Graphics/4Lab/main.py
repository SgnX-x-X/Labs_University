import os
import sys
import tkinter as tk
from tkinter import ttk, filedialog, messagebox
import numpy as np
from PIL import Image, ImageTk

import image_processing as ip


class ImageProcessingLabApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Алгоритмы обработки изображений")
        self.geometry("1440x860")
        self.minsize(1200, 750)
        self.configure(bg="#f0f2f5")

        self.orig_rgb = None
        self.gray_img = None
        self.bin_img = None
        self.task2_img = None
        self.task3_img = None
        self.task4_img = None
        self.hough_vec_img = None
        self.photo_refs = {}

        self.threshold_var = tk.IntVar(value=128)
        self.sawtooth_peaks_var = tk.IntVar(value=3)
        self.kernel_shape_var = tk.StringVar(value="square")
        self.kernel_size_var = tk.IntVar(value=3)
        self.anchor_x_var = tk.IntVar(value=1)
        self.anchor_y_var = tk.IntVar(value=1)
        self.hough_ratio_var = tk.DoubleVar(value=0.30)

        self._setup_styles()
        self._build_ui()

        sample_dir = os.path.join(os.path.dirname(__file__), "sample_images")
        if os.path.exists(sample_dir):
            candidates = [
                "default.jpg", "default.png", "default.jpeg",
                "photo_2026-11-02_11-14-30.jpg", "shapes.png"
            ]
            for candidate in candidates:
                p = os.path.join(sample_dir, candidate)
                if os.path.exists(p):
                    self.load_image_from_path(p)
                    break
            else:
                files = [os.path.join(sample_dir, f) for f in os.listdir(sample_dir) if f.lower().endswith(('.png', '.jpg', '.jpeg', '.bmp'))]
                if files:
                    self.load_image_from_path(files[0])

    def _setup_styles(self):
        style = ttk.Style(self)
        try:
            style.theme_use('clam')
        except Exception:
            pass

        style.configure(".", background="#f0f2f5", font=("Segoe UI", 9))
        style.configure("Header.TFrame", background="#1a237e")
        style.configure("Header.TLabel", background="#1a237e", foreground="#ffffff", font=("Segoe UI", 12, "bold"))

        style.configure("Control.TLabelframe", background="#ffffff", relief="groove")
        style.configure("Control.TLabelframe.Label", background="#ffffff", foreground="#1a237e", font=("Segoe UI", 9, "bold"))

        style.configure("Card.TFrame", background="#ffffff", relief="ridge", borderwidth=1)
        style.configure("CardTitle.TLabel", background="#e8eaf6", foreground="#1a237e", font=("Segoe UI", 9, "bold"), padding=4)
        style.configure("CardSub.TLabel", background="#ffffff", foreground="#5c6bc0", font=("Segoe UI", 8))

        style.configure("Accent.TButton", font=("Segoe UI", 9, "bold"), background="#3949ab", foreground="#ffffff")
        style.map("Accent.TButton", background=[("active", "#1e88e5")])

    def _build_ui(self):
        header_frame = ttk.Frame(self, style="Header.TFrame", padding=(15, 8))
        header_frame.pack(side=tk.TOP, fill=tk.X)

        title_lbl = ttk.Label(header_frame, text="Алгоритмы обработки изображений", style="Header.TLabel")
        title_lbl.pack(side=tk.LEFT)

        btn_open = ttk.Button(header_frame, text="Загрузить фото...", command=self.browse_image)
        btn_open.pack(side=tk.RIGHT, padx=4)

        control_panel = ttk.Frame(self, padding=(10, 6), style="Control.TLabelframe")
        control_panel.pack(side=tk.TOP, fill=tk.X, padx=10, pady=5)

        # 1. Порог бинаризации
        f_t1 = ttk.LabelFrame(control_panel, text="Порог бинаризации", style="Control.TLabelframe", padding=6)
        f_t1.pack(side=tk.LEFT, padx=4, fill=tk.Y)

        self.thresh_lbl = ttk.Label(f_t1, text=f"Порог T: {self.threshold_var.get()}")
        self.thresh_lbl.pack(anchor="w")
        thresh_scale = ttk.Scale(
            f_t1, from_=0, to=255, orient=tk.HORIZONTAL,
            variable=self.threshold_var, length=120,
            command=lambda v: self._on_thresh_change()
        )
        thresh_scale.pack(pady=2)

        # 2. Пилообразное масштабирование
        f_t2 = ttk.LabelFrame(control_panel, text="Пилообразное масштабирование", style="Control.TLabelframe", padding=6)
        f_t2.pack(side=tk.LEFT, padx=4, fill=tk.Y)

        self.peaks_lbl = ttk.Label(f_t2, text=f"Пиков пилы K: {self.sawtooth_peaks_var.get()}")
        self.peaks_lbl.pack(anchor="w")
        peaks_scale = ttk.Scale(
            f_t2, from_=1, to=8, orient=tk.HORIZONTAL,
            variable=self.sawtooth_peaks_var, length=140,
            command=lambda v: self._on_peaks_change()
        )
        peaks_scale.pack(pady=2)

        # 3. Фильтр границ
        f_t3 = ttk.LabelFrame(control_panel, text="Фильтр границ (Лапласиан)", style="Control.TLabelframe", padding=6)
        f_t3.pack(side=tk.LEFT, padx=4, fill=tk.Y)

        ttk.Label(f_t3, text="Матрица Лапласа 3х3 (A=0, B=1)").pack(anchor="w")
        ttk.Label(f_t3, text="Обработка краев: копирование рядов", foreground="#3949ab", font=("Segoe UI", 8)).pack(anchor="w", pady=(2, 0))

        # 4. Сужение / Эрозия
        f_t4 = ttk.LabelFrame(control_panel, text="Сужение / Эрозия", style="Control.TLabelframe", padding=6)
        f_t4.pack(side=tk.LEFT, padx=4, fill=tk.Y)

        f_t4_row1 = ttk.Frame(f_t4)
        f_t4_row1.pack(fill=tk.X)
        ttk.Label(f_t4_row1, text="Форма:").pack(side=tk.LEFT, padx=2)
        shape_combo = ttk.Combobox(
            f_t4_row1, textvariable=self.kernel_shape_var, state="readonly", width=8,
            values=["square", "cross", "disk"]
        )
        shape_combo.pack(side=tk.LEFT, padx=2)
        shape_combo.bind("<<ComboboxSelected>>", lambda e: self.update_all_images())

        ttk.Label(f_t4_row1, text="Размер:").pack(side=tk.LEFT, padx=(4, 2))
        size_combo = ttk.Combobox(
            f_t4_row1, textvariable=self.kernel_size_var, state="readonly", width=3,
            values=[3, 5, 7]
        )
        size_combo.pack(side=tk.LEFT, padx=2)
        size_combo.bind("<<ComboboxSelected>>", lambda e: self._on_kernel_size_change())

        f_t4_row2 = ttk.Frame(f_t4)
        f_t4_row2.pack(fill=tk.X, pady=2)
        self.anchor_lbl = ttk.Label(f_t4_row2, text=f"Якорь ({self.anchor_x_var.get()},{self.anchor_y_var.get()}):")
        self.anchor_lbl.pack(side=tk.LEFT, padx=(2, 4))
        ttk.Label(f_t4_row2, text="X:").pack(side=tk.LEFT)
        self.ax_spin = ttk.Spinbox(f_t4_row2, from_=0, to=2, width=3, textvariable=self.anchor_x_var, command=self.update_all_images)
        self.ax_spin.pack(side=tk.LEFT, padx=1)
        ttk.Label(f_t4_row2, text="Y:").pack(side=tk.LEFT)
        self.ay_spin = ttk.Spinbox(f_t4_row2, from_=0, to=2, width=3, textvariable=self.anchor_y_var, command=self.update_all_images)
        self.ay_spin.pack(side=tk.LEFT, padx=1)

        # 5. Преобразование Хафа (Векторизация)
        f_t5 = ttk.LabelFrame(control_panel, text="Преобразование Хафа (Векторизация)", style="Control.TLabelframe", padding=6)
        f_t5.pack(side=tk.LEFT, padx=4, fill=tk.Y)

        self.hough_lbl = ttk.Label(f_t5, text=f"Порог: {int(self.hough_ratio_var.get()*100)}%")
        self.hough_lbl.pack(anchor="w")
        hough_scale = ttk.Scale(
            f_t5, from_=0.10, to=0.70, orient=tk.HORIZONTAL,
            variable=self.hough_ratio_var, length=150,
            command=lambda v: self._on_hough_change()
        )
        hough_scale.pack(pady=2)

        # Сетка отображения изображений
        self.grid_container = ttk.Frame(self, padding=8)
        self.grid_container.pack(side=tk.TOP, fill=tk.BOTH, expand=True)

        for c in range(4):
            self.grid_container.columnconfigure(c, weight=1, uniform="col")
        for r in range(2):
            self.grid_container.rowconfigure(r, weight=1, uniform="row")

        self.image_cards = {}
        cards_def = [
            ("img1", "Исходное изображение (RGB)", 0, 0),
            ("img2", "Оттенки серого (Rec. 601)", 0, 1),
            ("img3", "Пороговая бинаризация", 0, 2),
            ("img4", "Пилообразное масштабирование", 0, 3),
            ("img5", "Фильтр определения границ", 1, 0),
            ("img6", "Сужение (эрозия)", 1, 1),
            ("img7", "Векторизация (Преобразование Хафа)", 1, 2),
        ]

        for key, title, row, col in cards_def:
            card = ttk.Frame(self.grid_container, style="Card.TFrame")
            card.grid(row=row, column=col, padx=4, pady=4, sticky="nsew")

            title_lbl = ttk.Label(card, text=title, style="CardTitle.TLabel", anchor="center")
            title_lbl.pack(side=tk.TOP, fill=tk.X)

            sub_lbl = ttk.Label(card, text="", style="CardSub.TLabel", anchor="center")
            sub_lbl.pack(side=tk.TOP, fill=tk.X, pady=(0, 2))

            canvas = tk.Canvas(card, bg="#1e1e24", highlightthickness=0)
            canvas.pack(side=tk.TOP, fill=tk.BOTH, expand=True)

            self.image_cards[key] = {
                "frame": card,
                "title_lbl": title_lbl,
                "sub_lbl": sub_lbl,
                "canvas": canvas,
                "img_data": None
            }

        self.bind("<Configure>", self._on_window_resize)

    def _on_thresh_change(self):
        t = self.threshold_var.get()
        self.thresh_lbl.config(text=f"Порог T: {t}")
        self.update_binarization_and_morphology()

    def _on_peaks_change(self):
        k = self.sawtooth_peaks_var.get()
        self.peaks_lbl.config(text=f"Пиков пилы K: {k}")
        self.update_task2_image()

    def _on_kernel_size_change(self):
        sz = self.kernel_size_var.get()
        max_idx = sz - 1
        self.ax_spin.config(to=max_idx)
        self.ay_spin.config(to=max_idx)
        self.anchor_x_var.set(sz // 2)
        self.anchor_y_var.set(sz // 2)
        self.anchor_lbl.config(text=f"Якорь ({sz//2},{sz//2}):")
        self.update_task4_image()

    def _on_hough_change(self):
        self.update_hough_image()

    def _on_window_resize(self, event):
        if event.widget == self:
            self.after_idle(self.render_all_canvases)

    def browse_image(self):
        path = filedialog.askopenfilename(
            title="Выберите изображение",
            filetypes=[("Изображения", "*.png;*.jpg;*.jpeg;*.bmp;*.webp"), ("Все файлы", "*.*")]
        )
        if path:
            self.load_image_from_path(path)

    def load_image_from_path(self, path: str):
        try:
            pil_img = Image.open(path).convert("RGB")
            pil_img.thumbnail((600, 600), Image.Resampling.LANCZOS)
            self.orig_rgb = np.array(pil_img)
            self.gray_img = ip.rgb_to_grayscale(self.orig_rgb)
            self.update_all_images()
        except Exception as e:
            messagebox.showerror("Ошибка", f"Не удалось загрузить изображение: {e}")

    def update_all_images(self):
        if self.orig_rgb is None:
            return

        self.image_cards["img1"]["img_data"] = self.orig_rgb
        self.image_cards["img1"]["sub_lbl"].config(
            text=f"Размер: {self.orig_rgb.shape[1]}x{self.orig_rgb.shape[0]} px"
        )

        self.image_cards["img2"]["img_data"] = self.gray_img
        self.image_cards["img2"]["sub_lbl"].config(
            text="Y = 0.299*R + 0.587*G + 0.114*B"
        )

        self.update_binarization_and_morphology()
        self.update_task2_image()
        self.update_task3_image()
        self.update_hough_image()

    def update_binarization_and_morphology(self):
        if self.gray_img is None:
            return
        t = self.threshold_var.get()
        self.bin_img = ip.threshold_binarization(self.gray_img, t)
        self.image_cards["img3"]["img_data"] = self.bin_img
        self.image_cards["img3"]["sub_lbl"].config(text=f"Порог бинаризации T = {t}")
        self.update_task4_image()

    def update_task2_image(self):
        if self.gray_img is None:
            return
        k = self.sawtooth_peaks_var.get()
        self.task2_img = ip.sawtooth_contrast_scaling(self.gray_img, k)
        self.image_cards["img4"]["title_lbl"].config(text="Пилообразное масштабирование")
        self.image_cards["img4"]["sub_lbl"].config(text=f"Количество пиков пилы K = {k}")
        self.image_cards["img4"]["img_data"] = self.task2_img
        self.render_card("img4")

    def update_task3_image(self):
        if self.gray_img is None:
            return
        lap_k = np.array([[0, -1, 0], [-1, 4, -1], [0, -1, 0]], dtype=np.float32)
        self.task3_img = ip.linear_mask_filter_replicate_border(self.gray_img, lap_k, A=0.0, B=1.0)
        self.image_cards["img5"]["title_lbl"].config(text="Фильтр определения границ")
        self.image_cards["img5"]["sub_lbl"].config(text="Матрица Лапласа 3х3 (A=0, B=1), копирование рядов")
        self.image_cards["img5"]["img_data"] = self.task3_img
        self.render_card("img5")

    def update_task4_image(self):
        if self.bin_img is None:
            return

        shape = self.kernel_shape_var.get()
        size = self.kernel_size_var.get()
        ax = self.anchor_x_var.get()
        ay = self.anchor_y_var.get()

        kernel = ip.create_structuring_element(shape, size)
        self.task4_img = ip.morphological_erosion(self.bin_img, kernel, (ax, ay))

        shape_ru = {"square": "квадрат", "cross": "крест", "disk": "диск"}.get(shape, shape)
        self.image_cards["img6"]["title_lbl"].config(text="Сужение (эрозия)")
        self.image_cards["img6"]["sub_lbl"].config(text=f"Ядро: {shape_ru} {size}х{size}, якорь ({ax}, {ay})")
        self.image_cards["img6"]["img_data"] = self.task4_img
        self.render_card("img6")

    def update_hough_image(self):
        if self.task3_img is None and self.gray_img is None:
            return

        if self.task3_img is not None:
            edge_img = (self.task3_img > 40).astype(np.uint8) * 255
        else:
            edge_img = ip.threshold_binarization(self.gray_img, self.threshold_var.get())

        ratio = self.hough_ratio_var.get()
        _, segments, overlay = ip.hough_line_vectorization(
            edge_img, orig_rgb=self.orig_rgb, threshold_ratio=ratio, min_line_len=20, max_lines=40
        )
        self.hough_vec_img = overlay

        self.hough_lbl.config(text=f"Порог: {int(ratio*100)}% | Линий: {len(segments)}")

        self.image_cards["img7"]["img_data"] = overlay
        self.image_cards["img7"]["sub_lbl"].config(text=f"Найдено векторных отрезков: {len(segments)}")

        self.render_card("img7")

    def render_card(self, key: str):
        card_info = self.image_cards.get(key)
        if not card_info or card_info["img_data"] is None:
            return

        canvas = card_info["canvas"]
        cw, ch = canvas.winfo_width(), canvas.winfo_height()
        if cw < 20 or ch < 20:
            return

        arr = card_info["img_data"]
        pil_img = Image.fromarray(arr, mode="L" if arr.ndim == 2 else "RGB")
        iw, ih = pil_img.size
        scale = min(cw / iw, ch / ih)
        nw, nh = max(1, int(iw * scale)), max(1, int(ih * scale))

        resample = Image.Resampling.NEAREST if arr.ndim == 2 and np.array_equal(np.unique(arr), [0, 255]) else Image.Resampling.BILINEAR
        resized = pil_img.resize((nw, nh), resample)
        photo = ImageTk.PhotoImage(resized)
        self.photo_refs[key] = photo

        canvas.delete("all")
        canvas.create_image((cw - nw) // 2, (ch - nh) // 2, anchor="nw", image=photo)

    def render_all_canvases(self):
        for key in self.image_cards:
            self.render_card(key)


if __name__ == "__main__":
    app = ImageProcessingLabApp()
    app.mainloop()
