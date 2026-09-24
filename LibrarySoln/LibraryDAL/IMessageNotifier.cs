using System.Windows.Forms;

namespace LibraryDAL
{
	/// <summary>
	/// Kullaniciya mesaj gosterme soyutlamasi. Testlerde MessageBox acilmamasi icin cikarildi.
	/// </summary>
	public interface IMessageNotifier
	{
		void Show(string message);
	}

	public class MessageBoxNotifier : IMessageNotifier
	{
		public void Show(string message)
		{
			MessageBox.Show(message);
		}
	}
}
