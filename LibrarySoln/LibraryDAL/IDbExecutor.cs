using System.Collections.Generic;
using System.Data;

namespace LibraryDAL
{
	/// <summary>
	/// Stored procedure calistirma soyutlamasi. DAL'in veritabanina dogrudan
	/// bagimli olmadan test edilebilmesi icin cikarildi.
	/// </summary>
	public interface IDbExecutor
	{
		/// <summary>Stored procedure sonucunu verilen DataTable'a doldurur.</summary>
		void Fill(string procedureName, IDictionary<string, object> parameters, DataTable target);

		/// <summary>Stored procedure'u calistirir ve etkilenen satir sayisini dondurur.</summary>
		int ExecuteNonQuery(string procedureName, IDictionary<string, object> parameters);
	}
}
