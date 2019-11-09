namespace LibrarySoln
{
	partial class UserProfile
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
			this.dgvHiredBooks = new System.Windows.Forms.DataGridView();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnUserScreen = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvHiredBooks)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvHiredBooks
			// 
			this.dgvHiredBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHiredBooks.Location = new System.Drawing.Point(12, 12);
			this.dgvHiredBooks.MultiSelect = false;
			this.dgvHiredBooks.Name = "dgvHiredBooks";
			this.dgvHiredBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHiredBooks.Size = new System.Drawing.Size(447, 381);
			this.dgvHiredBooks.TabIndex = 0;
			// 
			// btnBack
			// 
			this.btnBack.Location = new System.Drawing.Point(384, 402);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 23);
			this.btnBack.TabIndex = 1;
			this.btnBack.Text = "İade Et";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnUserScreen
			// 
			this.btnUserScreen.Location = new System.Drawing.Point(12, 402);
			this.btnUserScreen.Name = "btnUserScreen";
			this.btnUserScreen.Size = new System.Drawing.Size(131, 23);
			this.btnUserScreen.TabIndex = 2;
			this.btnUserScreen.Text = "Kullanıcı Arayüzü";
			this.btnUserScreen.UseVisualStyleBackColor = true;
			this.btnUserScreen.Click += new System.EventHandler(this.btnUserScreen_Click);
			// 
			// UserProfile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(475, 437);
			this.Controls.Add(this.btnUserScreen);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.dgvHiredBooks);
			this.Name = "UserProfile";
			this.Text = "Profil";
			this.Load += new System.EventHandler(this.UserProfile_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvHiredBooks)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvHiredBooks;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnUserScreen;
	}
}