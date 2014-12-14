using PysiLib;
using System;

namespace BloquinhosWin.Classes
{
	internal static class Publico
	{
		internal static string Nome;
		internal static bool Valido;

		public static string GerarPosCodigo(string precodigo)
		{
			precodigo = Validation.OnlyNumber(precodigo, false);

			string resultado = null;

			for (var i = 0; i < 18; i += 2)
				resultado += Math.Abs(Converte.SeeInt(precodigo.Substring(0, 18).Substring(i, 2)) - Converte.SeeInt(precodigo.Substring(18, 18).Substring(16 - i, 2))).ToString("00");

			resultado += Validation.Inverse(resultado);

			return resultado;
		}

		internal static bool Validar(string precodigo, string poscodigo)
		{
			string resultado = null;

			precodigo = Validation.OnlyNumber(precodigo, false);
			poscodigo = Validation.OnlyNumber(poscodigo, false);

			var esqpre = precodigo.Substring(0, 18);
			var dirpre = precodigo.Substring(18, 18);

			for (var i = 0; i < 18; i += 2)
				resultado += Math.Abs(Converte.SeeInt(esqpre.Substring(i, 2)) - Converte.SeeInt(dirpre.Substring(16 - i, 2))).ToString("00");

			resultado += Validation.Inverse(resultado);

			return resultado == poscodigo;
		}
	}
}