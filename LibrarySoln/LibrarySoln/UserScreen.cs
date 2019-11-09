using System;
using System.Data;
using System.Windows.Forms;
using LibraryDAL;

namespace LibrarySoln
{
	public partial class UserScreen : Form
	{
		private string userName;
		public UserScreen(string userName)
		{
			InitializeComponent();
			this.userName = userName;
		}

		private void UserScreen_Load(object sender, EventArgs e)
		{
			FillclbBookCategory();
			FillcbBookType();
			FilldgvBook();
			FillcbPrintery();
			FillUserInf(userName);
			
		}


		private void btnAddBook_Click(object sender, EventArgs e)
		{
			DAL dl = new DAL();
			try
			{

				string categories = "";
				for (int i = 0; i < clbBookCategory.CheckedItems.Count; i++)
				{
					if (i == 0)
						categories += clbBookCategory.CheckedItems[i];
					else
						categories += ";" + clbBookCategory.CheckedItems[i];
				}
				dl.PRC_DML_BOOK("I", tbBookName.Text, dpPrinteryDate.Value.ToShortDateString(), tbWriterName.Text, tbWriterSurname.Text, cbPrintery.SelectedItem.ToString(), categories,
					cbBookType.SelectedItem.ToString(), Convert.ToInt32(tbHirePrice.Text));

				FilldgvBook();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Biligleri Kontrol Ediniz.");
			}
		}

		private void FilldgvBook()
		{
			DAL dl = new DAL();
			dgvBooks.DataSource = dl.PRC_GET_BOOKS();
			dgvBooks.Columns[0].Visible = false;
			dgvBooks.Columns[1].HeaderText = "Kitap Adı";
			dgvBooks.Columns[2].HeaderText = "Yazar";
			dgvBooks.Columns[3].HeaderText = "Basımevi";
			dgvBooks.Columns[4].HeaderText = "Yayım Tarihi";
			dgvBooks.Columns[5].HeaderText = "Ücret";
		}

		private void FillUserInf(string userName)
		{
			lblUserName.Text = "Kullanıcı Adı..: " + userName;
			lblDate.Text = "Tarih..: " + DateTime.Now.ToShortDateString();
		}

		private void FillcbBookType()
		{
			DAL dl = new DAL();
			DataTable dt = dl.PRC_GET_BOOK_TYPES();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				cbBookType.Items.Add(dt.Rows[i].ItemArray[0]);
			}
		}

		private void FillclbBookCategory()
		{
			DAL dl = new DAL();
			DataTable dt = dl.PRC_GET_BOOK_CATEGORIES();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				clbBookCategory.Items.Add(dt.Rows[i].ItemArray[1]);
			}
		}

		public void FillcbPrintery()
		{
			DAL dl = new DAL();
			DataTable dt = dl.PRC_GET_PRINTERY();
			cbPrintery.Items.Clear();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				cbPrintery.Items.Add(dt.Rows[i].ItemArray[0]);
			}
		}

		private void btnAddPrintery_Click(object sender, EventArgs e)
		{
			AddPrintery addPrinteryFrom = new AddPrintery(this);
			addPrinteryFrom.Owner = this;
			addPrinteryFrom.Show();
		}

		private void btnHire_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvBooks.SelectedRows.Count != 0)
				{
					DAL dl = new DAL();
					int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["bookId"].Value.ToString());
					string responseTime = DateTime.Now.AddDays(7).ToShortDateString();
					int price = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["hirePrice"].Value.ToString());
					int sonuc=dl.PRC_DML_HIRE("I", bookId, userName, responseTime, 0, price,0);
					if(sonuc>0)
						MessageBox.Show("Kitap Kiralandi.");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Lutfen Kitap Seciniz!");
			}
		}

		private void btnProfile_Click(object sender, EventArgs e)
		{
			UserProfile userProfile = new UserProfile(userName);
			userProfile.Owner = this;
			userProfile.Show();
			this.Hide();
		}
	}
}
