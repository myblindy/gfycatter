namespace gfycatter
{
    partial class VideoRangeSelector
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VideoRangeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "VideoRangeSelector";
            this.Size = new System.Drawing.Size(291, 23);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoRangeSelector_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoRangeSelector_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoRangeSelector_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoRangeSelector_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
