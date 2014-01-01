using System;
using System.IO;
using System.Windows.Forms;

namespace BloquinhosWin
{
    public partial class FrmLanguage : Form
    {
        public FrmLanguage()
        {
            InitializeComponent();
        }

        private string _language;

        private void BtnPtClick(object sender, EventArgs e)
        {
            _language = "pt";
            SaveLanguage();
        }

        private void SaveLanguage()
        {
            const string filename = "language.dat";
            if (File.Exists(filename)) File.Delete(filename);
            File.WriteAllText(filename, _language);
            Close();
        }

        private void BtnEnClick(object sender, EventArgs e)
        {
            _language = "en";
            SaveLanguage();
        }
    }
}
