namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm(this);
            createForm.Show();
            Hide();
        }
        private void Task_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm(this);
            taskForm.Show();
            Hide();
        }
        private void AboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Выполнил: Гильфанов Александр Александрович \nГруппа: 6101-090301D \nВариант 10: Создать два дерева поиска. Скопировать в линейный список информационные поля элементов с совпадающими в первом и втором деревьях значениями ключей.", "О программе", MessageBoxButtons.OK);
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Destroy_Click(object sender, EventArgs e)
        {
            Data.tree1.Destroy();
            Data.tree2.Destroy();
            MessageBox.Show("Оба дерева были разрушены", "Разрушение", MessageBoxButtons.OK);
        }
    }
}

