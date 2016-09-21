using BloquinhosWin.Entities;
using BloquinhosWin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace BloquinhosWin
{
    internal partial class FrmPrincipal
    {
        public Configuracoes Config { get; set; } = new Configuracoes();

        public List<Bitmap> CoresDisponiveis = new List<Bitmap>() {
            Resources.AMBER,
            Resources.CLOUDS,
            Resources.CRIMSON,
            Resources.GREEN
        };

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            pbTempo.Value += 100;
            pbTempo.Maximum = Config.LimiteTempo;

            AtualizaPainel();

            if (pbTempo.Value == Config.LimiteTempo)
            {
                pbTempo.Value = 0;

                foreach (Control controle in Controls)
                {
                    if (controle is PictureBox)
                    {
                        EmbaralhaCor(controle);
                    }
                }
            }
        }

        public Random Aleatorio = new Random(DateTime.Now.Millisecond);

        private void EmbaralhaCor(Control bloco)
        {
            var indiceCor = Aleatorio.Next(4);
            var corEscolhida = CoresDisponiveis[indiceCor];

            if (bloco.BackgroundImage == null && bloco.BackColor == Color.Black) return;

            if (bloco.BackgroundImage == corEscolhida)
            {
                EmbaralhaCor(bloco);
            }
            else
            {
                bloco.BackgroundImage = corEscolhida;
            }
        }

        private void BlocoClicado(Control bloco)
        {
            if (Timer1.Enabled && bloco.BackgroundImage != null)
            {
                if (bloco.BackgroundImage == picEscolhido.BackgroundImage)
                {
                    bloco.BackgroundImage = null;
                    bloco.BackColor = Color.Black;

                    Config.CliqueCerto();
                }
                else
                {
                    Config.CliqueErrado();
                }

                AtualizaVidas();

                if (Config.IsProximoNivel())
                {
                    pbTempo.Value = 0;

                    foreach (Control controle in Controls)
                        if (controle is PictureBox)
                            controle.BackColor = Color.White;

                    EmbaralhaCor(picEscolhido);
                }

                AtualizaPainel();

                if (Config.Vidas == 0)
                {
                    Timer1.Enabled = false;
                    btnPausar.Enabled = false;

                    MessageBox.Show("Fim de jogo");
                }
            }
        }

        private void AtualizaVidas()
        {
            lstVidas.Items.Clear();

            var vidas = Enumerable.Range(1, Config.Vidas)
                        .Select(index => new ListViewItem(index.ToString()))
                        .ToArray();

            lstVidas.Items.AddRange(vidas);
        }

        private void AtualizaPainel()
        {
            lblNivel.Text = $"Nível {Config.Nivel}";
            lblPontos.Text = Config.Pontos.ToString();

            pbProximaVida.Maximum = Config.ProximaVida;
            pbProximaVida.Value = Config.Pontos;
        }

        private void NovoJogo()
        {
            Config = new Configuracoes();

            pbTempo.Value = 0;
            pbTempo.Maximum = Config.LimiteTempo;

            foreach (Control controle in Controls)
                if (controle is PictureBox)
                    controle.BackColor = Color.White;

            AtualizaVidas();

            Timer1.Enabled = true;
            EmbaralhaCor(picEscolhido);

            AtualizaPainel();

            btnPausar.Enabled = true;
        }

        private void BtnPausarClick(object sender, EventArgs e)
        {
            Timer1.Enabled = !Timer1.Enabled;
            btnNovoJogo.Enabled = !btnNovoJogo.Enabled;

            foreach (Control controle in Controls)
                if (controle is PictureBox)
                    controle.Visible = Timer1.Enabled;
        }

        private void P1Click1(object sender, EventArgs e)
        {
            BlocoClicado((Control)sender);
        }

        private void BtnNovoJogoClick1(object sender, EventArgs e)
        {
            NovoJogo();
        }

        private void BtnFecharClick(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}