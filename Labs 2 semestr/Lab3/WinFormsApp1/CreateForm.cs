using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class CreateForm : Form
    {
        MainForm main;
        public CreateForm(MainForm main)
        {
            InitializeComponent();
            this.main=main;
        }
        public void PaintTree(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float width = this.ClientSize.Width;

            float startX1 = width / 4f;
            float dX1 = width / 8f;

            float startX2 = width * 3f / 4f;
            float dX2 = width / 8f;

            float dY = 50f;
            float startY = 60f;

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                if (Data.tree1 != null && Data.tree1.Root != null)
                {
                    Data.tree1.Show(Data.tree1.Root, startX1, startY, dX1, dY, g, font, brush, format);
                }
                if (Data.tree2 != null && Data.tree2.Root != null)
                {
                    Data.tree2.Show(Data.tree2.Root, startX2, startY, dX2, dY, g, font, brush, format);
                }
            }
        }
        private void CreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main != null) main.Show();
        }

        private void CreateTree1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] keys = Key.Text.Split(new[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                     .Where(n => int.TryParse(n, out _))
                     .Select(int.Parse)
                     .ToArray();
                char[] infos = Info.Text
                            .Split(new char[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s[0])
                            .ToArray();
                if (infos.Length == keys.Length)
                {
                    Data.tree1.Create(keys, infos);
                    this.Invalidate();
                }
                else MessageBox.Show($"Количество ключей и информационных полей должны быть равны",
                        "Ошибка",
                        MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                                    "Ошибка",
                                    MessageBoxButtons.OK);
            }
        }

        private void CreateTree2_Click(object sender, EventArgs e)
        {
            try
            {
                int[] keys = Key.Text.Split(new[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Where(n => int.TryParse(n, out _))
                                     .Select(int.Parse)
                                     .ToArray();
                char[] infos = Info.Text
                            .Split(new char[] { ',', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s[0])
                            .ToArray();
                if (infos.Length == keys.Length)
                {
                    Data.tree2.Create(keys, infos);
                    this.Invalidate();
                }
                else MessageBox.Show($"Количество ключей и информационных полей должны быть равны",
                        "Ошибка",
                        MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                                    "Ошибка",
                                    MessageBoxButtons.OK);
            }

        }
    }
}
