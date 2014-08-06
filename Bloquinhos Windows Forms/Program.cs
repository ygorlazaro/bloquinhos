#region

using System;
using System.IO;
using System.Windows.Forms;
using BloquinhosWin.Classes;
using PysiLib;

#endregion

namespace BloquinhosWin
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Translation.Load();


            //if (!File.Exists(@"pysikey.pysi"))
            //{
            //    FrmSerial f = new FrmSerial();
            //    f.ShowDialog();
            //}
            //else
            //{
            //    string conteudo = File.ReadAllText(@"pysikey.pysi");
            //    string pre = conteudo.Substring(0, 36);
            //    string pos = conteudo.Substring(36, 36);

            //    if (!Publico.Validar(pre, pos))
            //    {
            //        Validation.Message(Translation.InvalidKey());
            //        FrmSerial f = new FrmSerial();
            //        f.ShowDialog();
            //    }
            //    else
            //        Publico.Valido = true;
            //}

            Application.Run(new FrmPrincipal());
        }
    }
}