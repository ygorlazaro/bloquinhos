#region

using BloquinhosWin.Classes;
using System;

#endregion

namespace BloquinhosWin
{
	internal sealed partial class FrmRecordes
	{
		internal FrmRecordes()
		{
			InitializeComponent();
		}

		private void BtnFecharClick(object sender, EventArgs e)
		{
			Close();
		}

		private void FrmRecordes_Load(object sender, EventArgs e)
		{
			lblRecordes.Text = Translation.HighScores();
			btnFechar.Text = Translation.Close();
		}
	}
}