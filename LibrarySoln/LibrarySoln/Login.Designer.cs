namespace LibrarySoln
{
	partial class Login
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
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSignUp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(57, 83);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(67, 13);
			this.lblUserName.TabIndex = 0;
			this.lblUserName.Text = "Kullanıcı Adı:";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(79, 116);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(40, 13);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Parola:";
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(130, 80);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(100, 20);
			this.tbUserName.TabIndex = 2;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(130, 109);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '•';
			this.tbPassword.Size = new System.Drawing.Size(100, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(101, 156);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(87, 23);
			this.btnLogin.TabIndex = 4;
			this.btnLogin.Text = "Giriş Yap";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(36, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(245, 42);
			this.label3.TabIndex = 5;
			this.label3.Text = "Kütüphane Giriş";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSignUp
			// 
			this.btnSignUp.Location = new System.Drawing.Point(101, 186);
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.Size = new System.Drawing.Size(87, 23);
			this.btnSignUp.TabIndex = 6;
			this.btnSignUp.Text = "Üye Ol";
			this.btnSignUp.UseVisualStyleBackColor = true;
			this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 232);
			this.Controls.Add(this.btnSignUp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbUserName);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUserName);
			this.Name = "Login";
			this.Text = "Giriş Yap";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSignUp;
	}
}

