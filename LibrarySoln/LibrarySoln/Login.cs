using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryDAL;

namespace LibrarySoln
{
	public partial class Login : Form
	{

		public Login()
		{			
			InitializeComponent();
			//to do: silinecek 
			tbUserName.Text = "admin";
			tbPassword.Text = "admin";
		}
		private void btnLogin_Click(object sender, EventArgs e)
		{
			DAL dl = new DAL();
			DataTable userInformation = dl.PRC_LOGIN(tbUserName.Text, tbPassword.Text);
			if(userInformation.Rows.Count != 0)
			{
				UserScreen userScreen = new UserScreen(userInformation.Rows[0].ItemArray[6].ToString());
				userScreen.Owner = this;
				userScreen.Show();
				this.Hide();

				
			}
			else
			{
				MessageBox.Show("Hatali Kullanici Adi veya Sifre!!!\nTekrar Deneyiniz");
			}

		}

		private void btnSignUp_Click(object sender, EventArgs e)
		{
			Signup signupForm = new Signup();
			signupForm.Owner = this;
			signupForm.Show();
			this.Hide();
		}
	}
}