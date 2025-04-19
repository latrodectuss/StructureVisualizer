namespace StructureVisualizer
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
			button1 = new Button();
			button2 = new Button();
			textBoxSize = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(254, 73);
			button1.Name = "button1";
			button1.Size = new Size(266, 138);
			button1.TabIndex = 0;
			button1.Text = "Тык для выбора файла структуры";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(254, 281);
			button2.Name = "button2";
			button2.Size = new Size(266, 45);
			button2.TabIndex = 1;
			button2.Text = "Тык для визуализации";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// textBoxSize
			// 
			textBoxSize.Location = new Point(596, 290);
			textBoxSize.Name = "textBoxSize";
			textBoxSize.Size = new Size(125, 27);
			textBoxSize.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(621, 256);
			label1.Name = "label1";
			label1.Size = new Size(72, 20);
			label1.TabIndex = 3;
			label1.Text = "Масштаб";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(label1);
			Controls.Add(textBoxSize);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Button button2;
		private TextBox textBoxSize;
		private Label label1;
	}
}
