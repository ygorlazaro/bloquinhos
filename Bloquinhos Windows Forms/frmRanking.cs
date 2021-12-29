using BloquinhosWin.Entities;
using BloquinhosWin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Media;
using System.IO;

namespace BloquinhosWin
{

    internal partial class FrmRanking
    {
        public FrmRanking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRanking_Load(object sender, EventArgs e)
        {
            var ranking = RankPosition.ReadRanking().Select(rank => rank.ToString());

            foreach (var item in ranking)
            {
                listBox1.Items.Add(item);
            }

        }
    }
}