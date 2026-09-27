using Labs2;
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
    public partial class Insert : Form
    {
        MainMenu main;
        public Insert(MainMenu main)
        {
            InitializeComponent();
            this.main=main;
            List.list.Print(dataGridView1);
        }
        private void firstButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Value.Text, out int value))
            {
                MessageBox.Show("Введите число",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
            else
            {
                List.list.InsertBeforeFirst(value);
                List.list.Print(dataGridView1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Value.Text, out int value))
                {
                    MessageBox.Show("Введите число",
                        "Ошибка",
                        MessageBoxButtons.OK);
                }
                else
                {
                    List.list.InsertAfterLast(value);
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
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Value.Text, out int value) || !int.TryParse(Number.Text, out int number) || number <= 0)
                {
                    MessageBox.Show("Введите число",
                        "Ошибка",
                        MessageBoxButtons.OK);
                }
                else
                {
                    List.list.InsertAt(value, number);
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
        private void Insert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main != null) main.Show();
        }
    }
}