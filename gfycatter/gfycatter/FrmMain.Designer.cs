namespace gfycatter
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdVideoFile = new System.Windows.Forms.OpenFileDialog();
            this.wmpMain = new AxWMPLib.AxWindowsMediaPlayer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.selVideoRange = new gfycatter.VideoRangeSelector();
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVideoFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openVideoFileToolStripMenuItem
            // 
            this.openVideoFileToolStripMenuItem.Name = "openVideoFileToolStripMenuItem";
            this.openVideoFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openVideoFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openVideoFileToolStripMenuItem.Text = "Open video file...";
            this.openVideoFileToolStripMenuItem.Click += new System.EventHandler(this.openVideoFileToolStripMenuItem_Click);
            // 
            // ofdVideoFile
            // 
            this.ofdVideoFile.FileName = "Video Files (*.avi;*.wmv;*.flv)|*.avi;*.wmv;*.flv";
            // 
            // wmpMain
            // 
            this.wmpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wmpMain.Enabled = true;
            this.wmpMain.Location = new System.Drawing.Point(12, 27);
            this.wmpMain.Name = "wmpMain";
            this.wmpMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpMain.OcxState")));
            this.wmpMain.Size = new System.Drawing.Size(345, 263);
            this.wmpMain.TabIndex = 1;
            this.wmpMain.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.wmpMain_PlayStateChange);
            this.wmpMain.MediaChange += new AxWMPLib._WMPOCXEvents_MediaChangeEventHandler(this.wmpMain_MediaChange);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // lblLength
            // 
            this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(246, 328);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 3;
            this.lblLength.Text = "Length:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFrom.Location = new System.Drawing.Point(51, 325);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(77, 20);
            this.txtFrom.TabIndex = 4;
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTo.Location = new System.Drawing.Point(163, 325);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(77, 20);
            this.txtTo.TabIndex = 4;
            // 
            // selVideoRange
            // 
            this.selVideoRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selVideoRange.CurrentValue = 0;
            this.selVideoRange.FrameMax = 100;
            this.selVideoRange.FrameMin = 0;
            this.selVideoRange.Location = new System.Drawing.Point(12, 296);
            this.selVideoRange.Name = "selVideoRange";
            this.selVideoRange.RangeValue1 = 0;
            this.selVideoRange.RangeValue2 = 100;
            this.selVideoRange.Size = new System.Drawing.Size(345, 23);
            this.selVideoRange.TabIndex = 2;
            this.selVideoRange.RangeUpdated += new System.EventHandler(this.selVideoRange_RangeUpdated);
            // 
            // tmrUI
            // 
            this.tmrUI.Enabled = true;
            this.tmrUI.Tick += new System.EventHandler(this.tmrUI_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 357);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selVideoRange);
            this.Controls.Add(this.wmpMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Gfycatter";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdVideoFile;
        private AxWMPLib.AxWindowsMediaPlayer wmpMain;
        private VideoRangeSelector selVideoRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Timer tmrUI;
    }
}

