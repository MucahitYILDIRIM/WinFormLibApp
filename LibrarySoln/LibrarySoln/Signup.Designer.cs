namespace LibrarySoln
{
	partial class Signup
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
			this.btnSignUp = new System.Windows.Forms.Button();
			this.lblBaslik = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblSurname = new System.Windows.Forms.Label();
			this.tbSurname = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSignUp
			// 
			this.btnSignUp.Location = new System.Drawing.Point(129, 206);
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.Size = new System.Drawing.Size(87, 23);
			this.btnSignUp.TabIndex = 16;
			this.btnSignUp.Text = "Üye Ol";
			this.btnSignUp.UseVisualStyleBackColor = true;
			this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
			// 
			// lblBaslik
			// 
			this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBaslik.Location = new System.Drawing.Point(61, 26);
			this.lblBaslik.Name = "lblBaslik";
			this.lblBaslik.Size = new System.Drawing.Size(245, 42);
			this.lblBaslik.TabIndex = 17;
			this.lblBaslik.Text = "Kütüphane Kayıt";
			this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(155, 168);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '•';
			this.tbPassword.Size = new System.Drawing.Size(100, 20);
			this.tbPassword.TabIndex = 14;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(155, 142);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(100, 20);
			this.tbUserName.TabIndex = 13;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(109, 175);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(40, 13);
			this.lblPassword.TabIndex = 8;
			this.lblPassword.Text = "Parola:";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(82, 149);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(67, 13);
			this.lblUserName.TabIndex = 7;
			this.lblUserName.Text = "Kullanıcı Adı:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(126, 93);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(23, 13);
			this.lblName.TabIndex = 14;
			this.lblName.Text = "Ad:";
			// 
			// lblSurname
			// 
			this.lblSurname.AutoSize = true;
			this.lblSurname.Location = new System.Drawing.Point(109, 119);
			this.lblSurname.Name = "lblSurname";
			this.lblSurname.Size = new System.Drawing.Size(40, 13);
			this.lblSurname.TabIndex = 15;
			this.lblSurname.Text = "Soyad:";
			// 
			// tbSurname
			// 
			this.tbSurname.Location = new System.Drawing.Point(155, 116);
			this.tbSurname.Name = "tbSurname";
			this.tbSurname.Size = new System.Drawing.Size(100, 20);
			this.tbSurname.TabIndex = 10;
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(155, 90);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(100, 20);
			this.tbName.TabIndex = 9;
			// 
			// Signup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 278);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.tbSurname);
			this.Controls.Add(this.lblSurname);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnSignUp);
			this.Controls.Add(this.lblBaslik);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUserName);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Name = "Signup";
			this.Text = "Kayıt Ol";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSignUp;
		private System.Windows.Forms.Label lblBaslik;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblSurname;
		private System.Windows.Forms.TextBox tbSurname;
		private System.Windows.Forms.TextBox tbName;
	}
}