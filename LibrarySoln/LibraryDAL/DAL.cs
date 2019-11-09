using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryDAL
{
    public class DAL
    {
		private SqlConnection con;
		public DAL()
		{
			con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
		}

		public DataTable PRC_LOGIN(string userName,string Password)
		{
			DataTable dt = new DataTable();

			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_LOGIN", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@P_userName", userName);
				cmd.Parameters.AddWithValue("@P_password", Password);
				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);
				DataAdapter.Fill(dt);
			}
			catch (Exception ex)
			{
				
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}

		public int PRC_DML_MEMBER(string dmlType,string name,string surname,string userName,string Password)
		{
			int etkilenen = 0;

			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_DML_MEMBER", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@P_dmlType", dmlType);
				cmd.Parameters.AddWithValue("@P_name", name);
				cmd.Parameters.AddWithValue("@P_surname", surname);
				cmd.Parameters.AddWithValue("@P_userName", userName);
				cmd.Parameters.AddWithValue("@P_password", Password);
				etkilenen = cmd.ExecuteNonQuery();				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				etkilenen = -1;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		
			return etkilenen;
		}

		public DataTable PRC_GET_BOOKS()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_BOOKS", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{
				
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}

		public DataTable PRC_GET_BOOK_TYPES()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_BOOK_TYPES", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}
		
		public DataTable PRC_GET_BOOK_CATEGORIES()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_BOOK_CATEGORIES", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}

		public DataTable PRC_GET_PRINTERY()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_PRINTERY", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}

		public DataTable PRC_GET_CITY()
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_CITY", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}

		public DataTable PRC_GET_TOWN(string cityName)
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_TOWN", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@P_cityName", cityName);
				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}
		public int PRC_DML_BOOK(string dmlType,string bookName,string printeryDate,string writerName,string writerSurname,string printery,string category, string typeName, int hirePrice)
		{
			int etkilenen = 0;

			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_DML_BOOK", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@P_dmlType", dmlType);
				cmd.Parameters.AddWithValue("@P_bookName", bookName);
				cmd.Parameters.AddWithValue("@P_printeryDate", Convert.ToDateTime(printeryDate));
				cmd.Parameters.AddWithValue("@P_writerName", writerName);
				cmd.Parameters.AddWithValue("@P_writerSurname", writerSurname);
				cmd.Parameters.AddWithValue("@P_printery", printery);
				cmd.Parameters.AddWithValue("@P_category", category);
				cmd.Parameters.AddWithValue("@P_typeName", typeName);
				cmd.Parameters.AddWithValue("@P_hirePrice", hirePrice);
				etkilenen = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				etkilenen = -1;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return etkilenen;
		}

		public int PRC_DML_PRINTERY(string PrinteryName, string townName,string cityName , string adress)
		{
			int etkilenen = 0;

			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_DML_PRINTERY", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@P_PrinteryName", PrinteryName);
				cmd.Parameters.AddWithValue("@P_TownName", townName);
				cmd.Parameters.AddWithValue("@P_CityName", cityName);
				cmd.Parameters.AddWithValue("@P_Adress", adress);
				etkilenen = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				etkilenen = -1;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return etkilenen;
		}

		public int PRC_DML_HIRE(string dmlType,int bookId,string userName,string responseTime,int isBack,int price,int hireId)
		{
			int etkilenen = 0;

			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_DML_HIRE", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@P_dmlType", dmlType);
				cmd.Parameters.AddWithValue("@P_bookId", bookId);
				cmd.Parameters.AddWithValue("@P_userName", userName);
				cmd.Parameters.AddWithValue("@P_responseTime",Convert.ToDateTime(responseTime));
				cmd.Parameters.AddWithValue("@P_isBack", isBack);
				cmd.Parameters.AddWithValue("@P_price", price);
				cmd.Parameters.AddWithValue("@P_hireId", hireId);
				etkilenen = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				etkilenen = -1;
			}
			finally
			{
				con.Close();
				con.Dispose();
			}

			return etkilenen;
		}

		public DataTable PRC_GET_HIRED_BOOK(string userName)
		{
			DataTable dt = new DataTable();
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("PRC_GET_HIRED_BOOK", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@P_UserName", userName);

				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);

				DataAdapter.Fill(dt);
			}
			catch
			{

			}
			finally
			{
				con.Close();
				con.Dispose();
			}
			return dt;
		}



	}
}
