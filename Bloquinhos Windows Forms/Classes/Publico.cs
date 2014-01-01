using System;
using PysiLib;

namespace BloquinhosWin.Classes
{
    internal static class Publico
    {
        internal static string Nome;
        internal static bool Valido;

        public static string GerarPosCodigo(string precodigo)
        {
            precodigo = Validacao.SomenteNumeros(precodigo, false);

            string esqpre = precodigo.Substring(0, 18);
            string dirpre = precodigo.Substring(18, 18);

            string resultado = null;

            for (int i = 0; i < 18; i += 2)
            {
                int esq = Converte.SeeInt(esqpre.Substring(i, 2));
                int dir = Converte.SeeInt(dirpre.Substring(16 - i, 2));
                resultado += Math.Abs(esq - dir).ToString("00");
            }

            resultado += Validacao.Inverso(resultado);

            return resultado;
        }

        internal static bool Validar(string precodigo, string poscodigo)
        {
            string resultado = null;

            precodigo = Validacao.SomenteNumeros(precodigo, false);
            poscodigo = Validacao.SomenteNumeros(poscodigo, false);

            string esqpre = precodigo.Substring(0, 18);
            string dirpre = precodigo.Substring(18, 18);

            for (int i = 0; i < 18; i += 2)
            {
                int esq = Converte.SeeInt(esqpre.Substring(i, 2));
                int dir = Converte.SeeInt(dirpre.Substring(16 - i, 2));
                resultado += Math.Abs(esq - dir).ToString("00");
            }

            resultado += Validacao.Inverso(resultado);

            return resultado == poscodigo;
        }
    }
}