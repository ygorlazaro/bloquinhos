using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using BloquinhosSL.Classes;

namespace BloquinhosSL
{
    internal sealed partial class MainPage
    {
        internal MainPage()
        {
            InitializeComponent();
        }

        private DispatcherTimer _timer;
        Random _r = new Random();

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            Variaveis.Degrade[0] = new LinearGradientBrush();
            Variaveis.Degrade[0].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 59, 0, 0)));
            Variaveis.Degrade[0].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 255, 39, 39)));

            Variaveis.Degrade[1] = new LinearGradientBrush();
            Variaveis.Degrade[1].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 5, 0, 106)));
            Variaveis.Degrade[1].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 44, 131, 234)));

            Variaveis.Degrade[2] = new LinearGradientBrush();
            Variaveis.Degrade[2].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 0, 53, 45)));
            Variaveis.Degrade[2].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 1, 255, 13)));

            Variaveis.Degrade[3] = new LinearGradientBrush();
            Variaveis.Degrade[3].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 126, 126, 126)));
            Variaveis.Degrade[3].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 241, 254, 4)));

            Variaveis.Degrade[4] = new LinearGradientBrush();
            Variaveis.Degrade[4].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 0, 35, 45)));
            Variaveis.Degrade[4].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 193, 24, 134)));

            Variaveis.Degrade[5] = new LinearGradientBrush();
            Variaveis.Degrade[5].GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 0, 126, 144)));
            Variaveis.Degrade[5].GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 27, 203, 228)));

            Variaveis.Corclicado = new LinearGradientBrush();
            Variaveis.Corclicado.GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 69, 69, 69)));
            Variaveis.Corclicado.GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 0, 0, 0)));

            Variaveis.Corinicial = new LinearGradientBrush();
            Variaveis.Corinicial.GradientStops.Add(Visual.NovoGradientStop(0, Color.FromArgb(255, 179, 179, 179)));
            Variaveis.Corinicial.GradientStops.Add(Visual.NovoGradientStop(1, Color.FromArgb(255, 255, 255, 255)));

            _timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            _timer.Tick += RotinaTimer;

            NovoJogo();
        }

        private void RotinaTimer(object sender, EventArgs e)
        {
            pbTempo.Value += 100;
            pbTempo.Maximum = Variaveis.LimiteTempo;
            AtualizaPainel();

            if (pbTempo.Value != Variaveis.LimiteTempo) return;
            pbTempo.Value = 0;

            foreach (Rectangle controle in LayoutRoot.Children.OfType<Rectangle>())
                EscolheCor(controle);

       }

        private void EscolheCor(Shape controle)
        {
            int numero = _r.Next(0, 6);

            if (controle.Name == "recFundo")
                return;

            if (controle.Fill == Variaveis.Corclicado) return;

            if (controle.Fill.Equals(Variaveis.Degrade[numero]))
            {
                EscolheCor(controle);
                return;
            }
            controle.Fill = Variaveis.Degrade[numero];
        }

        private void Confere(Shape retangulo)
        {
            if (!_timer.IsEnabled)
                return;

            if (retangulo.Name == "recFundo")
                return;

            if (retangulo.Fill == Variaveis.Corclicado)
                return;

            if (retangulo.Fill.Equals(recFundo.Fill))
            {
                retangulo.Fill = Variaveis.Corclicado;
                Variaveis.Pontos += (50 * Variaveis.Nivel);
                Variaveis.Restantes -= 1;
                PlayAudio(@"sons/acerto.wma");
            }
            else
            {
                Variaveis.Pontos -= (80 * Variaveis.Nivel);
                Variaveis.Vidas -= 1;
                AtualizaVidas();
                PlayAudio(@"sons/erro.wma");
            }

            if (Variaveis.Pontos > Variaveis.ProximaVida)
            {
                Variaveis.ProximaVida += Convert.ToInt64((Variaveis.Pontos * 0.25) + 10000);
                Variaveis.Vidas += 1;
                AtualizaVidas();
                pbProximaVida.Maximum = Variaveis.ProximaVida;
                PlayAudio(@"sons/vida.wma");
            }

            if (Variaveis.Restantes == 0)
            {
                if (Variaveis.LimiteTempo > 3000)
                    Variaveis.LimiteTempo -= 300;
                else Variaveis.LimiteTempo -= Variaveis.LimiteTempo > 1000 ? 200 : 100;

                if (Variaveis.LimiteTempo < 300)
                    Variaveis.LimiteTempo = 300;

                pbTempo.Value = 0;

                Variaveis.Restantes = 64;

                foreach (Rectangle controle in LayoutRoot.Children.OfType<Rectangle>())
                    controle.Fill = Variaveis.Corinicial;

                _r = new Random();
                int numero = _r.Next(0, 6);
                recFundo.Fill = Variaveis.Degrade[numero];

                Variaveis.Nivel += 1;

                PlayAudio(@"sons/proximacor.wma");
                _nomeCor = true;
            }

            AtualizaPainel();

            if (Variaveis.Vidas != 0) return;
            _timer.Stop();
            PlayAudio(@"sons/perder.wma");
            MessageBox.Show("Você perdeu!");
        }

        private void AtualizaPainel()
        {
            lblNivel.Text = "Nível: " + Variaveis.Nivel;
            lblVidas.Text = "Vidas:" + Variaveis.Vidas;
            lblPontosFase.Text = string.Format("Restantes: {0} ({1} bloco{2})", (50 * Variaveis.Nivel * Variaveis.Restantes), Variaveis.Restantes, Variaveis.Restantes > 1 ? "s" : "");

            pbProximaVida.Maximum = Variaveis.ProximaVida;
            pbProximaVida.Value = Variaveis.Pontos;
        }

        private void NovoJogo()
        {
            Variaveis.Restantes = 64;
            Variaveis.LimiteTempo = 5000;
            pbTempo.Value = 0;
            pbTempo.Maximum = Variaveis.LimiteTempo;
            Variaveis.Vidas = 3;
            Variaveis.Pontos = 0;
            Variaveis.Nivel = 1;
            Variaveis.ProximaVida = 10000;

            foreach (Rectangle controle in LayoutRoot.Children.OfType<Rectangle>())
                controle.Fill = Variaveis.Corinicial;

            _timer.Start();
            _r = new Random();
            int numero = _r.Next(0, 6);
            recFundo.Fill = Variaveis.Degrade[numero];
            AtualizaPainel();
            AtualizaVidas();
            PlayAudio(@"sons/proximacor.wma");
            _nomeCor = true;
        }

        private void AtualizaVidas()
        {
            int contador = 0;

            foreach (Ellipse e in LayoutRoot.Children.OfType<Ellipse>().Where(e => e.Name.StartsWith("elipVidas")))
                e.Visibility = Visibility.Collapsed;

            foreach (Ellipse e in LayoutRoot.Children.OfType<Ellipse>().Where(e => e.Name.StartsWith("elipVidas")))
            {
                contador += 1;
                if (contador <= Variaveis.Vidas)
                    e.Visibility = Visibility.Visible;
            }
        }

        private void P1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Confere((Rectangle)sender);
        }

        private void BtnNovoJogoClick(object sender, RoutedEventArgs e)
        {
            NovoJogo();
        }

        #region "Sons"

        private void PlayAudio(string arquivo)
        {
            AudioUri = new Uri(arquivo, UriKind.RelativeOrAbsolute);
        }

        Uri _audioUri;
        private Uri AudioUri
        {
            set
            {
                if (value != _audioUri)
                {
                    _audioUri = value;
                    mediaelem.Source = _audioUri;
                }
                //else
                {
                    mediaelem.Volume = 1;
                    mediaelem.Position = TimeSpan.FromSeconds(0);
                    mediaelem.Play();
                }
            }
        }

        private bool _nomeCor;
        #endregion

        private void MediaelemMediaEnded(object sender, RoutedEventArgs e)
        {
            if (!_nomeCor) return;
            _nomeCor = false;
            PlayAudio(@"sons/amarelo.wma");
        }


    }
}
