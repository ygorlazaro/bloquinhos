using System.Windows.Media;

namespace BloquinhosSL.Classes
{
    internal static class Visual
    {
        internal static GradientStop NovoGradientStop(int numOffset, Color cor)
        {
            return new GradientStop { Offset = numOffset, Color = cor };
        }
    }
}
