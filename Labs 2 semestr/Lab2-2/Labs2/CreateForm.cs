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
    public partial class CreateForm : Form
    {
        MainMenu main;
        public CreateForm(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            int[] numbers = inputValue.Text.Split(new[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                     .Where(n => int.TryParse(n, out _))
                     .Select(int.Parse)
                     .ToArray();
            List.list.Create(numbers);
            List.list.Print(dataGridView1);
        }

        private void CreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(main != null) main.Show(); 
        }
    }
}
