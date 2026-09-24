using System;
using System.Collections.Generic;
using System.Data;
using LibraryDAL;
using LibrarySoln.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibrarySoln.Tests
{
	[TestClass]
	public class DALTests
	{
		private FakeDbExecutor db;
		private FakeMessageNotifier notifier;
		private DAL dal;

		[TestInitialize]
		public void Setup()
		{
			db = new FakeDbExecutor();
			notifier = new FakeMessageNotifier();
			dal = new DAL(db, notifier);
		}

		private static DataTable SingleColumnTable(string column, params object[] values)
		{
			DataTable table = new DataTable();
			table.Columns.Add(column, typeof(string));
			foreach (object value in values)
				table.Rows.Add(value);
			return table;
		}

		private void AssertSingleCall(string method, string procedureName, int parameterCount)
		{
			Assert.AreEqual(1, db.Calls.Count, "Tek bir DB cagrisi bekleniyordu.");
			Assert.AreEqual(method, db.LastCall.Method);
			Assert.AreEqual(procedureName, db.LastCall.ProcedureName);
			Assert.AreEqual(parameterCount, db.LastCall.Parameters.Count);
		}

		private object Param(string name)
		{
			Assert.IsTrue(db.LastCall.Parameters.ContainsKey(name), "Parametre bulunamadi: " + name);
			return db.LastCall.Parameters[name];
		}

		// ---------- Constructor ----------

		[TestMethod]
		public void Constructor_NullExecutor_Throws()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DAL(null, notifier));
		}

		[TestMethod]
		public void Constructor_NullNotifier_Throws()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DAL(db, null));
		}

		[TestMethod]
		public void DefaultConstructor_WiresUpSqlExecutorAndMessageBoxNotifier_DoesNotThrow()
		{
			// Baglanti gercekten acilmadigi surece (Fill/ExecuteNonQuery cagrilmadigi surece)
			// SqlConnection kurulumu hata vermez; test projesinde "ConnectionString" App.config
			// anahtari olmadigindan ConfigurationManager null dondurur, bu da SqlConnection(null)
			// icin gecerlidir (bos baglanti dizesiyle esdeger).
			DAL defaultDal = new DAL();

			Assert.IsNotNull(defaultDal);
		}

		// ---------- PRC_LOGIN ----------

		[TestMethod]
		public void PRC_LOGIN_PassesCredentialsAndReturnsRows()
		{
			db.RowsToReturn = SingleColumnTable("userName", "admin");

			DataTable result = dal.PRC_LOGIN("admin", "secret");

			AssertSingleCall("Fill", "PRC_LOGIN", 2);
			Assert.AreEqual("admin", Param("@P_userName"));
			Assert.AreEqual("secret", Param("@P_password"));
			Assert.AreEqual(1, result.Rows.Count);
			Assert.AreEqual("admin", result.Rows[0]["userName"]);
		}

		[TestMethod]
		public void PRC_LOGIN_NoMatchingUser_ReturnsEmptyTable()
		{
			DataTable result = dal.PRC_LOGIN("admin", "wrong");

			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Rows.Count);
		}

		[TestMethod]
		public void PRC_LOGIN_DbError_ReturnsEmptyTableWithoutNotification()
		{
			db.ExceptionToThrow = new InvalidOperationException("db down");

			DataTable result = dal.PRC_LOGIN("admin", "admin");

			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.Rows.Count);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		// ---------- Parametresiz okuma prosedurleri ----------

		private void AssertParameterlessQuery(Func<DAL, DataTable> query, string procedureName)
		{
			db.RowsToReturn = SingleColumnTable("name", "a", "b");

			DataTable result = query(dal);

			AssertSingleCall("Fill", procedureName, 0);
			Assert.AreEqual(2, result.Rows.Count);
			Assert.AreEqual("a", result.Rows[0]["name"]);
			Assert.AreEqual("b", result.Rows[1]["name"]);
		}

		[TestMethod]
		public void PRC_GET_BOOKS_CallsProcedureAndReturnsRows()
		{
			AssertParameterlessQuery(d => d.PRC_GET_BOOKS(), "PRC_GET_BOOKS");
		}

		[TestMethod]
		public void PRC_GET_BOOK_TYPES_CallsProcedureAndReturnsRows()
		{
			AssertParameterlessQuery(d => d.PRC_GET_BOOK_TYPES(), "PRC_GET_BOOK_TYPES");
		}

		[TestMethod]
		public void PRC_GET_BOOK_CATEGORIES_CallsProcedureAndReturnsRows()
		{
			AssertParameterlessQuery(d => d.PRC_GET_BOOK_CATEGORIES(), "PRC_GET_BOOK_CATEGORIES");
		}

		[TestMethod]
		public void PRC_GET_PRINTERY_CallsProcedureAndReturnsRows()
		{
			AssertParameterlessQuery(d => d.PRC_GET_PRINTERY(), "PRC_GET_PRINTERY");
		}

		[TestMethod]
		public void PRC_GET_CITY_CallsProcedureAndReturnsRows()
		{
			AssertParameterlessQuery(d => d.PRC_GET_CITY(), "PRC_GET_CITY");
		}

		[TestMethod]
		public void ReadProcedures_DbError_ReturnEmptyTable()
		{
			List<Func<DAL, DataTable>> queries = new List<Func<DAL, DataTable>>
			{
				d => d.PRC_GET_BOOKS(),
				d => d.PRC_GET_BOOK_TYPES(),
				d => d.PRC_GET_BOOK_CATEGORIES(),
				d => d.PRC_GET_PRINTERY(),
				d => d.PRC_GET_CITY(),
				d => d.PRC_GET_TOWN("Istanbul"),
				d => d.PRC_GET_HIRED_BOOK("admin")
			};
			db.ExceptionToThrow = new InvalidOperationException("db down");

			foreach (Func<DAL, DataTable> query in queries)
			{
				DataTable result = query(dal);

				Assert.IsNotNull(result);
				Assert.AreEqual(0, result.Rows.Count);
			}
			Assert.AreEqual(queries.Count, db.Calls.Count);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		[TestMethod]
		public void ReadProcedure_ErrorAfterPartialFill_ReturnsRowsLoadedSoFar()
		{
			// Eski SqlDataAdapter.Fill davranisi: hata oncesi doldurulan satirlar korunur.
			db.RowsToReturn = SingleColumnTable("name", "a");
			db.ExceptionToThrow = new InvalidOperationException("connection lost");

			DataTable result = dal.PRC_GET_BOOKS();

			Assert.AreEqual(1, result.Rows.Count);
		}

		// ---------- PRC_GET_TOWN / PRC_GET_HIRED_BOOK ----------

		[TestMethod]
		public void PRC_GET_TOWN_PassesCityName()
		{
			db.RowsToReturn = SingleColumnTable("townName", "Kadikoy", "Besiktas");

			DataTable result = dal.PRC_GET_TOWN("Istanbul");

			AssertSingleCall("Fill", "PRC_GET_TOWN", 1);
			Assert.AreEqual("Istanbul", Param("@P_cityName"));
			Assert.AreEqual(2, result.Rows.Count);
		}

		[TestMethod]
		public void PRC_GET_HIRED_BOOK_PassesUserName()
		{
			db.RowsToReturn = SingleColumnTable("bookName", "Suc ve Ceza");

			DataTable result = dal.PRC_GET_HIRED_BOOK("admin");

			AssertSingleCall("Fill", "PRC_GET_HIRED_BOOK", 1);
			Assert.AreEqual("admin", Param("@P_UserName"));
			Assert.AreEqual(1, result.Rows.Count);
		}

		// ---------- PRC_DML_MEMBER ----------

		[TestMethod]
		public void PRC_DML_MEMBER_PassesAllParametersAndReturnsAffectedRows()
		{
			db.NonQueryResult = 1;

			int result = dal.PRC_DML_MEMBER("I", "Ali", "Veli", "aliveli", "1234");

			AssertSingleCall("ExecuteNonQuery", "PRC_DML_MEMBER", 5);
			Assert.AreEqual("I", Param("@P_dmlType"));
			Assert.AreEqual("Ali", Param("@P_name"));
			Assert.AreEqual("Veli", Param("@P_surname"));
			Assert.AreEqual("aliveli", Param("@P_userName"));
			Assert.AreEqual("1234", Param("@P_password"));
			Assert.AreEqual(1, result);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		[TestMethod]
		public void PRC_DML_MEMBER_NoRowsAffected_ReturnsZero()
		{
			db.NonQueryResult = 0;

			Assert.AreEqual(0, dal.PRC_DML_MEMBER("I", "Ali", "Veli", "aliveli", "1234"));
		}

		[TestMethod]
		public void PRC_DML_MEMBER_DbError_ReturnsMinusOneAndShowsMessage()
		{
			db.ExceptionToThrow = new InvalidOperationException("Kullanici adi mevcut");

			int result = dal.PRC_DML_MEMBER("I", "Ali", "Veli", "aliveli", "1234");

			Assert.AreEqual(-1, result);
			CollectionAssert.AreEqual(new[] { "Kullanici adi mevcut" }, notifier.Messages);
		}

		// ---------- PRC_DML_BOOK ----------

		[TestMethod]
		public void PRC_DML_BOOK_ConvertsDateAndPassesAllParameters()
		{
			DateTime printeryDate = new DateTime(2019, 3, 15);
			db.NonQueryResult = 1;

			int result = dal.PRC_DML_BOOK("I", "Nutuk", printeryDate.ToShortDateString(), "Mustafa Kemal", "Ataturk",
				"Yapi Kredi", "Tarih;Biyografi", "Ciltli", 25);

			AssertSingleCall("ExecuteNonQuery", "PRC_DML_BOOK", 9);
			Assert.AreEqual("I", Param("@P_dmlType"));
			Assert.AreEqual("Nutuk", Param("@P_bookName"));
			Assert.AreEqual(printeryDate, Param("@P_printeryDate"));
			Assert.IsInstanceOfType(Param("@P_printeryDate"), typeof(DateTime));
			Assert.AreEqual("Mustafa Kemal", Param("@P_writerName"));
			Assert.AreEqual("Ataturk", Param("@P_writerSurname"));
			Assert.AreEqual("Yapi Kredi", Param("@P_printery"));
			Assert.AreEqual("Tarih;Biyografi", Param("@P_category"));
			Assert.AreEqual("Ciltli", Param("@P_typeName"));
			Assert.AreEqual(25, Param("@P_hirePrice"));
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void PRC_DML_BOOK_InvalidDate_ReturnsMinusOneWithoutCallingDbOrNotifying()
		{
			int result = dal.PRC_DML_BOOK("I", "Nutuk", "not-a-date", "a", "b", "c", "d", "e", 10);

			Assert.AreEqual(-1, result);
			Assert.AreEqual(0, db.Calls.Count);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		[TestMethod]
		public void PRC_DML_BOOK_NullDate_IsSentAsDateTimeMinValue()
		{
			// Convert.ToDateTime(null) hata vermez, DateTime.MinValue dondurur (mevcut davranis).
			dal.PRC_DML_BOOK("I", "Nutuk", null, "a", "b", "c", "d", "e", 10);

			Assert.AreEqual(DateTime.MinValue, Param("@P_printeryDate"));
		}

		[TestMethod]
		public void PRC_DML_BOOK_DbError_ReturnsMinusOneWithoutNotifying()
		{
			db.ExceptionToThrow = new InvalidOperationException("db down");

			int result = dal.PRC_DML_BOOK("I", "Nutuk", new DateTime(2019, 3, 15).ToShortDateString(), "a", "b", "c", "d", "e", 10);

			Assert.AreEqual(-1, result);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		// ---------- PRC_DML_PRINTERY ----------

		[TestMethod]
		public void PRC_DML_PRINTERY_PassesAllParametersAndReturnsAffectedRows()
		{
			db.NonQueryResult = 1;

			int result = dal.PRC_DML_PRINTERY("Can Yayinlari", "Kadikoy", "Istanbul", "Moda Cad. No:1");

			AssertSingleCall("ExecuteNonQuery", "PRC_DML_PRINTERY", 4);
			Assert.AreEqual("Can Yayinlari", Param("@P_PrinteryName"));
			Assert.AreEqual("Kadikoy", Param("@P_TownName"));
			Assert.AreEqual("Istanbul", Param("@P_CityName"));
			Assert.AreEqual("Moda Cad. No:1", Param("@P_Adress"));
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void PRC_DML_PRINTERY_DbError_ReturnsMinusOneWithoutNotifying()
		{
			db.ExceptionToThrow = new InvalidOperationException("db down");

			int result = dal.PRC_DML_PRINTERY("Can Yayinlari", "Kadikoy", "Istanbul", "Moda Cad. No:1");

			Assert.AreEqual(-1, result);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		// ---------- PRC_DML_HIRE ----------

		[TestMethod]
		public void PRC_DML_HIRE_ConvertsDateAndPassesAllParameters()
		{
			DateTime responseTime = new DateTime(2020, 1, 22);
			db.NonQueryResult = 1;

			int result = dal.PRC_DML_HIRE("I", 42, "admin", responseTime.ToShortDateString(), 0, 15, 0);

			AssertSingleCall("ExecuteNonQuery", "PRC_DML_HIRE", 7);
			Assert.AreEqual("I", Param("@P_dmlType"));
			Assert.AreEqual(42, Param("@P_bookId"));
			Assert.AreEqual("admin", Param("@P_userName"));
			Assert.AreEqual(responseTime, Param("@P_responseTime"));
			Assert.AreEqual(0, Param("@P_isBack"));
			Assert.AreEqual(15, Param("@P_price"));
			Assert.AreEqual(0, Param("@P_hireId"));
			Assert.AreEqual(1, result);
			Assert.AreEqual(0, notifier.Messages.Count);
		}

		[TestMethod]
		public void PRC_DML_HIRE_ReturnBook_PassesHireId()
		{
			// UserProfile.btnBack_Click'teki iade cagrisi.
			db.NonQueryResult = 1;

			dal.PRC_DML_HIRE("U", 0, "", new DateTime(2020, 1, 22).ToShortDateString(), 0, 0, 7);

			Assert.AreEqual("U", Param("@P_dmlType"));
			Assert.AreEqual(7, Param("@P_hireId"));
		}

		[TestMethod]
		public void PRC_DML_HIRE_InvalidDate_ReturnsMinusOneAndShowsMessageWithoutCallingDb()
		{
			int result = dal.PRC_DML_HIRE("I", 42, "admin", "not-a-date", 0, 15, 0);

			Assert.AreEqual(-1, result);
			Assert.AreEqual(0, db.Calls.Count);
			Assert.AreEqual(1, notifier.Messages.Count);
		}

		[TestMethod]
		public void PRC_DML_HIRE_DbError_ReturnsMinusOneAndShowsMessage()
		{
			db.ExceptionToThrow = new InvalidOperationException("Kitap zaten kirada");

			int result = dal.PRC_DML_HIRE("I", 42, "admin", new DateTime(2020, 1, 22).ToShortDateString(), 0, 15, 0);

			Assert.AreEqual(-1, result);
			CollectionAssert.AreEqual(new[] { "Kitap zaten kirada" }, notifier.Messages);
		}
	}
}
