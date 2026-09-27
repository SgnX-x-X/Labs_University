namespace WinFormsApp1
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
            CreateTree1 = new Button();
            Key = new TextBox();
            CreateTree2 = new Button();
            Info = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // CreateTree1
            // 
            CreateTree1.Location = new Point(12, 401);
            CreateTree1.Name = "CreateTree1";
            CreateTree1.Size = new Size(113, 37);
            CreateTree1.TabIndex = 0;
            CreateTree1.Text = "Создать дерево 1";
            CreateTree1.UseVisualStyleBackColor = true;
            CreateTree1.Click += CreateTree1_Click;
            // 
            // Key
            // 
            Key.Location = new Point(12, 372);
            Key.Name = "Key";
            Key.Size = new Size(113, 23);
            Key.TabIndex = 1;
            // 
            // CreateTree2
            // 
            CreateTree2.Location = new Point(131, 401);
            CreateTree2.Name = "CreateTree2";
            CreateTree2.Size = new Size(113, 37);
            CreateTree2.TabIndex = 2;
            CreateTree2.Text = "Создать дерево 2";
            CreateTree2.UseVisualStyleBackColor = true;
            CreateTree2.Click += CreateTree2_Click;
            // 
            // Info
            // 
            Info.Location = new Point(131, 372);
            Info.Name = "Info";
            Info.Size = new Size(113, 23);
            Info.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 354);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 4;
            label1.Text = "Ключ (число)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 354);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 5;
            label2.Text = "Инфо (символ)";
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Info);
            Controls.Add(CreateTree2);
            Controls.Add(Key);
            Controls.Add(CreateTree1);
            Name = "CreateForm";
            Text = "CreateForm";
            FormClosing += CreateForm_FormClosing;
            Paint += PaintTree;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateTree1;
        private TextBox Key;
        private Button CreateTree2;
        private TextBox Info;
        private Label label1;
        private Label label2;
    }
}