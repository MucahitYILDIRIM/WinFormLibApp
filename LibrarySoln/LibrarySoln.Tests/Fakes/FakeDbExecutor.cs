using System;
using System.Collections.Generic;
using System.Data;
using LibraryDAL;

namespace LibrarySoln.Tests.Fakes
{
	internal class DbCall
	{
		public string Method;
		public string ProcedureName;
		public Dictionary<string, object> Parameters;
	}

	/// <summary>Cagrilari kaydeden, ayarlanabilir sonuc/hata donduren sahte IDbExecutor.</summary>
	internal class FakeDbExecutor : IDbExecutor
	{
		public readonly List<DbCall> Calls = new List<DbCall>();

		/// <summary>Fill cagrisinda hedef tabloya kopyalanacak satirlar.</summary>
		public DataTable RowsToReturn;

		/// <summary>ExecuteNonQuery donus degeri.</summary>
		public int NonQueryResult;

		/// <summary>Ayarlanirsa cagri sirasinda firlatilir (Fill'de satirlar kopyalandiktan sonra).</summary>
		public Exception ExceptionToThrow;

		public DbCall LastCall
		{
			get { return Calls[Calls.Count - 1]; }
		}

		public void Fill(string procedureName, IDictionary<string, object> parameters, DataTable target)
		{
			Record("Fill", procedureName, parameters);

			if (RowsToReturn != null)
				target.Merge(RowsToReturn);

			if (ExceptionToThrow != null)
				throw ExceptionToThrow;
		}

		public int ExecuteNonQuery(string procedureName, IDictionary<string, object> parameters)
		{
			Record("ExecuteNonQuery", procedureName, parameters);

			if (ExceptionToThrow != null)
				throw ExceptionToThrow;

			return NonQueryResult;
		}

		private void Record(string method, string procedureName, IDictionary<string, object> parameters)
		{
			Calls.Add(new DbCall
			{
				Method = method,
				ProcedureName = procedureName,
				Parameters = parameters == null ? null : new Dictionary<string, object>(parameters)
			});
		}
	}

	internal class FakeMessageNotifier : IMessageNotifier
	{
		public readonly List<string> Messages = new List<string>();

		public void Show(string message)
		{
			Messages.Add(message);
		}
	}
}
