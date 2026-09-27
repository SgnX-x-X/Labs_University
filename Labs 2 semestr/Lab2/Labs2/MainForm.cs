namespace Labs2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил: Гильфанов Алексендр Александрович\nГруппа: 6101-090301D\nИз исходного списка удалите m элементов, начиная с n-ой позиции.",
                           "О программе",
                           MessageBoxButtons.OK);
        }
        private void createList_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm(this);
            createForm.Show();
            Hide();
        }
        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert insert = new Insert(this);
            insert.Show();
            Hide();
        }

        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert insert = new Insert(this);
            insert.Show();
            Hide();
        }
        private void вПроизвольнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert insert = new Insert(this);
            insert.Show();
            Hide();
        }
        private void вНачалеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(this);
            delete.Show();
            Hide();
        }

        private void вКонцеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(this);
            delete.Show();
            Hide();
        }
        private void вПроизвольнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(this);
            delete.Show();
            Hide();
        }
        private void обработкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task task = new Task(this);
            task.Show();
            Hide();
        }
        private void destroyList_Click(object sender, EventArgs e)
        {
            try
            {
                List.list.Destroy();
                MessageBox.Show($"Список разрушен",
                    "Разрушение",
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK);
            }
        }
        private void quite_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainManu_FormClosing(object sender, FormClosingEventArgs e)
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
