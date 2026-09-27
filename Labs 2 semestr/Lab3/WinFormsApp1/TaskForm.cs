using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TaskForm : Form
    {
        private MainForm main;
        public TaskForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            Data.tree1.Task(Data.tree1.Root, Data.tree2, Data.list);
            Data.list.Print(dataGridView1);
        }
        private void TaskPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float availableWidth = this.ClientSize.Width - dataGridView1.Width - 20f;

            float startX1 = availableWidth / 4f;
            float dX1 = availableWidth / 8f;

            float startX2 = availableWidth * 3f / 4f;
            float dX2 = availableWidth / 8f;

            float dY = 50f;
            float startY = 60f;

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            using (SolidBrush brushTree = new SolidBrush(Color.Black))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                if (Data.tree1 != null && Data.tree1.Root != null)
                {
                    Data.tree1.Show(Data.tree1.Root, startX1, startY, dX1, dY, g, font, brushTree, format);
                }

                if (Data.tree2 != null && Data.tree2.Root != null)
                {
                    Data.tree2.Show(Data.tree2.Root, startX2, startY, dX2, dY, g, font, brushTree, format);
                }
            }
        }
        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main != null) main.Show();
        }
    }
}
