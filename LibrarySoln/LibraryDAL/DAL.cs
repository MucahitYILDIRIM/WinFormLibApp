using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace LibraryDAL
{
    public class DAL
    {
		private IDbExecutor db;
		private IMessageNotifier notifier;

		public DAL()
			: this(new SqlDbExecutor(ConfigurationManager.AppSettings["ConnectionString"]), new MessageBoxNotifier())
		{
		}

		public DAL(IDbExecutor db, IMessageNotifier notifier)
		{
			if (db == null)
				throw new ArgumentNullException("db");
			if (notifier == null)
				throw new ArgumentNullException("notifier");

			this.db = db;
			this.notifier = notifier;
		}

		public DataTable PRC_LOGIN(string userName,string Password)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("@P_userName", userName);
			parameters.Add("@P_password", Password);
			return FillSilently("PRC_LOGIN", parameters);
		}

		public int PRC_DML_MEMBER(string dmlType,string name,string surname,string userName,string Password)
		{
			int etkilenen = 0;

			try
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("@P_dmlType", dmlType);
				parameters.Add("@P_name", name);
				parameters.Add("@P_surname", surname);
				parameters.Add("@P_userName", userName);
				parameters.Add("@P_password", Password);
				etkilenen = db.ExecuteNonQuery("PRC_DML_MEMBER", parameters);
			}
			catch (Exception ex)
			{
				notifier.Show(ex.Message);
				etkilenen = -1;
			}

			return etkilenen;
		}

		public DataTable PRC_GET_BOOKS()
		{
			return FillSilently("PRC_GET_BOOKS", new Dictionary<string, object>());
		}

		public DataTable PRC_GET_BOOK_TYPES()
		{
			return FillSilently("PRC_GET_BOOK_TYPES", new Dictionary<string, object>());
		}

		public DataTable PRC_GET_BOOK_CATEGORIES()
		{
			return FillSilently("PRC_GET_BOOK_CATEGORIES", new Dictionary<string, object>());
		}

		public DataTable PRC_GET_PRINTERY()
		{
			return FillSilently("PRC_GET_PRINTERY", new Dictionary<string, object>());
		}

		public DataTable PRC_GET_CITY()
		{
			return FillSilently("PRC_GET_CITY", new Dictionary<string, object>());
		}

		public DataTable PRC_GET_TOWN(string cityName)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("@P_cityName", cityName);
			return FillSilently("PRC_GET_TOWN", parameters);
		}

		public int PRC_DML_BOOK(string dmlType,string bookName,string printeryDate,string writerName,string writerSurname,string printery,string category, string typeName, int hirePrice)
		{
			int etkilenen = 0;

			try
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("@P_dmlType", dmlType);
				parameters.Add("@P_bookName", bookName);
				parameters.Add("@P_printeryDate", Convert.ToDateTime(printeryDate));
				parameters.Add("@P_writerName", writerName);
				parameters.Add("@P_writerSurname", writerSurname);
				parameters.Add("@P_printery", printery);
				parameters.Add("@P_category", category);
				parameters.Add("@P_typeName", typeName);
				parameters.Add("@P_hirePrice", hirePrice);
				etkilenen = db.ExecuteNonQuery("PRC_DML_BOOK", parameters);
			}
			catch (Exception)
			{
				etkilenen = -1;
			}

			return etkilenen;
		}

		public int PRC_DML_PRINTERY(string PrinteryName, string townName,string cityName , string adress)
		{
			int etkilenen = 0;

			try
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("@P_PrinteryName", PrinteryName);
				parameters.Add("@P_TownName", townName);
				parameters.Add("@P_CityName", cityName);
				parameters.Add("@P_Adress", adress);
				etkilenen = db.ExecuteNonQuery("PRC_DML_PRINTERY", parameters);
			}
			catch (Exception)
			{
				etkilenen = -1;
			}

			return etkilenen;
		}

		public int PRC_DML_HIRE(string dmlType,int bookId,string userName,string responseTime,int isBack,int price,int hireId)
		{
			int etkilenen = 0;

			try
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("@P_dmlType", dmlType);
				parameters.Add("@P_bookId", bookId);
				parameters.Add("@P_userName", userName);
				parameters.Add("@P_responseTime", Convert.ToDateTime(responseTime));
				parameters.Add("@P_isBack", isBack);
				parameters.Add("@P_price", price);
				parameters.Add("@P_hireId", hireId);
				etkilenen = db.ExecuteNonQuery("PRC_DML_HIRE", parameters);
			}
			catch (Exception ex)
			{
				notifier.Show(ex.Message);
				etkilenen = -1;
			}

			return etkilenen;
		}

		public DataTable PRC_GET_HIRED_BOOK(string userName)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("@P_UserName", userName);
			return FillSilently("PRC_GET_HIRED_BOOK", parameters);
		}

		// Okuma prosedurlerinde hatalar eskiden oldugu gibi yutulur; o ana kadar
		// doldurulmus (veya bos) tablo dondurulur.
		private DataTable FillSilently(string procedureName, Dictionary<string, object> parameters)
		{
			DataTable dt = new DataTable();
			try
			{
				db.Fill(procedureName, parameters, dt);
			}
			catch
			{

			}
			return dt;
		}
	}
}
