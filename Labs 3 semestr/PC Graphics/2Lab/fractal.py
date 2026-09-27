# import numpy as np
# import matplotlib.pyplot as plt

# def generate_fractal(x_min=-2.2, x_max=1.0, y_min=-1.2, y_max=1.2, width=1200, height=900, max_iter=100):
#     x = np.linspace(x_min, x_max, width)
#     y = np.linspace(y_min, y_max, height)
#     z0 = x[np.newaxis, :] + 1j * y[:, np.newaxis]
    
#     z = z0.copy()
#     fractal = np.zeros(z.shape, dtype=int)
#     mask = np.ones(z.shape, dtype=bool)

#     for i in range(max_iter):
#         z[mask] = z[mask]**4 + z0[mask]
#         escaped = np.abs(z) > 2.0
#         newly_escaped = escaped & mask
#         fractal[newly_escaped] = i
#         mask = mask & (~escaped)
#         if not np.any(mask):
#             break

#     fractal[mask] = max_iter
#     return fractal

# fractal_data = generate_fractal()

# plt.figure(figsize=(10, 7.5))
# plt.imshow(fractal_data, extent=[-2.2, 1.0, -1.2, 1.2], cmap="inferno", origin="lower")
# plt.colorbar(label="Итерации")
# plt.xlabel("Re(Z)")
# plt.ylabel("Im(Z)")
# plt.title(r"Фрактал $Z_{k+1} = Z_k^4 + Z_0$")
# plt.show()
import tkinter as tk


class FractalApp:

    def __init__(self, root):
        self.root = root
        self.root.title("Алгебраический фрактал Z^4 + Z0 (Вариант 2)")

        self.width = 600
        self.height = 500

        self.x_min, self.x_max = -2.2, 1.0
        self.y_min, self.y_max = -1.2, 1.2

        self.max_iter = 50

        self.canvas = tk.Canvas(root, width=self.width, height=self.height, bg="black")
        self.canvas.pack()


        self.img = tk.PhotoImage(width=self.width, height=self.height)
        self.canvas.create_image((self.width // 2, self.height // 2), image=self.img)


        self.root.bind("<KeyPress>", self.handle_keys)

        self.draw_fractal()

    def draw_fractal(self):
        """Попиксельный расчет и отрисовка фрактала."""
        pixel_data = []

        colors = [
            "#050510",
            "#101530",
            "#152550",
            "#1a3570",
            "#1f4590",
            "#2455b0",
            "#2a65d0",
            "#4080e0",
            "#60a0ed",
            "#85c0f5",
            "#aadafa",
            "#d5f0fc",
            "#f0f9fe",
            "#e0f5da",
            "#bdf0a8",
            "#70e040",
        ]

        for py in range(self.height):
            row_colors = []
            # Переводим координату экрана Y в комплексное число
            y0 = self.y_max - (py / self.height) * (self.y_max - self.y_min)

            for px in range(self.width):
                # Переводим координату экрана X в комплексное число
                x0 = self.x_min + (px / self.width) * (self.x_max - self.x_min)

                cr, ci = x0, y0
                zr, zi = x0, y0

                iteration = 0
                while (zr * zr + zi * zi) <= 4.0 and iteration < self.max_iter:
                    # Z^2 = (zr^2 - zi^2) + i*(2*zr*zi)
                    r2 = zr * zr - zi * zi
                    i2 = 2.0 * zr * zi

                    # Z^4 = (Z^2)^2 = (r2^2 - i2^2) + i*(2*r2*i2)
                    temp_r = r2 * r2 - i2 * i2 + cr
                    zi = 2.0 * r2 * i2 + ci
                    zr = temp_r

                    iteration += 1

                if iteration == self.max_iter:
                    color = "#404040" 
                else:
                    color = colors[iteration % len(colors)]

                row_colors.append(color)

            pixel_data.append("{" + " ".join(row_colors) + "}")

        self.img.put(" ".join(pixel_data))

    def handle_keys(self, event):
        """Обработка нажатий для масштабирования и перемещения."""
        x_range = self.x_max - self.x_min
        y_range = self.y_max - self.y_min


        if event.char == "+" or event.char == "=":

            self.x_min += x_range * 0.1
            self.x_max -= x_range * 0.1
            self.y_min += y_range * 0.1
            self.y_max -= y_range * 0.1
        elif event.char == "-":

            self.x_min -= x_range * 0.1
            self.x_max += x_range * 0.1
            self.y_min -= y_range * 0.1
            self.y_max += y_range * 0.1

        elif event.keysym == "Left":
            self.x_min -= x_range * 0.1
            self.x_max -= x_range * 0.1
        elif event.keysym == "Right":
            self.x_min += x_range * 0.1
            self.x_max += x_range * 0.1
        elif event.keysym == "Up":
            self.y_min += y_range * 0.1
            self.y_max += y_range * 0.1
        elif event.keysym == "Down":
            self.y_min -= y_range * 0.1
            self.y_max -= y_range * 0.1
        else:
            return

        self.draw_fractal()


if __name__ == "__main__":
    root = tk.Tk()
    app = FractalApp(root)
    root.mainloop()
