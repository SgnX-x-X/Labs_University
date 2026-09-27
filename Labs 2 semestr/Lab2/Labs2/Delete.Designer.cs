namespace Labs2
{
    partial class Delete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Number = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 400);
            button1.Name = "button1";
            button1.Size = new Size(93, 38);
            button1.TabIndex = 0;
            button1.Text = "Удалить из начала";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(111, 400);
            button2.Name = "button2";
            button2.Size = new Size(93, 38);
            button2.TabIndex = 1;
            button2.Text = "Удалить с конца";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(210, 400);
            button3.Name = "button3";
            button3.Size = new Size(93, 38);
            button3.TabIndex = 2;
            button3.Text = "удалить выбранное";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Number
            // 
            Number.Location = new Point(12, 62);
            Number.Name = "Number";
            Number.Size = new Size(100, 23);
            Number.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 6;
            label2.Text = "Введите номер";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(539, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(249, 394);
            dataGridView1.TabIndex = 7;
            // 
            // Delete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(Number);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Delete";
            Text = "Удаление";
            FormClosing += Delete_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox Number;
        private Label label2;
        private DataGridView dataGridView1;
    }
}