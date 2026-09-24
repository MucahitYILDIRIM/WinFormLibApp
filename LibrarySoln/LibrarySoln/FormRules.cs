using System;
using System.Collections;
using System.Data;

namespace LibrarySoln
{
	/// <summary>
	/// Formlarin icindeki, UI'dan bagimsiz kurallar. Test edilebilmeleri icin formlardan cikarildi.
	/// </summary>
	public static class FormRules
	{
		/// <summary>Kiralanan kitabin iade suresi (gun).</summary>
		public const int HirePeriodDays = 7;

		/// <summary>Verilen alanlarin hicbiri null/bos degilse true doner.</summary>
		public static bool AreAllFilled(params string[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (String.IsNullOrEmpty(values[i]))
					return false;
			}
			return true;
		}

		/// <summary>Secili kategorileri ";" ile birlestirir (PRC_DML_BOOK @P_category formati).</summary>
		public static string JoinCategories(IList items)
		{
			string categories = "";
			for (int i = 0; i < items.Count; i++)
			{
				if (i == 0)
					categories += items[i];
				else
					categories += ";" + items[i];
			}
			return categories;
		}

		/// <summary>
		/// PRC_LOGIN sonucundaki userName sutununun indeksi
		/// (Person: 0-4, Member.personId: 5, Member.userName: 6).
		/// </summary>
		public const int LoginUserNameColumnIndex = 6;

		/// <summary>PRC_LOGIN sonucundan giris yapan kullanici adini dondurur; satir yoksa null.</summary>
		public static string GetLoggedInUserName(DataTable userInformation)
		{
			if (userInformation.Rows.Count != 0)
				return userInformation.Rows[0].ItemArray[LoginUserNameColumnIndex].ToString();
			return null;
		}

		/// <summary>Kiralama tarihinden iade tarihini hesaplar.</summary>
		public static DateTime GetResponseDate(DateTime hireDate)
		{
			return hireDate.AddDays(HirePeriodDays);
		}
	}
}
