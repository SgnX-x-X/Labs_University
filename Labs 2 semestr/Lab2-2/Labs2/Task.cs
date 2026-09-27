using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labs2
{
    public partial class Task : Form
    {
        MainMenu main;
        public Task(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            List.list.Print(dataGridView1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Quantity.Text, out int quantity) || !int.TryParse(Position.Text, out int position))
                {
                    MessageBox.Show("Введите число",
                        "Ошибка",
                        MessageBoxButtons.OK);
                }
                else if (quantity >0 && position > 0)
                {
                    List.list.Task(quantity, position);
                    List.list.Print(dataGridView1);
                }
                else MessageBox.Show($"Введите целое положительное число",
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

        private void Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main != null) main.Show();
        }
    }
}
