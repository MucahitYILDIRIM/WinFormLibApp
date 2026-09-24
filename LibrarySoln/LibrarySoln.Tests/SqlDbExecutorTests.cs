using System;
using LibraryDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibrarySoln.Tests
{
	// SqlDbExecutor'in Fill/ExecuteNonQuery metotlari gercek bir SQL Server baglantisi
	// gerektirdigi icin unit test kapsami disinda birakildi (bkz. CHANGES.md). Burada
	// sadece hicbir baglanti acmayan, salt sozdizimsel dogrulamalar test ediliyor:
	// SqlConnection constructor'i / ConnectionString setter'i gecersiz anahtar kelimeleri
	// aga baglanmadan, senkron olarak reddeder.
	[TestClass]
	public class SqlDbExecutorTests
	{
		[TestMethod]
		public void Constructor_UnsupportedKeyword_ThrowsArgumentException()
		{
			Assert.ThrowsException<ArgumentException>(() => new SqlDbExecutor("NotARealKeyword=foo"));
		}

		[TestMethod]
		public void Constructor_MalformedConnectionString_ThrowsArgumentException()
		{
			// Kapatilmamis tirnak isareti: sozdizimi hatasi, aga baglanmadan firlatilir.
			Assert.ThrowsException<ArgumentException>(() => new SqlDbExecutor("Data Source=.;Password='unterminated"));
		}

		[TestMethod]
		public void Constructor_ValidConnectionString_DoesNotThrow()
		{
			SqlDbExecutor executor = new SqlDbExecutor("Data Source=.;Initial Catalog=Test;Integrated Security=True");

			Assert.IsInstanceOfType(executor, typeof(IDbExecutor));
		}

		[TestMethod]
		public void Constructor_NullConnectionString_DoesNotThrow()
		{
			// SqlConnection(string) null'i bos baglanti dizesi gibi ele alir; hemen firlatmaz.
			SqlDbExecutor executor = new SqlDbExecutor(null);

			Assert.IsNotNull(executor);
		}
	}
}
