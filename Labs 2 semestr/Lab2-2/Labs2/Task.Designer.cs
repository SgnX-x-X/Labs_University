namespace Labs2
{
    partial class Task
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
            Delete = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            Position = new TextBox();
            Quantity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Delete
            // 
            Delete.Location = new Point(12, 399);
            Delete.Name = "Delete";
            Delete.Size = new Size(122, 39);
            Delete.TabIndex = 0;
            Delete.Text = "Удалить";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(534, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(254, 404);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите количество узлов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 3;
            label2.Text = "Введите первый элемент";
            // 
            // Position
            // 
            Position.Location = new Point(12, 96);
            Position.Name = "Position";
            Position.Size = new Size(100, 23);
            Position.TabIndex = 4;
            // 
            // Quantity
            // 
            Quantity.Location = new Point(12, 52);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(100, 23);
            Quantity.TabIndex = 5;
            // 
            // Task
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Quantity);
            Controls.Add(Position);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(Delete);
            Name = "Task";
            Text = "Task";
            FormClosing += Task_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Delete;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox Position;
        private TextBox Quantity;
    }
}