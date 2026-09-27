namespace FirstLaba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            panelAbout.Visible = true;
            panel1.Visible = false;
        }

        private void MenuTask_Click(object sender, EventArgs e)
        {
            panelAbout.Visible = false;
            panel1.Visible = true;
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textX.Text, out double x))
            {
                MessageBox.Show("Пожалуйста, введите корректное число для Х.");
            }
            if (!int.TryParse(textN.Text, out int n) || n < 0)
            {
                MessageBox.Show("N должно быть целым положительным числом");
            }
            double result = Recursive.Calculate(x, n);
            labelResult.Text = $"Результат вычеслений: {result}";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите закрыть приложение?",
                "Подтверждение закрытия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
