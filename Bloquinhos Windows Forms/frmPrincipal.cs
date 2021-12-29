using BloquinhosWin.Entities;
using BloquinhosWin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Media;
using System.Diagnostics;

namespace BloquinhosWin
{

    internal partial class FrmPrincipal
    {
        public Configuracoes Config { get; set; } = new Configuracoes();

        public List<ResourceColor> CoresDisponiveis = new List<ResourceColor>() {
            new ResourceColor(Resources.AMBER, "Yellow"),
            new ResourceColor(Resources.CLOUDS, "Blue"),
            new ResourceColor(Resources.CRIMSON, "Red"),
            new ResourceColor(Resources.GREEN, "Green")
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

        private string EmbaralhaCor(Control bloco)
        {
            var indiceCor = Aleatorio.Next(4);
            var corEscolhida = CoresDisponiveis[indiceCor];
            var somCor = GetSoundColor(corEscolhida.Name);

            if (bloco.BackgroundImage == null && bloco.BackColor == Color.Black) return "";

            if (bloco.BackgroundImage == corEscolhida.Resource)
            {
                return EmbaralhaCor(bloco);
            }
            else
            {
                bloco.BackgroundImage = corEscolhida.Resource;
            }

            return somCor;
        }

        private string GetSoundColor(string corEscolhida)
        {
            return $"./sounds/{corEscolhida.ToLower()}.wav";
        }

        private void BlocoClicado(Control bloco)
        {
            if (Timer1.Enabled && bloco.BackgroundImage != null)
            {
                if (bloco.BackgroundImage == picEscolhido.BackgroundImage)
                {
                    PlaySound("./sounds/bip.wav", false);
                    bloco.BackgroundImage = null;
                    bloco.BackColor = Color.Black;

                    var nextLife = Config.CliqueCerto();

                    if (nextLife)
                    {
                        PlaySound("./sounds/ta_da.wav", false);
                    }
                }
                else
                {
                    Config.CliqueErrado();
                    PlaySound("./sounds/oh_no.wav", false);
                }

                AtualizaVidas();

                if (Config.IsProximoNivel())
                {
                    pbTempo.Value = 0;

                    foreach (Control controle in Controls)
                        if (controle is PictureBox)
                            controle.BackColor = Color.White;

                    PlaySound("./sounds/proxima_cor.wav");
                    var somCor = EmbaralhaCor(picEscolhido);
                    PlaySound(somCor);
                }

                AtualizaPainel();

                if (Config.Vidas == 0)
                {
                    Timer1.Enabled = false;
                    btnPausar.Enabled = false;

                    PlaySound("./sounds/fim_jogo.wav");

                    ValidateRanking();
                }
            }
        }

        private void ValidateRanking()
        {
            var ranking = RankPosition.ReadRanking();

            if (ranking.Count < 10 || ranking.Last().Points < Config.Pontos)
            {
                var name = ShowDialog("Qual o seu nome?", "Parabéns");
                var pontuation = new RankPosition(name, Config.Pontos);

                pontuation.Save();
                RankPosition.DeleteMinor();

                var frmRanking = new FrmRanking();
                frmRanking.ShowDialog();
            }
        }

        private static string ShowDialog(string text, string caption)
        {
            var prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label() { Left = 50, Top = 20, Text = text };
            var textBox = new TextBox() { Left = 50, Top = 50, Width = 400, MaxLength = 6 };
            var confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void AtualizaVidas()
        {
            lstVidas.Items.Clear();

            var vidas = Enumerable.Range(1, Config.Vidas)
                        .Select(index => new ListViewItem(index.ToString(), 0))
                        .ToArray();

            lstVidas.Items.AddRange(vidas);
        }

        private void AtualizaPainel()
        {
            lblNivel.Text = $"Nível {Config.Nivel}";
            lblPontos.Text = Config.Pontos.ToString();

            pbProximaVida.Maximum = Config.ProximaVida;
            pbProximaVida.Value = Config.Pontos;
            label2.Text = $"{Config.Pontos}/{Config.ProximaVida}";
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
            PlaySound("./sounds/choosed_color.wav");
            var somCor = EmbaralhaCor(picEscolhido);
            PlaySound(somCor);

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

        private void PlaySound(string sound, bool isWaiting = true)
        {
            Debug.WriteLine(sound);
            using (var soundPlayer = new SoundPlayer(sound))
            {
                if (isWaiting)
                {
                    soundPlayer.PlaySync();
                }
                else
                {
                    soundPlayer.Play();
                }
            }
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            if (Timer1.Enabled)
            {
                BtnPausarClick(sender, e);
            }

            var ranking = new FrmRanking();
            ranking.ShowDialog();
        }
    }
}