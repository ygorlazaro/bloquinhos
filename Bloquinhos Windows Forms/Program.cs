#region

using BloquinhosWin.Classes;
using System;
using System.Windows.Forms;


#endregion

namespace BloquinhosWin
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Translation.Load();

			Application.Run(new FrmPrincipal());
		}
	}
}