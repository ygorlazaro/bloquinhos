using BloquinhosWin.Classes;
using PysiLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace BloquinhosWin
{
	public sealed partial class FrmSerial : Form
	{
		public FrmSerial()
		{
			InitializeComponent();
		}

		private string _precodigo;

		private void FrmSerial_Load(object sender, EventArgs e)
		{
			string ticks = DateTime.Now.Ticks.ToString();

			_precodigo = ticks + Validation.Inverse(ticks);
			txtPre.Text = _precodigo;

			label1.Text = Translation.IntroRegister();
			btnValidate.Text = Translation.Validate();
			btnFechar.Text = Translation.Close();
		}

		private void BtnValidateClick(object sender, EventArgs e)
		{
			if (Publico.Validar(_precodigo, txtPos.Text))
			{
				const string arquivo = @"pysikey.pysi";
				File.WriteAllText(arquivo, Validation.OnlyNumber(_precodigo, false) + Validation.OnlyNumber(txtPos.Text, false));
				Validation.Message(Translation.Registered());
				Publico.Valido = true;
				Hide();
			}
			else
				Validation.Message(Translation.InvalidKey());
		}

		private void BtnFecharClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
