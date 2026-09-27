namespace Labs2
{
    partial class Insert
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
            label1 = new Label();
            firstButton = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            Value = new TextBox();
            Number = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите число";
            // 
            // firstButton
            // 
            firstButton.Location = new Point(12, 393);
            firstButton.Name = "firstButton";
            firstButton.Size = new Size(102, 45);
            firstButton.TabIndex = 1;
            firstButton.Text = "Добавить в начало";
            firstButton.UseVisualStyleBackColor = true;
            firstButton.Click += firstButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(548, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(240, 400);
            dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 3;
            label2.Text = "Введите номер";
            // 
            // button2
            // 
            button2.Location = new Point(120, 393);
            button2.Name = "button2";
            button2.Size = new Size(102, 45);
            button2.TabIndex = 4;
            button2.Text = "Добавить в конец";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(228, 393);
            button3.Name = "button3";
            button3.Size = new Size(110, 45);
            button3.TabIndex = 5;
            button3.Text = "Добавить в произвольную";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Value
            // 
            Value.Location = new Point(12, 56);
            Value.Name = "Value";
            Value.Size = new Size(100, 23);
            Value.TabIndex = 6;
            // 
            // Number
            // 
            Number.Location = new Point(12, 112);
            Number.Name = "Number";
            Number.Size = new Size(100, 23);
            Number.TabIndex = 7;
            // 
            // Insert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Number);
            Controls.Add(label2);
            Controls.Add(Value);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(firstButton);
            Controls.Add(label1);
            Name = "Insert";
            Text = "InsertAfterLast";
            FormClosing += Insert_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button firstButton;
        private DataGridView dataGridView1;
        private Label label2;
        private Button button2;
        private Button button3;
        private TextBox Value;
        private TextBox Number;
    }
}