using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        Vlc.DotNet.Forms.VlcControl vlcVideoPlayer;

        string VideoFilePath;
        TimeSpan VideoDuration;
        Size VideoSize;
        bool VideoPlaying;

        double? RequestRepositiong;

        public FrmMain()
        {
            InitializeComponent();

            // build the VLC control
            vlcVideoPlayer = new Vlc.DotNet.Forms.VlcControl();
            vlcVideoPlayer.BeginInit();
            vlcVideoPlayer.PositionChanged += VlcVideoPlayer_PositionChanged;
            vlcVideoPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "vlc"));
            vlcVideoPlayer.Dock = DockStyle.Fill;
            vlcVideoPlayer.EndInit();
            pnlVideoPlayer.Controls.Add(vlcVideoPlayer);
        }

        private void VlcVideoPlayer_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            var frameposition = e.NewPosition * (selVideoRange.FrameMax - selVideoRange.FrameMin);
            selVideoRange.CurrentValue = (int)frameposition;
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
            VideoDuration = TimeSpan.FromSeconds(mediafile.Metadata.Duration.TotalSeconds);

            // and load it in the player
            vlcVideoPlayer.Play(new FileInfo(filepath));
        }

        private void RepositionToFrame(int framepos, int framemin, int framemax)
        {
            vlcVideoPlayer.Position = (float)framepos / (framemax - framemin);
            Debug.WriteLine("Repositioning requested to frame " + framepos + " in [" + framemin + ", " + framemax + "]");
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
                    RepositionToFrame(selVideoRange.RangeValue1, selVideoRange.FrameMin, selVideoRange.FrameMax);
            }
        }

        private void tmrUI_Tick(object sender, EventArgs e)
        {
            if (VideoPlaying)
            {
                // reposition requested?
                if (RequestRepositiong.HasValue)
                {
                    //wmpMain.Ctlcontrols.currentPosition = RequestRepositiong.Value;
                    RequestRepositiong = null;
                }

            }
        }
    }
}
