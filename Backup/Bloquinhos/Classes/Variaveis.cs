using System.Windows.Media;

namespace BloquinhosSL.Classes
{
    internal static class Variaveis
    {
        public static readonly LinearGradientBrush[] Degrade = new LinearGradientBrush[6];
        public static int LimiteTempo = 5000;
        public static int Restantes = 64;
        public static long Pontos;
        public static int Nivel = 1;
        public static int Vidas = 3;
        public static long ProximaVida = 10000;
        
        public static LinearGradientBrush Corclicado = new LinearGradientBrush();
        public static LinearGradientBrush Corinicial = new LinearGradientBrush();
    }
}
