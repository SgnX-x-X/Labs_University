using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs2
{
    public partial class Delete : Form
    {
        MainMenu main;
        public Delete(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            List.list.Print(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List.list.DeleteFirst();
                List.list.Print(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List.list.DeleteLast();
                List.list.Print(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Number.Text, out int number) || number <= 0)
                {
                    MessageBox.Show("Введите число",
                        "Ошибка",
                        MessageBoxButtons.OK);
                }
                else
                {
                    List.list.DeleteAt(number);
                    List.list.Print(dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
        }
        private void Delete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main != null) main.Show();
        }
    }
}
