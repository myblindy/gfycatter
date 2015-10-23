using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gfycatter
{
    public partial class VideoRangeSelector : UserControl
    {
        public VideoRangeSelector()
        {
            InitializeComponent();
        }

        const float ThumbWidth = 5;
        int frameMin = 0, frameMax = 100, rangeValue1 = 0, rangeValue2 = 100, currentValue = 0;
        public int FrameMin
        {
            get
            {
                return frameMin;
            }
            set
            {
                frameMin = value;
                FireRangeUpdated();
            }
        }

        float PositionFromThumb(float thumbval) { return thumbval / (frameMax - frameMin) * Width; }

        private void VideoRangeSelector_Paint(object sender, PaintEventArgs e)
        {
            var thumb1 = PositionFromThumb(rangeValue1);
            var thumb2 = PositionFromThumb(rangeValue2);

            e.Graphics.FillRectangles(Enabled ? Brushes.Black : Brushes.Gray, new[] {
                new RectangleF(thumb1 - ThumbWidth / 2, 0, ThumbWidth, Height),
                new RectangleF(thumb2 - ThumbWidth / 2, 0, ThumbWidth, Height) });
            e.Graphics.FillRectangle(Brushes.GreenYellow, PositionFromThumb(CurrentValue) - ThumbWidth / 2, 0, ThumbWidth, Height);
        }

        int Dragging = -1, DraggingStartValue;
        private void VideoRangeSelector_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Enabled)
            {
                Cursor = Cursors.Arrow;
                return;
            }

            if (Dragging >= 0)
            {
                var frameval = (float)e.X / Width * (frameMax - FrameMin);
                if (Dragging == 0)
                {
                    if (frameval > RangeValue2)
                    {
                        Dragging = 1;
                        RangeValue2 = (int)frameval;
                    }
                    else
                        RangeValue1 = (int)frameval;
                }
                else
                {
                    if (frameval < RangeValue1)
                    {
                        Dragging = 0;
                        RangeValue1 = (int)frameval;
                    }
                    else
                        RangeValue2 = (int)frameval;
                }
                Cursor = Cursors.Hand;
            }
            else if (Math.Abs(PositionFromThumb(rangeValue1) - e.X) <= ThumbWidth || Math.Abs(PositionFromThumb(rangeValue2) - e.X) <= ThumbWidth)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Arrow;
        }

        private void VideoRangeSelector_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Dragging >= 0)
            {
                Capture = false;
                Dragging = -1;
            }
        }

        private void VideoRangeSelector_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Enabled)
                if (Math.Abs(PositionFromThumb(rangeValue1) - e.X) <= ThumbWidth)
                {
                    Dragging = 0;
                    DraggingStartValue = RangeValue1;
                    Capture = true;
                }
                else if (Math.Abs(PositionFromThumb(rangeValue2) - e.X) <= ThumbWidth)
                {
                    Dragging = 1;
                    DraggingStartValue = RangeValue2;
                    Capture = true;
                }
        }

        public int FrameMax
        {
            get
            {
                return frameMax;
            }
            set
            {
                frameMax = value;
                FireRangeUpdated();
            }
        }

        public int RangeValue1
        {
            get
            {
                return rangeValue1;
            }
            set
            {
                rangeValue1 = value;
                FireRangeUpdated();
            }
        }
        public int RangeValue2
        {
            get
            {
                return rangeValue2;
            }
            set
            {
                rangeValue2 = value;
                FireRangeUpdated();
            }
        }
        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                FireRangeUpdated();
            }
        }

        public event EventHandler RangeUpdated;
        private void FireRangeUpdated()
        {
            Invalidate();
            RangeUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
