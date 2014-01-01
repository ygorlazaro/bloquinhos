#region

using System;
using BloquinhosWin.Classes;

#endregion

namespace BloquinhosWin
{
    internal sealed partial class FrmNome
    {
        internal FrmNome()
        {
            InitializeComponent();
        }

        private void BtnAceitarClick(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty) return;
            Publico.Nome = txtNome.Text.Trim();
            Close();
        }

        private void FrmNomeLoad(object sender, EventArgs e)
        {
            lblName.Text = Translation.EnterName();
            btnAceitar.Text = Translation.Accept();

            txtNome.Focus();
        }
    }
}