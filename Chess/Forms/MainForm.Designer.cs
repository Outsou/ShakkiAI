namespace Chess.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomMoveButton = new System.Windows.Forms.ToolStripButton();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.chessBoard = new Chess.Components.ChessBoard();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.maxTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maxDepthUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.TurnTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.toolStripSeparator5,
            this.toolStripSeparator7,
            this.mnuAbout,
            this.randomMoveButton});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(335, 25);
            this.MenuStrip.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuClose});
            this.mnuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(38, 22);
            this.mnuFile.Text = "&File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(132, 22);
            this.mnuNew.Text = "New Game";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(132, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuAbout
            // 
            this.mnuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAboutItem});
            this.mnuAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(53, 22);
            this.mnuAbout.Text = "About";
            // 
            // mnuAboutItem
            // 
            this.mnuAboutItem.Name = "mnuAboutItem";
            this.mnuAboutItem.Size = new System.Drawing.Size(107, 22);
            this.mnuAboutItem.Text = "&About";
            this.mnuAboutItem.Click += new System.EventHandler(this.mnuAboutItem_Click);
            // 
            // randomMoveButton
            // 
            this.randomMoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.randomMoveButton.Image = ((System.Drawing.Image)(resources.GetObject("randomMoveButton.Image")));
            this.randomMoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.randomMoveButton.Name = "randomMoveButton";
            this.randomMoveButton.Size = new System.Drawing.Size(41, 22);
            this.randomMoveButton.Text = "Move";
            this.randomMoveButton.Click += new System.EventHandler(this.randomMoveButton_Click);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.chessBoard);
            this.pnlClient.Controls.Add(this.pnlTop);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 25);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(335, 404);
            this.pnlClient.TabIndex = 2;
            // 
            // chessBoard
            // 
            this.chessBoard.BackColor = System.Drawing.Color.LightGray;
            this.chessBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chessBoard.Location = new System.Drawing.Point(0, 59);
            this.chessBoard.Name = "chessBoard";
            this.chessBoard.Size = new System.Drawing.Size(335, 345);
            this.chessBoard.TabIndex = 2;
            this.chessBoard.TurnChanged += new Chess.Components.ChessBoard.TurnChangedHandler(this.chessBoard_TurnChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.maxTimeUpDown);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.maxDepthUpDown);
            this.pnlTop.Controls.Add(this.lblTurn);
            this.pnlTop.Controls.Add(this.lblWhiteTime);
            this.pnlTop.Controls.Add(this.lblBlackTime);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(335, 59);
            this.pnlTop.TabIndex = 1;
            // 
            // maxTimeUpDown
            // 
            this.maxTimeUpDown.Location = new System.Drawing.Point(263, 26);
            this.maxTimeUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.maxTimeUpDown.Name = "maxTimeUpDown";
            this.maxTimeUpDown.Size = new System.Drawing.Size(60, 20);
            this.maxTimeUpDown.TabIndex = 10;
            this.maxTimeUpDown.ValueChanged += new System.EventHandler(this.maxTimeUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max time (seconds):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Max depth:";
            // 
            // maxDepthUpDown
            // 
            this.maxDepthUpDown.Location = new System.Drawing.Point(66, 26);
            this.maxDepthUpDown.Name = "maxDepthUpDown";
            this.maxDepthUpDown.Size = new System.Drawing.Size(48, 20);
            this.maxDepthUpDown.TabIndex = 7;
            this.maxDepthUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.maxDepthUpDown.ValueChanged += new System.EventHandler(this.maxDepthUpDown_ValueChanged);
            // 
            // lblTurn
            // 
            this.lblTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblTurn.ForeColor = System.Drawing.Color.Black;
            this.lblTurn.Location = new System.Drawing.Point(265, 5);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(67, 13);
            this.lblTurn.TabIndex = 3;
            this.lblTurn.Text = "White\'s Turn";
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Location = new System.Drawing.Point(3, 5);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(83, 13);
            this.lblWhiteTime.TabIndex = 6;
            this.lblWhiteTime.Text = "White: 00:00:00";
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Location = new System.Drawing.Point(88, 5);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(82, 13);
            this.lblBlackTime.TabIndex = 5;
            this.lblBlackTime.Text = "Black: 00:00:00";
            // 
            // TurnTimer
            // 
            this.TurnTimer.Interval = 1000;
            this.TurnTimer.Tick += new System.EventHandler(this.TurnTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 429);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChessBin.com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDepthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuStrip;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.Timer TurnTimer;
        private System.Windows.Forms.ToolStripDropDownButton mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripDropDownButton mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private Chess.Components.ChessBoard chessBoard;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.ToolStripButton randomMoveButton;
        private System.Windows.Forms.NumericUpDown maxTimeUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxDepthUpDown;

        
    }
}