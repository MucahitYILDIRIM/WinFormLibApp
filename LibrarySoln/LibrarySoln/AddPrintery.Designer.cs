namespace LibrarySoln
{
	partial class AddPrintery
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
			this.tbPrintery = new System.Windows.Forms.TextBox();
			this.cbCity = new System.Windows.Forms.ComboBox();
			this.cbTown = new System.Windows.Forms.ComboBox();
			this.rtbAdress = new System.Windows.Forms.RichTextBox();
			this.lblPritery = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblTown = new System.Windows.Forms.Label();
			this.lblAdress = new System.Windows.Forms.Label();
			this.btnAddPrintery = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbPrintery
			// 
			this.tbPrintery.Location = new System.Drawing.Point(95, 27);
			this.tbPrintery.Name = "tbPrintery";
			this.tbPrintery.Size = new System.Drawing.Size(129, 20);
			this.tbPrintery.TabIndex = 0;
			// 
			// cbCity
			// 
			this.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCity.FormattingEnabled = true;
			this.cbCity.Location = new System.Drawing.Point(95, 62);
			this.cbCity.Name = "cbCity";
			this.cbCity.Size = new System.Drawing.Size(129, 21);
			this.cbCity.TabIndex = 1;
			this.cbCity.SelectedValueChanged += new System.EventHandler(this.cbCity_SelectedValueChanged);
			// 
			// cbTown
			// 
			this.cbTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTown.FormattingEnabled = true;
			this.cbTown.Location = new System.Drawing.Point(95, 102);
			this.cbTown.Name = "cbTown";
			this.cbTown.Size = new System.Drawing.Size(129, 21);
			this.cbTown.TabIndex = 2;
			// 
			// rtbAdress
			// 
			this.rtbAdress.Location = new System.Drawing.Point(95, 140);
			this.rtbAdress.Name = "rtbAdress";
			this.rtbAdress.Size = new System.Drawing.Size(129, 75);
			this.rtbAdress.TabIndex = 3;
			this.rtbAdress.Text = "";
			// 
			// lblPritery
			// 
			this.lblPritery.AutoSize = true;
			this.lblPritery.Location = new System.Drawing.Point(18, 30);
			this.lblPritery.Name = "lblPritery";
			this.lblPritery.Size = new System.Drawing.Size(71, 13);
			this.lblPritery.TabIndex = 4;
			this.lblPritery.Text = "Yapımevi Adı:";
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Location = new System.Drawing.Point(55, 65);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(34, 13);
			this.lblCity.TabIndex = 5;
			this.lblCity.Text = "Şehir:";
			// 
			// lblTown
			// 
			this.lblTown.AutoSize = true;
			this.lblTown.Location = new System.Drawing.Point(54, 105);
			this.lblTown.Name = "lblTown";
			this.lblTown.Size = new System.Drawing.Size(27, 13);
			this.lblTown.TabIndex = 6;
			this.lblTown.Text = "İlçe:";
			// 
			// lblAdress
			// 
			this.lblAdress.AutoSize = true;
			this.lblAdress.Location = new System.Drawing.Point(46, 143);
			this.lblAdress.Name = "lblAdress";
			this.lblAdress.Size = new System.Drawing.Size(37, 13);
			this.lblAdress.TabIndex = 7;
			this.lblAdress.Text = "Adres:";
			// 
			// btnAddPrintery
			// 
			this.btnAddPrintery.Location = new System.Drawing.Point(149, 230);
			this.btnAddPrintery.Name = "btnAddPrintery";
			this.btnAddPrintery.Size = new System.Drawing.Size(75, 23);
			this.btnAddPrintery.TabIndex = 8;
			this.btnAddPrintery.Text = "Kaydet";
			this.btnAddPrintery.UseVisualStyleBackColor = true;
			this.btnAddPrintery.Click += new System.EventHandler(this.btnAddPrintery_Click);
			// 
			// AddPrintery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 265);
			this.Controls.Add(this.btnAddPrintery);
			this.Controls.Add(this.lblAdress);
			this.Controls.Add(this.lblTown);
			this.Controls.Add(this.lblCity);
			this.Controls.Add(this.lblPritery);
			this.Controls.Add(this.rtbAdress);
			this.Controls.Add(this.cbTown);
			this.Controls.Add(this.cbCity);
			this.Controls.Add(this.tbPrintery);
			this.Name = "AddPrintery";
			this.Text = "Yapımevi Tanımlama";
			this.Load += new System.EventHandler(this.AddPrintery_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbPrintery;
		private System.Windows.Forms.ComboBox cbCity;
		private System.Windows.Forms.ComboBox cbTown;
		private System.Windows.Forms.RichTextBox rtbAdress;
		private System.Windows.Forms.Label lblPritery;
		private System.Windows.Forms.Label lblCity;
		private System.Windows.Forms.Label lblTown;
		private System.Windows.Forms.Label lblAdress;
		private System.Windows.Forms.Button btnAddPrintery;
	}
}