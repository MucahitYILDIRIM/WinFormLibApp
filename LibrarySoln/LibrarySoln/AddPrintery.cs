using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryDAL;
namespace LibrarySoln
{
	public partial class AddPrintery : Form
	{
		private UserScreen owner;
		public AddPrintery(UserScreen us)
		{
			InitializeComponent();
			owner = us;
		}

		private void AddPrintery_Load(object sender, EventArgs e)
		{
			FillCity();
		}

		private void btnAddPrintery_Click(object sender, EventArgs e)
		{
			DAL dl = new DAL();
			if (String.IsNullOrEmpty(tbPrintery.Text) || String.IsNullOrEmpty(cbTown.SelectedItem.ToString()) || String.IsNullOrEmpty(cbCity.SelectedItem.ToString()) || String.IsNullOrEmpty(rtbAdress.Text))
			{
				MessageBox.Show("Alanları Doldurunuz");
			}
			else
			{
				int sonuc = dl.PRC_DML_PRINTERY(tbPrintery.Text, cbTown.SelectedItem.ToString(), cbCity.SelectedItem.ToString(), rtbAdress.Text);
				owner.FillcbPrintery();
				this.Visible = false;
			}
			
		}
		private void FillCity()
		{
			DAL dl = new DAL();
			DataTable dt = dl.PRC_GET_CITY();

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				cbCity.Items.Add(dt.Rows[i].ItemArray[0]);
			}
		}

		private void FillTown(string City)
		{
			DAL dl = new DAL();
			DataTable dt = dl.PRC_GET_TOWN(City);
			cbTown.Items.Clear();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				cbTown.Items.Add(dt.Rows[i].ItemArray[0]);
			}
		}

		private void cbCity_SelectedValueChanged(object sender, EventArgs e)
		{
			FillTown(cbCity.SelectedItem.ToString());
		}
	}
}
