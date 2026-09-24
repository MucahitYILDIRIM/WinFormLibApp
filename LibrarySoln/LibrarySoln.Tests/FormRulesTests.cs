using System;
using System.Collections;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibrarySoln.Tests
{
	[TestClass]
	public class FormRulesTests
	{
		// ---------- AreAllFilled (Signup) ----------

		[TestMethod]
		public void AreAllFilled_AllValuesPresent_ReturnsTrue()
		{
			Assert.IsTrue(FormRules.AreAllFilled("Ali", "Veli", "aliveli", "1234"));
		}

		[TestMethod]
		public void AreAllFilled_AnyEmpty_ReturnsFalse()
		{
			Assert.IsFalse(FormRules.AreAllFilled("", "Veli", "aliveli", "1234"));
			Assert.IsFalse(FormRules.AreAllFilled("Ali", "Veli", "aliveli", ""));
		}

		[TestMethod]
		public void AreAllFilled_AnyNull_ReturnsFalse()
		{
			Assert.IsFalse(FormRules.AreAllFilled("Ali", null, "aliveli", "1234"));
		}

		[TestMethod]
		public void AreAllFilled_WhitespaceIsConsideredFilled()
		{
			// Mevcut davranis String.IsNullOrEmpty ile kontrol ediyor, bosluk gecerli sayilir.
			Assert.IsTrue(FormRules.AreAllFilled(" ", "Veli"));
		}

		[TestMethod]
		public void AreAllFilled_NoValues_ReturnsTrue()
		{
			Assert.IsTrue(FormRules.AreAllFilled());
		}

		// ---------- JoinCategories (UserScreen) ----------

		[TestMethod]
		public void JoinCategories_Empty_ReturnsEmptyString()
		{
			Assert.AreEqual("", FormRules.JoinCategories(new ArrayList()));
		}

		[TestMethod]
		public void JoinCategories_SingleItem_ReturnsItemWithoutSeparator()
		{
			Assert.AreEqual("Roman", FormRules.JoinCategories(new ArrayList { "Roman" }));
		}

		[TestMethod]
		public void JoinCategories_MultipleItems_JoinsWithSemicolon()
		{
			Assert.AreEqual("Roman;Tarih;Bilim", FormRules.JoinCategories(new ArrayList { "Roman", "Tarih", "Bilim" }));
		}

		[TestMethod]
		public void JoinCategories_NonStringItems_UsesToString()
		{
			Assert.AreEqual("1;2", FormRules.JoinCategories(new ArrayList { 1, 2 }));
		}

		[TestMethod]
		public void JoinCategories_NullItem_BecomesEmptySegment()
		{
			Assert.AreEqual("Roman;", FormRules.JoinCategories(new ArrayList { "Roman", null }));
		}

		// ---------- GetLoggedInUserName (Login) ----------

		private static DataTable LoginResultTable()
		{
			// PRC_LOGIN: SELECT * FROM Person INNER JOIN Member -> Person sutunlari + Member sutunlari.
			DataTable table = new DataTable();
			table.Columns.Add("personId", typeof(int));
			table.Columns.Add("Name", typeof(string));
			table.Columns.Add("Surname", typeof(string));
			table.Columns.Add("isMember", typeof(byte));
			table.Columns.Add("isWriter", typeof(byte));
			table.Columns.Add("personId1", typeof(int));
			table.Columns.Add("userName", typeof(string));
			table.Columns.Add("password", typeof(string));
			table.Columns.Add("bookNumber", typeof(int));
			return table;
		}

		[TestMethod]
		public void GetLoggedInUserName_MatchingUser_ReturnsUserNameColumn()
		{
			DataTable table = LoginResultTable();
			table.Rows.Add(1, "Ali", "Veli", (byte)1, (byte)0, 1, "aliveli", "1234", 0);

			Assert.AreEqual("aliveli", FormRules.GetLoggedInUserName(table));
		}

		[TestMethod]
		public void GetLoggedInUserName_MultipleRows_UsesFirstRow()
		{
			DataTable table = LoginResultTable();
			table.Rows.Add(1, "Ali", "Veli", (byte)1, (byte)0, 1, "aliveli", "1234", 0);
			table.Rows.Add(2, "Ayse", "Fatma", (byte)1, (byte)0, 2, "aysefatma", "1234", 0);

			Assert.AreEqual("aliveli", FormRules.GetLoggedInUserName(table));
		}

		[TestMethod]
		public void GetLoggedInUserName_NoRows_ReturnsNull()
		{
			Assert.IsNull(FormRules.GetLoggedInUserName(LoginResultTable()));
		}

		[TestMethod]
		public void GetLoggedInUserName_TooFewColumns_Throws()
		{
			// Sabit indeks kullanildigi icin beklenmeyen sema hata verir (mevcut davranis).
			DataTable table = new DataTable();
			table.Columns.Add("userName", typeof(string));
			table.Rows.Add("aliveli");

			Assert.ThrowsException<IndexOutOfRangeException>(() => FormRules.GetLoggedInUserName(table));
		}

		// ---------- GetResponseDate (UserScreen kiralama) ----------

		[TestMethod]
		public void HirePeriodDays_IsSevenDays()
		{
			Assert.AreEqual(7, FormRules.HirePeriodDays);
		}

		[TestMethod]
		public void GetResponseDate_AddsHirePeriod()
		{
			Assert.AreEqual(new DateTime(2020, 1, 8), FormRules.GetResponseDate(new DateTime(2020, 1, 1)));
		}

		[TestMethod]
		public void GetResponseDate_CrossesMonthAndYearBoundaries()
		{
			Assert.AreEqual(new DateTime(2020, 3, 4), FormRules.GetResponseDate(new DateTime(2020, 2, 26)));
			Assert.AreEqual(new DateTime(2021, 1, 3), FormRules.GetResponseDate(new DateTime(2020, 12, 27)));
		}

		[TestMethod]
		public void GetResponseDate_PreservesTimeOfDay()
		{
			DateTime hireDate = new DateTime(2020, 5, 10, 14, 30, 0);

			Assert.AreEqual(new DateTime(2020, 5, 17, 14, 30, 0), FormRules.GetResponseDate(hireDate));
		}
	}
}
