using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace Bloquinhos_Metro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        DispatcherTimer timer = new DispatcherTimer();
        public int _limiteTempo = 6000;
        public int _restantes = 64;
        public int _vidas = 3;
        public int _pontos = 0;
        public int _nivel = 1;
        public int _proximaVida = 10000;
        public Random _randomCor = new Random();

        enum EnumCores
        {
            Vermelho,
            Amarelo,
            Verde,
            Azul,            
            Branco, 
            Preto
        }

        public List<Color> Cores = new List<Color>()
        {
            Color.FromArgb(255,255,0,0),
            Color.FromArgb(255,0,255,255),
            Color.FromArgb(255,0,255,0),
            Color.FromArgb(255,0,0,255),
            Color.FromArgb(255,255,255,255),
            Color.FromArgb(255,0,0,0)

        };

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            timer.Tick += timer_Tick;
            timer.Interval = (new TimeSpan(0, 0, 0, 0, 100));
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            pbTempo.Value += 100;
            pbTempo.Maximum = _limiteTempo;
            AtualizaPainel();

            if (pbTempo.Value < _limiteTempo) return;
            pbTempo.Value = 0;

            int count = VisualTreeHelper.GetChildrenCount(grid1);
            for (int i = 0; i < count; i++)
            {
                FrameworkElement childVisual = (FrameworkElement)VisualTreeHelper.GetChild(grid1, i);
                if (childVisual is Rectangle && childVisual.Name != "picEscolhido" && GetColor((Rectangle)childVisual) != Cores[(int)EnumCores.Preto]) 
                    EscolheCor((Rectangle)childVisual);
            }
        }

        private void P_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Rectangle objeto = (Rectangle)sender;

            if (!timer.IsEnabled) return;
            if (objeto.Fill == null)
                return;

            if (GetColor(objeto) == GetColor(picEscolhido))
            {
                objeto.Fill = null;
                objeto.Fill = new SolidColorBrush(Cores[(int)EnumCores.Preto]);
                _pontos += (50 * _nivel);
                _restantes -= 1;
                //if (!chkSom.Checked) _computer.Play(".\\sons\\acerto.wav");
            }
            else
            {
                _pontos -= (80 * _nivel);
                if (_pontos < 0) _pontos = 0;
                _vidas -= 1;
                AtualizaVidas();
                //if (!chkSom.Checked) _computer.Play(".\\sons\\erro.wav", AudioPlayMode.WaitToComplete);
            }

            if (_pontos > _proximaVida)
            {
                _proximaVida += Convert.ToInt32((_pontos * 0.15) + 10000);
                _vidas += 1;
                AtualizaVidas();
                //if (!chkSom.Checked) _computer.Play(".\\sons\\vida.wav", AudioPlayMode.WaitToComplete);
            }

            if (_restantes == 0)
            {
                _limiteTempo -= _limiteTempo > 2000 ? 300 : (_limiteTempo > 1000 ? 200 : 100);

                if (_limiteTempo < 300)
                    _limiteTempo = 300;

                pbTempo.Value = 0;

                _restantes = 64;

                int count = VisualTreeHelper.GetChildrenCount(grid1);
                for (int i = 0; i < count; i++)
                {
                    FrameworkElement childVisual = (FrameworkElement)VisualTreeHelper.GetChild(grid1, i);
                    if (childVisual is Rectangle && childVisual.Name != "picEscolhido")
                        ((Rectangle)childVisual).Fill = new SolidColorBrush(Cores[(int)EnumCores.Branco]);
                }


                EscolheCor(picEscolhido);
                _nivel += 1;
            }

            AtualizaPainel();

            if (_vidas == 0)
            {
                timer.Stop();
                //if (!chkSom.Checked) _computer.Play(".\\sons\\perder.wav", AudioPlayMode.WaitToComplete);
                //btnPausar.Enabled = false;
            }
        }

        private Color GetColor(Rectangle objeto)
        {
            return ((SolidColorBrush)objeto.Fill).Color;
        }

        private void btnNovo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NovoJogo();
        }

        private void NovoJogo()
        {
            _restantes = 64;
            _limiteTempo = 6000;
            pbTempo.Value = 0;
            pbTempo.Maximum = _limiteTempo;
            _vidas = 3;
            _pontos = 0;
            _nivel = 1;
            _proximaVida = 10000;

            int count = VisualTreeHelper.GetChildrenCount(grid1);
            for (int i = 0; i < count; i++)
            {
                FrameworkElement childVisual = (FrameworkElement)VisualTreeHelper.GetChild(grid1, i);
                if (childVisual is Rectangle && childVisual.Name != "picEscolhido")
                    ((Rectangle)childVisual).Fill = new SolidColorBrush(Cores[(int)EnumCores.Branco]);
            }

            AtualizaVidas();

            timer.Start();
            EscolheCor(picEscolhido);

            AtualizaPainel();

            //btnPausar.Enabled = true;
        }

        private void EscolheCor(Rectangle controle)
        {
            int numero = _randomCor.Next(4);

            var corSelecionada = new SolidColorBrush(Cores[numero]);

            if (controle.Fill == null && GetColor(controle) == Cores[(int)EnumCores.Preto]) return;
            if (controle.Fill == corSelecionada)
            {
                EscolheCor(controle);
                return;
            }
            controle.Fill = corSelecionada;
        }

        public void AtualizaVidas()
        {
            txtVidas.Text = "Vidas: " + _vidas.ToString();
        }

        private void AtualizaPainel()
        {
            lblNivel.Text = string.Format("{0}: {1}", "Nível: ", _nivel);
            lblPontos.Text = _pontos.ToString();

            pbProximaVida.Maximum = _proximaVida;
            pbProximaVida.Value = _pontos;
        }

    }
}
