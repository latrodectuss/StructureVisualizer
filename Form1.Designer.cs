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
			buttonGetFile = new Button();
			button2D = new Button();
			textBoxSize = new TextBox();
			label1 = new Label();
			button3D = new Button();
			SuspendLayout();
			// 
			// buttonGetFile
			// 
			buttonGetFile.Location = new Point(254, 73);
			buttonGetFile.Name = "buttonGetFile";
			buttonGetFile.Size = new Size(266, 138);
			buttonGetFile.TabIndex = 0;
			buttonGetFile.Text = "Тык для выбора файла структуры";
			buttonGetFile.UseVisualStyleBackColor = true;
			buttonGetFile.Click += buttonGetFile_Click;
			// 
			// button2D
			// 
			button2D.Location = new Point(254, 244);
			button2D.Name = "button2D";
			button2D.Size = new Size(266, 45);
			button2D.TabIndex = 1;
			button2D.Text = "Тык для визуализации";
			button2D.UseVisualStyleBackColor = true;
			button2D.Click += button2D_Click;
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
			// button3D
			// 
			button3D.Location = new Point(254, 313);
			button3D.Name = "button3D";
			button3D.Size = new Size(266, 45);
			button3D.TabIndex = 4;
			button3D.Text = "Тык для визуализации в 3D";
			button3D.UseVisualStyleBackColor = true;
			button3D.Click += button3D_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(button3D);
			Controls.Add(label1);
			Controls.Add(textBoxSize);
			Controls.Add(button2D);
			Controls.Add(buttonGetFile);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonGetFile;
		private Button button2D;
		private TextBox textBoxSize;
		private Label label1;
		private Button button3D;
	}
}
