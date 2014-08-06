#region

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BloquinhosWin.Classes;
using BloquinhosWin.Properties;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using PysiLib;

#endregion

namespace BloquinhosWin
{
    internal sealed partial class FrmPrincipal
    {
        private readonly Audio _computer = new Audio();
        //private readonly Color[] _cores = new Color[5];
        private readonly FrmRecordes _frmRecordes = new FrmRecordes();
        private readonly ListBox _lstNomes = new ListBox();
        private readonly ListBox _lstPontos = new ListBox();
        private int _limiteTempo = 4000;
        private int _nivel = 1;
        private int _pontos;
        private int _proximaVida = 10000;
        private int _restantes = 64;
        private int _vidas = 3;
        private readonly Bitmap[] _imagens = new[] { Resources.AMBER, Resources.CLOUDS, Resources.CRIMSON, Resources.GREEN };

        internal FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            pbTempo.Value += 100;
            pbTempo.Maximum = _limiteTempo;
            AtualizaPainel();

            if (pbTempo.Value != _limiteTempo) return;
            pbTempo.Value = 0;

            foreach (Control controle in Controls)
                if ((controle) is PictureBox)
                    EscolheCor(controle);
        }

        private readonly Random _randomCor = new Random();

        private void EscolheCor(Control controle)
        {
            int numero = _randomCor.Next(4);

            if (controle.BackgroundImage == null && controle.BackColor == Color.Black) return;
            if (controle.BackgroundImage == _imagens[numero])
            {
                EscolheCor(controle);
                return;
            }
            controle.BackgroundImage = _imagens[numero];

            if (controle is Label)
                FalarCor(numero);
        }

        private void Confere(Control objeto)
        {
            if (Timer1.Enabled != true) return;
            if (objeto.BackgroundImage == null)
                return;

            if (objeto.BackgroundImage == picEscolhido.BackgroundImage)
            {
                objeto.BackgroundImage = null;
                objeto.BackColor = Color.Black;
                _pontos += (50 * _nivel);
                _restantes -= 1;
                if (!chkSom.Checked) _computer.Play(".\\sons\\acerto.wav");
            }
            else
            {
                _pontos -= (80 * _nivel);
                if (_pontos < 0) _pontos = 0;
                _vidas -= 1;
                AtualizaVidas();
                if (!chkSom.Checked) _computer.Play(".\\sons\\erro.wav", AudioPlayMode.WaitToComplete);
            }

            if (_pontos > _proximaVida)
            {
                _proximaVida += Convert.ToInt32((_pontos * 0.15) + 10000);
                _vidas += 1;
                AtualizaVidas();
                if (!chkSom.Checked) _computer.Play(".\\sons\\vida.wav", AudioPlayMode.WaitToComplete);
            }

            if (_restantes == 0)
            {
                _limiteTempo -= _limiteTempo > 2000 ? 300 : (_limiteTempo > 1000 ? 200 : 100);

                if (_limiteTempo < 300)
                    _limiteTempo = 300;

                pbTempo.Value = 0;

                _restantes = 64;

                foreach (Control controle in Controls)
                    if (controle is PictureBox)
                        controle.BackColor = Color.White;

                EscolheCor(picEscolhido);
                _nivel += 1;
            }

            AtualizaPainel();

            switch (_vidas)
            {
                case 0:
                    int posicao = 0;
                    {
                        Timer1.Enabled = false;
                        if (!chkSom.Checked) _computer.Play(".\\sons\\perder.wav", AudioPlayMode.WaitToComplete);
                        btnPausar.Enabled = false;

                        if (_pontos > Convert.ToInt32(_lstPontos.Items[9].ToString()))
                            posicao = 10;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[8].ToString()))
                            posicao = 9;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[7].ToString()))
                            posicao = 8;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[6].ToString()))
                            posicao = 7;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[5].ToString()))
                            posicao = 6;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[4].ToString()))
                            posicao = 5;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[3].ToString()))
                            posicao = 4;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[2].ToString()))
                            posicao = 3;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[1].ToString()))
                            posicao = 2;
                        if (_pontos > Convert.ToInt32(_lstPontos.Items[0].ToString()))
                            posicao = 1;

                        if (posicao != 0)
                        {
                            if (!chkSom.Checked) _computer.Play(".\\sons\\nome.wav", AudioPlayMode.WaitToComplete);
                            FrmNome frmNome = new FrmNome();
                            frmNome.ShowDialog();

                            string vencedor = Publico.Nome;

                            posicao -= 1;
                            _lstPontos.Items.Remove(9);
                            _lstNomes.Items.Remove(9);
                            _lstPontos.Items.Insert(posicao, _pontos);
                            _lstNomes.Items.Insert(posicao, vencedor);

                            CarregaRecordes();
                            SalvarRecordes();
                        }
                    }
                    break;
            }
        }

        private void AtualizaVidas()
        {
            lstVidas.Items.Clear();
            for (int i = 0; i < _vidas; i++)
                lstVidas.Items.Add(new ListViewItem((i + 1).ToString(), 0));
        }

        private void AtualizaPainel()
        {
            lblNivel.Text = string.Format("{0}: {1}", Translation.Level(), _nivel);
            lblPontos.Text = _pontos.ToString();

            pbProximaVida.Maximum = _proximaVida;
            pbProximaVida.Value = _pontos;
        }

        private void NovoJogo()
        {
            _restantes = 64;
            _limiteTempo = 4000;
            pbTempo.Value = 0;
            pbTempo.Maximum = _limiteTempo;
            _vidas = 3;
            _pontos = 0;
            _nivel = 1;
            _proximaVida = 10000;

            foreach (Control controle in Controls)
                if (controle is PictureBox)
                    controle.BackColor = Color.White;

            AtualizaVidas();

            Timer1.Enabled = true;
            EscolheCor(picEscolhido);

            AtualizaPainel();

            btnPausar.Enabled = true;
        }

        private void FrmPrincipalLoad(object sender, EventArgs e)
        {
            //if (!Publico.Valido) Application.Exit();

            const string arquivo = "Scores.dat";

            int contador;
            if (!(File.Exists(arquivo)))
            {
                StreamWriter gravacao = null;
                try
                {
                    gravacao = new StreamWriter(arquivo);

                    for (contador = 10; contador >= 1; contador--)
                    {
                        gravacao.WriteLine("Player");
                        gravacao.WriteLine((5000 * contador).ToString());
                    }
                }
                catch (Exception ex)
                {
                    Validation.Message(ex.Message);
                }
                finally
                {
                    if (gravacao != null) gravacao.Close();
                }
            }

            StreamReader leitura = null;
            contador = 0;
            try
            {
                leitura = new StreamReader(arquivo);
                string linha = leitura.ReadLine();

                while (linha != null)
                {
                    _lstNomes.Items.Add(linha);
                    linha = leitura.ReadLine();
                    _lstPontos.Items.Add(linha);
                    linha = leitura.ReadLine();
                    contador += 1;
                }
            }
            catch (Exception ex)
            {
                Validation.Message(ex.Message);
                File.Delete(arquivo);
                Application.Exit();
            }
            finally
            {
                if (leitura != null) leitura.Close();
            }

            CarregaRecordes();

            lblNivel.Text = Translation.Level();
            lblPontos.Text = Translation.Score();
            btnNovoJogo.Text = Translation.NewGame();
            btnPausar.Text = Translation.Pause();
            btnRecordes.Text = Translation.HighScores();
            btnFechar.Text = Translation.Close();
            lblTempo.Text = Translation.Time();
            lblNextLife.Text = Translation.NextLife();
            lblItemEscolhido.Text = Translation.ChoosedItem();

        }

        private void BtnPausarClick(object sender, EventArgs e)
        {
            Timer1.Enabled = !Timer1.Enabled;
            btnNovoJogo.Enabled = !btnNovoJogo.Enabled;

            bool congela = false;

            if (btnPausar.Text == Translation.Pause())
                btnPausar.Text = Translation.Continue();
            else
            {
                btnPausar.Text = Translation.Pause();
                congela = true;
            }

            foreach (Control controle in Controls)
                if (controle is PictureBox)
                    controle.Visible = congela;
        }

        private void P1Click1(object sender, EventArgs e)
        {
            Confere((Control)sender);
        }

        private void BtnNovoJogoClick1(object sender, EventArgs e)
        {
            NovoJogo();
        }

        private void BtnRecordesClick(object sender, EventArgs e)
        {
            CarregaRecordes();
        }

        private void CarregaRecordes()
        {
            _frmRecordes.lblNome1.Text = _lstNomes.Items[0].ToString();
            _frmRecordes.lblPontos1.Text = _lstPontos.Items[0].ToString();
            _frmRecordes.lblNome2.Text = _lstNomes.Items[1].ToString();
            _frmRecordes.lblPontos2.Text = _lstPontos.Items[1].ToString();
            _frmRecordes.lblNome3.Text = _lstNomes.Items[2].ToString();
            _frmRecordes.lblPontos3.Text = _lstPontos.Items[2].ToString();
            _frmRecordes.lblNome4.Text = _lstNomes.Items[3].ToString();
            _frmRecordes.lblPontos4.Text = _lstPontos.Items[3].ToString();
            _frmRecordes.lblNome5.Text = _lstNomes.Items[4].ToString();
            _frmRecordes.lblPontos5.Text = _lstPontos.Items[4].ToString();
            _frmRecordes.lblNome6.Text = _lstNomes.Items[5].ToString();
            _frmRecordes.lblPontos6.Text = _lstPontos.Items[5].ToString();
            _frmRecordes.lblNome7.Text = _lstNomes.Items[6].ToString();
            _frmRecordes.lblPontos7.Text = _lstPontos.Items[6].ToString();
            _frmRecordes.lblNome8.Text = _lstNomes.Items[7].ToString();
            _frmRecordes.lblPontos8.Text = _lstPontos.Items[7].ToString();
            _frmRecordes.lblNome9.Text = _lstNomes.Items[8].ToString();
            _frmRecordes.lblPontos9.Text = _lstPontos.Items[8].ToString();
            _frmRecordes.lblNome10.Text = _lstNomes.Items[9].ToString();
            _frmRecordes.lblPontos10.Text = _lstPontos.Items[9].ToString();

            _frmRecordes.ShowDialog();
        }

        private void SalvarRecordes()
        {
            const string arquivo = "Scores.dat";

            if (File.Exists(arquivo))
                File.Delete(arquivo);
            StreamWriter gravacao = null;

            try
            {
                gravacao = new StreamWriter(arquivo);
                int i;
                for (i = 0; i <= 9; i++)
                {
                    gravacao.WriteLine(_lstNomes.Items[i]);
                    gravacao.WriteLine(_lstPontos.Items[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (gravacao != null) gravacao.Close();
            }
        }

        private void BtnFecharClick(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void FalarCor(int numero)
        {
            if (chkSom.Checked) return;
            _computer.Play(".\\sons\\proximacor.wav", AudioPlayMode.WaitToComplete);

            switch (numero)
            {
                case 0:
                    _computer.Play(".\\sons\\vermelho.wav");
                    break;
                case 1:
                    _computer.Play(".\\sons\\azul.wav");
                    break;
                case 2:
                    _computer.Play(".\\sons\\verde.wav");
                    break;
                case 3:
                    _computer.Play(".\\sons\\amarelo.wav");

                    break;
            }
        }

        private void ChkSomCheckedChanged(object sender, EventArgs e)
        {
            chkSom.Image = chkSom.Checked ? Resources.soundoff : Resources.soundon;
        }

        private void BtnLanguageClick(object sender, EventArgs e)
        {
            FrmLanguage f = new FrmLanguage();
            f.ShowDialog();

            Validation.Message(Translation.Restart());
        }

        private void PicEscolhidoClick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
                if (_imagens[i] == picEscolhido.BackgroundImage)
                    FalarCor(i);
        }
    }
}