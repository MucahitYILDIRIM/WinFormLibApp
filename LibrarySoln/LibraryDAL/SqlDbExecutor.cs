using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryDAL
{
	/// <summary>
	/// SQL Server uzerinde stored procedure calistirir. Eski DAL davranisini korur:
	/// tek bir baglanti kullanilir ve her cagridan sonra kapatilip dispose edilir.
	/// </summary>
	public class SqlDbExecutor : IDbExecutor
	{
		private SqlConnection con;

		public SqlDbExecutor(string connectionString)
		{
			con = new SqlConnection(connectionString);
		}

		public void Fill(string procedureName, IDictionary<string, object> parameters, DataTable target)
		{
			try
			{
				con.Open();
				SqlCommand cmd = CreateCommand(procedureName, parameters);
				SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);
				DataAdapter.Fill(target);
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		public int ExecuteNonQuery(string procedureName, IDictionary<string, object> parameters)
		{
			try
			{
				con.Open();
				SqlCommand cmd = CreateCommand(procedureName, parameters);
				return cmd.ExecuteNonQuery();
			}
			finally
			{
				con.Close();
				con.Dispose();
			}
		}

		private SqlCommand CreateCommand(string procedureName, IDictionary<string, object> parameters)
		{
			SqlCommand cmd = new SqlCommand(procedureName, con);
			cmd.CommandType = CommandType.StoredProcedure;
			if (parameters != null)
			{
				foreach (KeyValuePair<string, object> parameter in parameters)
				{
					cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
				}
			}
			return cmd;
		}
	}
}
