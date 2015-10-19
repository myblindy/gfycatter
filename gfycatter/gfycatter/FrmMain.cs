using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gfycatter
{
    public partial class FrmMain : Form
    {
        string VideoFilePath;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void openVideoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdVideoFile.ShowDialog() == DialogResult.OK)
                OpenVideoFile(ofdVideoFile.FileName);
        }

        private void OpenVideoFile(string filepath)
        {
            VideoFilePath = filepath;
            wmpMain.URL = filepath;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            wmpMain.uiMode = "none";
            wmpMain.windowlessVideo = true;
            wmpMain.enableContextMenu = false;
        }
    }
}
