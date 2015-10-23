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
        TimeSpan VideoDuration;
        Size VideoSize;
        bool VideoPlaying;

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

        private void selVideoRange_RangeUpdated(object sender, EventArgs e)
        {
            const string format = "hh\\:mm\\:ss\\.ff";
            if (VideoFilePath != null && VideoDuration.TotalSeconds != 0)
            {
                double range = selVideoRange.FrameMax - selVideoRange.FrameMin;

                txtFrom.Text = TimeSpan.FromSeconds(selVideoRange.RangeValue1 / range * VideoDuration.TotalSeconds).ToString(format);
                txtTo.Text = TimeSpan.FromSeconds(selVideoRange.RangeValue2 / range * VideoDuration.TotalSeconds).ToString(format);
                lblLength.Text = "Length: " + TimeSpan.FromSeconds((selVideoRange.RangeValue1 - selVideoRange.RangeValue2) / range * VideoDuration.TotalSeconds).ToString(format);
            }
        }

        private void wmpMain_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            var media = (WMPLib.IWMPMedia3)e.item;
            VideoDuration = TimeSpan.FromSeconds(media.duration);
            VideoSize = new Size(media.imageSourceWidth, media.imageSourceHeight);

            selVideoRange_RangeUpdated(null, EventArgs.Empty);
        }

        private void wmpMain_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
        }

        private void wmpMain_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            VideoPlaying = e.newState == 3/*playing*/;
        }

        private void tmrUI_Tick(object sender, EventArgs e)
        {
            if (VideoPlaying)
            {
                var frameposition = wmpMain.Ctlcontrols.currentPosition / VideoDuration.TotalSeconds * (selVideoRange.FrameMax - selVideoRange.FrameMin);
                selVideoRange.CurrentValue = (int)frameposition;
            }
        }
    }
}
