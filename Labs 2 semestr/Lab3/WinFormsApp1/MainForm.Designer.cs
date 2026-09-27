namespace WinFormsApp1
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            заданиеToolStripMenuItem = new ToolStripMenuItem();
            Create = new ToolStripMenuItem();
            Task = new ToolStripMenuItem();
            Destroy = new ToolStripMenuItem();
            AboutProgram = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { заданиеToolStripMenuItem, AboutProgram, Exit });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(646, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // заданиеToolStripMenuItem
            // 
            заданиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Create, Task, Destroy });
            заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            заданиеToolStripMenuItem.Size = new Size(64, 20);
            заданиеToolStripMenuItem.Text = "Задание";
            // 
            // Create
            // 
            Create.Name = "Create";
            Create.Size = new Size(178, 22);
            Create.Text = "Создание деревьев";
            Create.Click += Create_Click;
            // 
            // Task
            // 
            Task.Name = "Task";
            Task.Size = new Size(178, 22);
            Task.Text = "Обработка";
            Task.Click += Task_Click;
            // 
            // Destroy
            // 
            Destroy.Name = "Destroy";
            Destroy.Size = new Size(180, 22);
            Destroy.Text = "Разрушение";
            Destroy.Click += Destroy_Click;
            // 
            // AboutProgram
            // 
            AboutProgram.Name = "AboutProgram";
            AboutProgram.Size = new Size(94, 20);
            AboutProgram.Text = "О программе";
            AboutProgram.Click += AboutProgram_Click;
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(53, 20);
            Exit.Text = "Выход";
            Exit.Click += Exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(192, 106);
            label1.Name = "label1";
            label1.Size = new Size(278, 60);
            label1.TabIndex = 2;
            label1.Text = "Лабораторная работа №3\r\n              Деревья";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 300);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Лабораторная работа №3";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem заданиеToolStripMenuItem;
        private ToolStripMenuItem Create;
        private ToolStripMenuItem Task;
        private ToolStripMenuItem Destroy;
        private ToolStripMenuItem AboutProgram;
        private ToolStripMenuItem Exit;
        private Label label1;
    }
}
