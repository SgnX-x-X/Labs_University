import math
import tkinter as tk
from PIL import Image, ImageTk

# Настройка High-DPI для четкого отображения на Windows
try:
    import ctypes
    ctypes.windll.shcore.SetProcessDpiAwareness(1)
except Exception:
    try:
        import ctypes
        ctypes.windll.user32.SetProcessDPIAware()
    except Exception:
        pass

def set_pixel(img, x, y, color):
    """Установка цвета пикселя с проверкой границ холста."""
    if 0 <= x < img.width and 0 <= y < img.height:
        img.putpixel((int(x), int(y)), color)


def bresenham_line(img, x0, y0, x1, y1, color, watertight=True):
    """
    Целочисленный алгоритм Брезенхема для отрезка прямой.
    """
    x0, y0, x1, y1 = int(round(x0)), int(round(y0)), int(round(x1)), int(round(y1))
    dx = abs(x1 - x0)
    dy = abs(y1 - y0)
    sx = 1 if x0 < x1 else -1
    sy = 1 if y0 < y1 else -1
    err = dx - dy

    while True:
        set_pixel(img, x0, y0, color)
        if x0 == x1 and y0 == y1:
            break
        e2 = 2 * err
        if watertight and e2 > -dy and e2 < dx:
            set_pixel(img, x0 + sx, y0, color)
        if e2 > -dy:
            err -= dy
            x0 += sx
        if e2 < dx:
            err += dx
            y0 += sy


def bresenham_circle(img, xc, yc, r, color, watertight=True):
    """
    Алгоритм Брезенхема для окружности 
    """
    xc, yc, r = int(round(xc)), int(round(yc)), int(round(r))
    x = 0
    y = r
    d = 3 - 2 * r

    def plot_8(cx, cy, px, py):
        pts = [
            (cx + px, cy + py), (cx - px, cy + py),
            (cx + px, cy - py), (cx - px, cy - py),
            (cx + py, cy + px), (cx - py, cy + px),
            (cx + py, cy - px), (cx - py, cy - px)
        ]
        for ppx, ppy in pts:
            set_pixel(img, ppx, ppy, color)
            if watertight:
                if ppx > cx:
                    set_pixel(img, ppx - 1, ppy, color)
                elif ppx < cx:
                    set_pixel(img, ppx + 1, ppy, color)

    while y >= x:
        plot_8(xc, yc, x, y)
        if d <= 0:
            d += 4 * x + 6
        else:
            d += 4 * (x - y) + 10
            y -= 1
        x += 1


def bresenham_ellipse(img, xc, yc, rx, ry, color, watertight=True):
    """
    Алгоритм средней точки Брезенхема для эллипса
    """
    xc, yc, rx, ry = int(round(xc)), int(round(yc)), int(round(rx)), int(round(ry))
    if rx <= 0 or ry <= 0:
        return

    rx2 = rx * rx
    ry2 = ry * ry

    def plot_4(cx, cy, px, py):
        for ppx, ppy in [(cx + px, cy + py), (cx - px, cy + py), (cx + px, cy - py), (cx - px, cy - py)]:
            set_pixel(img, ppx, ppy, color)
            if watertight:
                if ppx > cx:
                    set_pixel(img, ppx - 1, ppy, color)
                elif ppx < cx:
                    set_pixel(img, ppx + 1, ppy, color)

    # Область 1 (|dy/dx| < 1)
    x = 0
    y = ry
    d1 = 4 * ry2 - 4 * rx2 * ry + rx2
    dx = 2 * ry2 * x
    dy = 2 * rx2 * y

    while dx < dy:
        plot_4(xc, yc, x, y)
        x += 1
        dx += 2 * ry2
        if d1 < 0:
            d1 += 4 * dx + 4 * ry2
        else:
            y -= 1
            dy -= 2 * rx2
            d1 += 4 * (dx - dy) + 4 * ry2

    # Область 2 (|dy/dx| >= 1)
    d2 = 4 * ry2 * (x + 1) * (x + 1) + 4 * rx2 * (y - 1) * (y - 1) - 4 * rx2 * ry2
    while y >= 0:
        plot_4(xc, yc, x, y)
        y -= 1
        dy -= 2 * rx2
        if d2 > 0:
            d2 += 4 * rx2 - 4 * dy
        else:
            x += 1
            dx += 2 * ry2
            d2 += 4 * (dx - dy) + 4 * rx2


def bezier_cubic(img, p0, p1, p2, p3, color, steps=60):
    """
    Кубическая кривая Безье
    """
    prev = p0
    for i in range(1, steps + 1):
        t = i / steps
        it = 1.0 - t
        x = (it ** 3) * p0[0] + 3 * t * (it ** 2) * p1[0] + 3 * (t ** 2) * it * p2[0] + (t ** 3) * p3[0]
        y = (it ** 3) * p0[1] + 3 * t * (it ** 2) * p1[1] + 3 * (t ** 2) * it * p2[1] + (t ** 3) * p3[1]
        curr = (x, y)
        bresenham_line(img, prev[0], prev[1], curr[0], curr[1], color, watertight=True)
        prev = curr

def flood_fill_solid(img, start_x, start_y, fill_color):
    """
    Модифицированный алгоритм с «затравкой»
    """
    w, h = img.width, img.height
    x, y = int(start_x), int(start_y)
    if not (0 <= x < w and 0 <= y < h):
        return

    pix = img.load()
    target = pix[x, y]
    if target == fill_color:
        return

    stack = [(x, y)]
    while stack:
        cx, cy = stack.pop()
        if pix[cx, cy] != target:
            continue

        x_left = cx
        while x_left >= 0 and pix[x_left, cy] == target:
            x_left -= 1
        x_left += 1

        x_right = cx
        while x_right < w and pix[x_right, cy] == target:
            x_right += 1
        x_right -= 1

        for i in range(x_left, x_right + 1):
            pix[i, cy] = fill_color
        for ny in (cy + 1, cy - 1):
            if 0 <= ny < h:
                nx = x_left
                while nx <= x_right:
                    if pix[nx, ny] == target:
                        while nx <= x_right and pix[nx, ny] == target:
                            nx += 1
                        stack.append((nx - 1, ny))
                    nx += 1


def create_watermelon_pattern(width=60, height=60, dark_color=(16, 68, 28), light_color=(76, 175, 58)):
    """
    Создание массива-узора pattern[Width][Height] (Лекция 4, разд. 2.2.3, стр. 4).
    Пиксельная карта элемента мозаики с волнистыми полосами арбуза.
    """
    pattern = [[None for _ in range(height)] for _ in range(width)]
    for x in range(width):
        for y in range(height):
            # Волнообразный изгиб полос для текстуры арбуза
            wave = int(7.0 * math.sin(2.0 * math.pi * y / height))
            if ((x + wave) % width) < (width // 2):
                pattern[x][y] = dark_color
            else:
                pattern[x][y] = light_color
    return pattern


def flood_fill_pattern(img, start_x, start_y, pattern):
    """
    Закраска с узором.
    """
    w, h = img.width, img.height
    x, y = int(start_x), int(start_y)
    if not (0 <= x < w and 0 <= y < h):
        return

    pat_w = len(pattern)
    pat_h = len(pattern[0])

    pix = img.load()
    target = pix[x, y]
    visited = bytearray(w * h)
    stack = [(x, y)]

    while stack:
        cx, cy = stack.pop()
        idx = cy * w + cx
        if visited[idx] or pix[cx, cy] != target:
            continue

        x_left = cx
        while x_left >= 0 and not visited[cy * w + x_left] and pix[x_left, cy] == target:
            x_left -= 1
        x_left += 1

        x_right = cx
        while x_right < w and not visited[cy * w + x_right] and pix[x_right, cy] == target:
            x_right += 1
        x_right -= 1

        for i in range(x_left, x_right + 1):
            visited[cy * w + i] = 1
            pix[i, cy] = pattern[i % pat_w][cy % pat_h]

        for ny in (cy + 1, cy - 1):
            if 0 <= ny < h:
                nx = x_left
                row_off = ny * w
                while nx <= x_right:
                    if not visited[row_off + nx] and pix[nx, ny] == target:
                        while nx <= x_right and not visited[row_off + nx] and pix[nx, ny] == target:
                            nx += 1
                        stack.append((nx - 1, ny))
                    nx += 1

def draw_watermelon(img):
    """
    Отрисовка рисунка арбуза
    """
    w, h = img.width, img.height
    XC, YC = w // 2, 320
    R = 200
    stem_y = YC - R

    DARK_GREEN = (16, 68, 28)
    LIGHT_GREEN = (76, 175, 58)
    BROWN = (95, 65, 35)
    bresenham_circle(img, XC, YC, R, DARK_GREEN, watertight=True)
    wm_pattern = create_watermelon_pattern(width=50, height=50, dark_color=DARK_GREEN, light_color=LIGHT_GREEN)
    flood_fill_pattern(img, XC, YC, wm_pattern)
    bezier_cubic(img, (XC - 4, stem_y), (XC - 9, stem_y - 18), (XC - 5, stem_y - 34), (XC + 9, stem_y - 46), BROWN)
    bezier_cubic(img, (XC + 4, stem_y), (XC - 1, stem_y - 18), (XC + 3, stem_y - 34), (XC + 17, stem_y - 44), BROWN)
    bresenham_line(img, XC + 9, stem_y - 46, XC + 17, stem_y - 44, BROWN, watertight=True)
    flood_fill_solid(img, XC, stem_y - 15, BROWN)

def main():
    root = tk.Tk()
    root.title("Лабораторная работа №3")
    root.resizable(False, False)

    width, height = 900, 600

    img = Image.new("RGB", (width, height), (252, 252, 255))

    draw_watermelon(img)

    img.save("watermelon_final.png")

    tk_img = ImageTk.PhotoImage(img)
    canvas = tk.Canvas(root, width=width, height=height, bg="#fcfcff", highlightthickness=0)
    canvas.pack()
    canvas.create_image(0, 0, anchor=tk.NW, image=tk_img)

    canvas.image = tk_img

    root.mainloop()


if __name__ == "__main__":
    main()