using System;

namespace BloquinhosWin.Entities
{
    public class Configuracoes
    {
        public int LimiteTempo { get; set; }

        public int Nivel { get; set; }

        public int Pontos { get; set; }

        public int ProximaVida { get; set; }

        public int BlocosRestantes { get; set; }

        public int Vidas { get; set; }

        public Configuracoes()
        {
            LimiteTempo = 4000;
            Nivel = 1;
            Pontos = 0;
            ProximaVida = 10000;
            BlocosRestantes = 64;
            Vidas = 3;
        }

        internal bool CliqueCerto()
        {
            Pontos += (50 * Nivel);
            BlocosRestantes -= 1;

            return Validacoes();
        }

        internal void CliqueErrado()
        {
            Vidas -= 1;
            Pontos -= (80 * Nivel);

            if (Pontos < 0)
            {
                Pontos = 0;
            }

            Validacoes();
        }

        private bool Validacoes()
        {
            return ValidaVidaBonus();
        }

        public bool IsProximoNivel()
        {
            if (BlocosRestantes == 0)
            {
                LimiteTempo -= LimiteTempo > 2000 ? 300 : 
                    (LimiteTempo > 1000 ? 200 : 100);

                if (LimiteTempo < 300)
                    LimiteTempo = 300;

                BlocosRestantes = 64;
                Nivel += 1;

                return true;
            }

            return false;
        }

        private bool ValidaVidaBonus()
        {
            if (Pontos > ProximaVida)
            {
                ProximaVida += Convert.ToInt32((Pontos * 0.15) + 10000);
                Vidas += 1;

                return true;
            }

            return false;
        }
    }
}
