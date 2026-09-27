namespace Labs2
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            заданиеToolStripMenuItem = new ToolStripMenuItem();
            createList = new ToolStripMenuItem();
            редактированиеСпискаToolStripMenuItem = new ToolStripMenuItem();
            добавлениеЭлементаToolStripMenuItem = new ToolStripMenuItem();
            вНачалоToolStripMenuItem = new ToolStripMenuItem();
            вКонецToolStripMenuItem = new ToolStripMenuItem();
            вПроизвольнуюToolStripMenuItem = new ToolStripMenuItem();
            удалениеЭлементаToolStripMenuItem = new ToolStripMenuItem();
            вНачалеToolStripMenuItem = new ToolStripMenuItem();
            вКонцеToolStripMenuItem = new ToolStripMenuItem();
            вПроизвольнойToolStripMenuItem = new ToolStripMenuItem();
            обработкаToolStripMenuItem = new ToolStripMenuItem();
            destroyList = new ToolStripMenuItem();
            aboutProgram = new ToolStripMenuItem();
            quite = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { заданиеToolStripMenuItem, aboutProgram, quite });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(837, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // заданиеToolStripMenuItem
            // 
            заданиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createList, редактированиеСпискаToolStripMenuItem, обработкаToolStripMenuItem, destroyList });
            заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            заданиеToolStripMenuItem.Size = new Size(64, 20);
            заданиеToolStripMenuItem.Text = "Задание";
            // 
            // createList
            // 
            createList.Name = "createList";
            createList.Size = new Size(204, 22);
            createList.Text = "Создание списка";
            createList.Click += createList_Click;
            // 
            // редактированиеСпискаToolStripMenuItem
            // 
            редактированиеСпискаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавлениеЭлементаToolStripMenuItem, удалениеЭлементаToolStripMenuItem });
            редактированиеСпискаToolStripMenuItem.Name = "редактированиеСпискаToolStripMenuItem";
            редактированиеСпискаToolStripMenuItem.Size = new Size(204, 22);
            редактированиеСпискаToolStripMenuItem.Text = "Редактирование списка";
            // 
            // добавлениеЭлементаToolStripMenuItem
            // 
            добавлениеЭлементаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вНачалоToolStripMenuItem, вКонецToolStripMenuItem, вПроизвольнуюToolStripMenuItem });
            добавлениеЭлементаToolStripMenuItem.Name = "добавлениеЭлементаToolStripMenuItem";
            добавлениеЭлементаToolStripMenuItem.Size = new Size(196, 22);
            добавлениеЭлементаToolStripMenuItem.Text = "Добавление элемента";
            // 
            // вНачалоToolStripMenuItem
            // 
            вНачалоToolStripMenuItem.Name = "вНачалоToolStripMenuItem";
            вНачалоToolStripMenuItem.Size = new Size(166, 22);
            вНачалоToolStripMenuItem.Text = "В начало";
            вНачалоToolStripMenuItem.Click += вНачалоToolStripMenuItem_Click;
            // 
            // вКонецToolStripMenuItem
            // 
            вКонецToolStripMenuItem.Name = "вКонецToolStripMenuItem";
            вКонецToolStripMenuItem.Size = new Size(166, 22);
            вКонецToolStripMenuItem.Text = "В конец";
            вКонецToolStripMenuItem.Click += вКонецToolStripMenuItem_Click;
            // 
            // вПроизвольнуюToolStripMenuItem
            // 
            вПроизвольнуюToolStripMenuItem.Name = "вПроизвольнуюToolStripMenuItem";
            вПроизвольнуюToolStripMenuItem.Size = new Size(166, 22);
            вПроизвольнуюToolStripMenuItem.Text = "В произвольную";
            вПроизвольнуюToolStripMenuItem.Click += вПроизвольнуюToolStripMenuItem_Click;
            // 
            // удалениеЭлементаToolStripMenuItem
            // 
            удалениеЭлементаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { вНачалеToolStripMenuItem, вКонцеToolStripMenuItem, вПроизвольнойToolStripMenuItem });
            удалениеЭлементаToolStripMenuItem.Name = "удалениеЭлементаToolStripMenuItem";
            удалениеЭлементаToolStripMenuItem.Size = new Size(196, 22);
            удалениеЭлементаToolStripMenuItem.Text = "Удаление элемента";
            // 
            // вНачалеToolStripMenuItem
            // 
            вНачалеToolStripMenuItem.Name = "вНачалеToolStripMenuItem";
            вНачалеToolStripMenuItem.Size = new Size(164, 22);
            вНачалеToolStripMenuItem.Text = "В начале";
            вНачалеToolStripMenuItem.Click += вНачалеToolStripMenuItem_Click;
            // 
            // вКонцеToolStripMenuItem
            // 
            вКонцеToolStripMenuItem.Name = "вКонцеToolStripMenuItem";
            вКонцеToolStripMenuItem.Size = new Size(164, 22);
            вКонцеToolStripMenuItem.Text = "В конце";
            вКонцеToolStripMenuItem.Click += вКонцеToolStripMenuItem_Click;
            // 
            // вПроизвольнойToolStripMenuItem
            // 
            вПроизвольнойToolStripMenuItem.Name = "вПроизвольнойToolStripMenuItem";
            вПроизвольнойToolStripMenuItem.Size = new Size(164, 22);
            вПроизвольнойToolStripMenuItem.Text = "В произвольной";
            вПроизвольнойToolStripMenuItem.Click += вПроизвольнойToolStripMenuItem_Click;
            // 
            // обработкаToolStripMenuItem
            // 
            обработкаToolStripMenuItem.Name = "обработкаToolStripMenuItem";
            обработкаToolStripMenuItem.Size = new Size(204, 22);
            обработкаToolStripMenuItem.Text = "Обработка";
            обработкаToolStripMenuItem.Click += обработкаToolStripMenuItem_Click;
            // 
            // destroyList
            // 
            destroyList.Name = "destroyList";
            destroyList.Size = new Size(204, 22);
            destroyList.Text = "Разрушение";
            destroyList.Click += destroyList_Click;
            // 
            // aboutProgram
            // 
            aboutProgram.Name = "aboutProgram";
            aboutProgram.Size = new Size(94, 20);
            aboutProgram.Text = "О программе";
            aboutProgram.Click += aboutProgram_Click;
            // 
            // quite
            // 
            quite.Name = "quite";
            quite.Size = new Size(53, 20);
            quite.Text = "Выход";
            quite.Click += quite_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(251, 194);
            label1.Name = "label1";
            label1.Size = new Size(315, 56);
            label1.TabIndex = 2;
            label1.Text = "Лабораторная работа №2-2 \r\nДвусвязные циклические списки\r\n";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 480);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainMenu";
            Text = "Лабораторная работа №2-2";
            FormClosing += MainManu_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem заданиеToolStripMenuItem;
        private ToolStripMenuItem createList;
        private ToolStripMenuItem редактированиеСпискаToolStripMenuItem;
        private ToolStripMenuItem обработкаToolStripMenuItem;
        private ToolStripMenuItem destroyList;
        private ToolStripMenuItem aboutProgram;
        private ToolStripMenuItem quite;
        private ToolStripMenuItem добавлениеЭлементаToolStripMenuItem;
        private ToolStripMenuItem вНачалоToolStripMenuItem;
        private ToolStripMenuItem вКонецToolStripMenuItem;
        private ToolStripMenuItem вПроизвольнуюToolStripMenuItem;
        private ToolStripMenuItem удалениеЭлементаToolStripMenuItem;
        private ToolStripMenuItem вНачалеToolStripMenuItem;
        private ToolStripMenuItem вКонцеToolStripMenuItem;
        private ToolStripMenuItem вПроизвольнойToolStripMenuItem;
        private Label label1;
    }
}
