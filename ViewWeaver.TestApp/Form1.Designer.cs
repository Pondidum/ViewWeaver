namespace ViewWeaver.TestApp
{
	partial class Form1
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
			this.dgv = new System.Windows.Forms.DataGridView();
			this.btnRegister = new System.Windows.Forms.Button();
			this.btnPopulate = new System.Windows.Forms.Button();
			this.btnSetupColumns = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Location = new System.Drawing.Point(12, 12);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(260, 150);
			this.dgv.TabIndex = 0;
			// 
			// btnRegister
			// 
			this.btnRegister.Location = new System.Drawing.Point(12, 168);
			this.btnRegister.Name = "btnRegister";
			this.btnRegister.Size = new System.Drawing.Size(75, 23);
			this.btnRegister.TabIndex = 1;
			this.btnRegister.Text = "Register";
			this.btnRegister.UseVisualStyleBackColor = true;
			this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
			// 
			// btnPopulate
			// 
			this.btnPopulate.Location = new System.Drawing.Point(174, 168);
			this.btnPopulate.Name = "btnPopulate";
			this.btnPopulate.Size = new System.Drawing.Size(75, 23);
			this.btnPopulate.TabIndex = 2;
			this.btnPopulate.Text = "Populate";
			this.btnPopulate.UseVisualStyleBackColor = true;
			this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
			// 
			// btnSetupColumns
			// 
			this.btnSetupColumns.Location = new System.Drawing.Point(93, 168);
			this.btnSetupColumns.Name = "btnSetupColumns";
			this.btnSetupColumns.Size = new System.Drawing.Size(75, 23);
			this.btnSetupColumns.TabIndex = 3;
			this.btnSetupColumns.Text = "Setup";
			this.btnSetupColumns.UseVisualStyleBackColor = true;
			this.btnSetupColumns.Click += new System.EventHandler(this.btnSetupColumns_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnSetupColumns);
			this.Controls.Add(this.btnPopulate);
			this.Controls.Add(this.btnRegister);
			this.Controls.Add(this.dgv);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.Button btnPopulate;
		private System.Windows.Forms.Button btnSetupColumns;
	}
}

