namespace FirstLaba
{
    partial class Form1
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
            MenuAbout = new ToolStripMenuItem();
            MenuTask = new ToolStripMenuItem();
            MenuExit = new ToolStripMenuItem();
            panelAbout = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            buttonResult = new Button();
            labelResult = new Label();
            label3 = new Label();
            textN = new TextBox();
            textX = new TextBox();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            panelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuAbout, MenuTask, MenuExit });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuAbout
            // 
            MenuAbout.Name = "MenuAbout";
            MenuAbout.Size = new Size(94, 20);
            MenuAbout.Text = "О программе";
            MenuAbout.Click += MenuAbout_Click;
            // 
            // MenuTask
            // 
            MenuTask.Name = "MenuTask";
            MenuTask.Size = new Size(64, 20);
            MenuTask.Text = "Задание";
            MenuTask.Click += MenuTask_Click;
            // 
            // MenuExit
            // 
            MenuExit.Name = "MenuExit";
            MenuExit.Size = new Size(53, 20);
            MenuExit.Text = "Выход";
            MenuExit.Click += MenuExit_Click;
            // 
            // panelAbout
            // 
            panelAbout.Controls.Add(label1);
            panelAbout.Controls.Add(pictureBox1);
            panelAbout.Location = new Point(40, 70);
            panelAbout.Name = "panelAbout";
            panelAbout.Size = new Size(748, 291);
            panelAbout.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(325, 50);
            label1.TabIndex = 0;
            label1.Text = "Гильфанов Александр Александрович\r\nГруппа: 6101-090301D\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Снимок_экрана_2026_03_19_212845;
            pictureBox1.Location = new Point(-28, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 214);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonResult);
            panel1.Controls.Add(labelResult);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textN);
            panel1.Controls.Add(textX);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(26, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 382);
            panel1.TabIndex = 2;
            // 
            // buttonResult
            // 
            buttonResult.Location = new Point(9, 131);
            buttonResult.Name = "buttonResult";
            buttonResult.Size = new Size(75, 23);
            buttonResult.TabIndex = 5;
            buttonResult.Text = "Расчитать";
            buttonResult.UseVisualStyleBackColor = true;
            buttonResult.Click += buttonResult_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(178, 61);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 15);
            labelResult.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 65);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 3;
            label3.Text = "Число членов ряда";
            // 
            // textN
            // 
            textN.Location = new Point(7, 83);
            textN.Name = "textN";
            textN.Size = new Size(100, 23);
            textN.TabIndex = 2;
            // 
            // textX
            // 
            textX.Location = new Point(11, 33);
            textX.Name = "textX";
            textX.Size = new Size(100, 23);
            textX.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 12);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 0;
            label2.Text = "Число";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panelAbout);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Лабораторная работа №1";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelAbout.ResumeLayout(false);
            panelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuAbout;
        private ToolStripMenuItem MenuTask;
        private ToolStripMenuItem MenuExit;
        private Panel panelAbout;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox textN;
        private TextBox textX;
        private Label label2;
        private Button buttonResult;
        private Label labelResult;
        private Label label3;
    }
}
