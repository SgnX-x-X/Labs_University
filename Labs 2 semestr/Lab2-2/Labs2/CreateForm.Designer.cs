namespace Labs2
{
    partial class CreateForm
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
            inputValue = new TextBox();
            Create = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // inputValue
            // 
            inputValue.Location = new Point(12, 57);
            inputValue.Name = "inputValue";
            inputValue.Size = new Size(303, 23);
            inputValue.TabIndex = 0;
            // 
            // Create
            // 
            Create.Location = new Point(12, 396);
            Create.Name = "Create";
            Create.Size = new Size(87, 42);
            Create.TabIndex = 1;
            Create.Text = "Создать";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(552, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(236, 403);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Ввод списка";
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(Create);
            Controls.Add(inputValue);
            Name = "CreateForm";
            Text = "CreateForm";
            FormClosing += CreateForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputValue;
        private Button Create;
        private DataGridView dataGridView1;
        private Label label1;
    }
}