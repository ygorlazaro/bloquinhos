using System;
using System.IO;
using System.Windows.Forms;
using BloquinhosWin.Classes;
using PysiLib;

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

            _precodigo = ticks + Validacao.Inverso(ticks);
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
                File.WriteAllText(arquivo, Validacao.SomenteNumeros(_precodigo, false) + Validacao.SomenteNumeros(txtPos.Text, false));
                Validacao.Mensagem(Translation.Registered());
                Publico.Valido = true;
                Hide();
            }
            else
                Validacao.Mensagem(Translation.InvalidKey());
        }

        private void BtnFecharClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
