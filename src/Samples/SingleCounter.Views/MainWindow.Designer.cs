namespace SingleCounter.Views
{
	partial class MainWindow
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
			this.btnPlus = new System.Windows.Forms.Button();
			this.btnMinus = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.lblCount = new System.Windows.Forms.Label();
			this.labelStepSize = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnPlus
			// 
			this.btnPlus.Location = new System.Drawing.Point(152, 4);
			this.btnPlus.Name = "btnPlus";
			this.btnPlus.Size = new System.Drawing.Size(38, 23);
			this.btnPlus.TabIndex = 0;
			this.btnPlus.Text = "+";
			this.btnPlus.UseVisualStyleBackColor = true;
			// 
			// btnMinus
			// 
			this.btnMinus.Location = new System.Drawing.Point(108, 4);
			this.btnMinus.Name = "btnMinus";
			this.btnMinus.Size = new System.Drawing.Size(38, 23);
			this.btnMinus.TabIndex = 0;
			this.btnMinus.Text = "-";
			this.btnMinus.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(390, 4);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 0;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(268, 4);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(116, 42);
			this.trackBar1.TabIndex = 1;
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(12, 9);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(52, 13);
			this.lblCount.TabIndex = 2;
			this.lblCount.Text = "Count {0}";
			// 
			// labelStepSize
			// 
			this.labelStepSize.AutoSize = true;
			this.labelStepSize.Location = new System.Drawing.Point(196, 9);
			this.labelStepSize.Name = "labelStepSize";
			this.labelStepSize.Size = new System.Drawing.Size(66, 13);
			this.labelStepSize.TabIndex = 2;
			this.labelStepSize.Text = "StepSize {0}";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 38);
			this.Controls.Add(this.labelStepSize);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnMinus);
			this.Controls.Add(this.btnPlus);
			this.Name = "MainWindow";
			this.Text = "Single counter";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPlus;
		private System.Windows.Forms.Button btnMinus;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Label labelStepSize;
	}
}