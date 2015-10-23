using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;

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
            // read data from this file
            var mediafile = new MediaFile(filepath);

            using (var engine = new Engine())
                engine.GetMetadata(mediafile);

            selVideoRange.RangeValue2 = selVideoRange.FrameMax = (int)(mediafile.Metadata.VideoData.Fps * mediafile.Metadata.Duration.TotalSeconds);
            selVideoRange.RangeValue1 = 0;
            VideoFilePath = filepath;

            // and load it in the player
            wmpMain.URL = filepath;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            wmpMain.uiMode = "none";
            wmpMain.windowlessVideo = true;
            wmpMain.enableContextMenu = false;
        }

        bool DontReposition = false;
        private void selVideoRange_RangeUpdated(object sender, EventArgs e)
        {
            const string format = "hh\\:mm\\:ss\\.ff";
            if (VideoFilePath != null && VideoDuration.TotalSeconds != 0)
            {
                double range = selVideoRange.FrameMax - selVideoRange.FrameMin;

                txtFrom.Text = TimeSpan.FromSeconds(selVideoRange.RangeValue1 / range * VideoDuration.TotalSeconds).ToString(format);
                txtTo.Text = TimeSpan.FromSeconds(selVideoRange.RangeValue2 / range * VideoDuration.TotalSeconds).ToString(format);
                lblLength.Text = "Length: " + TimeSpan.FromSeconds((selVideoRange.RangeValue1 - selVideoRange.RangeValue2) / range * VideoDuration.TotalSeconds).ToString(format);

                // reforce the movie range
                if (!DontReposition)
                {
                    var pos = wmpMain.Ctlcontrols.currentPosition = (double)selVideoRange.RangeValue1 / (selVideoRange.FrameMax - selVideoRange.FrameMin) * VideoDuration.TotalSeconds;
                    Debug.WriteLine("Repositioning to " + pos);
                }
            }
        }

        private void wmpMain_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            var media = (WMPLib.IWMPMedia3)e.item;
            VideoDuration = TimeSpan.FromSeconds(media.duration);
            VideoSize = new Size(media.imageSourceWidth, media.imageSourceHeight);

            DontReposition = true;
            selVideoRange_RangeUpdated(null, EventArgs.Empty);
            DontReposition = false;
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
