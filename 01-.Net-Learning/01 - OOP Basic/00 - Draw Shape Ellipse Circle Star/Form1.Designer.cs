namespace Draw_Shape_Ellipse_Circle_Star
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
						btnPoly = new Button();
						btnNormal = new Button();
						SuspendLayout();
						// 
						// btnPoly
						// 
						btnPoly.Location = new Point(1145, 479);
						btnPoly.Margin = new Padding(3, 4, 3, 4);
						btnPoly.Name = "btnPoly";
						btnPoly.Size = new Size(143, 75);
						btnPoly.TabIndex = 0;
						btnPoly.Text = "Drawing-Poly";
						btnPoly.UseVisualStyleBackColor = true;
						btnPoly.Click += btnPoly_Click;
						// 
						// btnNormal
						// 
						btnNormal.Location = new Point(958, 479);
						btnNormal.Margin = new Padding(3, 4, 3, 4);
						btnNormal.Name = "btnNormal";
						btnNormal.Size = new Size(145, 75);
						btnNormal.TabIndex = 1;
						btnNormal.Text = "Drawing";
						btnNormal.UseVisualStyleBackColor = true;
						btnNormal.Click += btnNormal_Click;
						// 
						// Form1
						// 
						AutoScaleDimensions = new SizeF(8F, 20F);
						AutoScaleMode = AutoScaleMode.Font;
						ClientSize = new Size(1365, 583);
						Controls.Add(btnNormal);
						Controls.Add(btnPoly);
						Name = "Form1";
						Text = "Form1";
						Paint += Form1_Paint;
						ResumeLayout(false);
				}

				#endregion

				private Button btnPoly;
        private Button btnNormal;
    }
}
