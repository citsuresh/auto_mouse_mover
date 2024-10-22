namespace AutoMouseMover
{
    partial class AutoMouseMoverForm
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
            components = new System.ComponentModel.Container();
            ScreenSaverEnabledCheckBox = new System.Windows.Forms.CheckBox();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoMouseMoverForm));
            StartButton = new System.Windows.Forms.Button();
            MovingTimeLabel = new System.Windows.Forms.Label();
            MovingPixelLabel = new System.Windows.Forms.Label();
            MovingPixelBox = new System.Windows.Forms.NumericUpDown();
            MovingPeriodBox = new System.Windows.Forms.NumericUpDown();
            MovingTimeSecondLabel = new System.Windows.Forms.Label();
            StatusStrip = new System.Windows.Forms.StatusStrip();
            StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            CursorTimer = new System.Windows.Forms.Timer(components);
            TrayBarIcon = new System.Windows.Forms.NotifyIcon(components);
            TrayBarContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            TrayBarMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            TrayBarMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            TrayBarMenuStop = new System.Windows.Forms.ToolStripMenuItem();
            TrayBarMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            StopButton = new System.Windows.Forms.Button();
            MenuStrip = new System.Windows.Forms.MenuStrip();
            StripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            IdleScreensaverTimer = new System.Windows.Forms.Timer(components);
            ScreenSaverIdleTimeBox = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ScreenSaverOpacityBox = new System.Windows.Forms.NumericUpDown();
            PreviewButton = new System.Windows.Forms.Button();
            ScreenSaverEnabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)MovingPixelBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MovingPeriodBox).BeginInit();
            StatusStrip.SuspendLayout();
            TrayBarContextMenu.SuspendLayout();
            MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScreenSaverIdleTimeBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScreenSaverOpacityBox).BeginInit();
            SuspendLayout();
            // 
            // ScreenSaverEnabledCheckBox
            // 
            ScreenSaverEnabledCheckBox.AutoSize = true;
            ScreenSaverEnabledCheckBox.Checked = true;
            ScreenSaverEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            ScreenSaverEnabledCheckBox.Location = new System.Drawing.Point(26, 161);
            ScreenSaverEnabledCheckBox.Name = "ScreenSaverEnabledCheckBox";
            ScreenSaverEnabledCheckBox.Size = new System.Drawing.Size(211, 29);
            ScreenSaverEnabledCheckBox.TabIndex = 20;
            ScreenSaverEnabledCheckBox.Text = "Screen Saver Enabled ";
            ScreenSaverEnabledCheckBox.UseVisualStyleBackColor = true;
            ScreenSaverEnabledCheckBox.CheckedChanged += ScreenSaverEnabledCheckBox_CheckedChanged;
            // 
            // StartButton
            // 
            StartButton.Location = new System.Drawing.Point(24, 300);
            StartButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            StartButton.Name = "StartButton";
            StartButton.Size = new System.Drawing.Size(125, 44);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // MovingTimeLabel
            // 
            MovingTimeLabel.AutoSize = true;
            MovingTimeLabel.Location = new System.Drawing.Point(20, 73);
            MovingTimeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            MovingTimeLabel.Name = "MovingTimeLabel";
            MovingTimeLabel.Size = new System.Drawing.Size(212, 25);
            MovingTimeLabel.TabIndex = 3;
            MovingTimeLabel.Text = "Move when PC is idle for:";
            // 
            // MovingPixelLabel
            // 
            MovingPixelLabel.AutoSize = true;
            MovingPixelLabel.Location = new System.Drawing.Point(20, 123);
            MovingPixelLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            MovingPixelLabel.Name = "MovingPixelLabel";
            MovingPixelLabel.Size = new System.Drawing.Size(275, 25);
            MovingPixelLabel.TabIndex = 4;
            MovingPixelLabel.Text = "Number of pixel to move mouse:";
            // 
            // MovingPixelBox
            // 
            MovingPixelBox.Location = new System.Drawing.Point(294, 119);
            MovingPixelBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MovingPixelBox.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            MovingPixelBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            MovingPixelBox.Name = "MovingPixelBox";
            MovingPixelBox.Size = new System.Drawing.Size(84, 31);
            MovingPixelBox.TabIndex = 5;
            MovingPixelBox.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // MovingPeriodBox
            // 
            MovingPeriodBox.Location = new System.Drawing.Point(294, 69);
            MovingPeriodBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MovingPeriodBox.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            MovingPeriodBox.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            MovingPeriodBox.Name = "MovingPeriodBox";
            MovingPeriodBox.Size = new System.Drawing.Size(84, 31);
            MovingPeriodBox.TabIndex = 6;
            MovingPeriodBox.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // MovingTimeSecondLabel
            // 
            MovingTimeSecondLabel.AutoSize = true;
            MovingTimeSecondLabel.Location = new System.Drawing.Point(386, 73);
            MovingTimeSecondLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            MovingTimeSecondLabel.Name = "MovingTimeSecondLabel";
            MovingTimeSecondLabel.Size = new System.Drawing.Size(87, 25);
            MovingTimeSecondLabel.TabIndex = 7;
            MovingTimeSecondLabel.Text = "second(s)";
            // 
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StatusLabel });
            StatusStrip.Location = new System.Drawing.Point(0, 366);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            StatusStrip.Size = new System.Drawing.Size(491, 32);
            StatusStrip.SizingGrip = false;
            StatusStrip.TabIndex = 8;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(89, 25);
            StatusLabel.Text = "Status: {0}";
            // 
            // CursorTimer
            // 
            CursorTimer.Tick += CursorTimer_Tick;
            // 
            // TrayBarIcon
            // 
            TrayBarIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            TrayBarIcon.BalloonTipText = "Automatic mouse mover is running in background";
            TrayBarIcon.BalloonTipTitle = "Automatic mouse mover";
            TrayBarIcon.ContextMenuStrip = TrayBarContextMenu;
            TrayBarIcon.Icon = (System.Drawing.Icon)resources.GetObject("TrayBarIcon.Icon");
            TrayBarIcon.Text = "Automatic mouse mover running";
            TrayBarIcon.Visible = true;
            TrayBarIcon.MouseDoubleClick += TrayBarIcon_MouseDoubleClick;
            // 
            // TrayBarContextMenu
            // 
            TrayBarContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            TrayBarContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TrayBarMenuOpen, TrayBarMenuStart, TrayBarMenuStop, TrayBarMenuExit });
            TrayBarContextMenu.Name = "TrayBarContextMenu";
            TrayBarContextMenu.Size = new System.Drawing.Size(129, 132);
            // 
            // TrayBarMenuOpen
            // 
            TrayBarMenuOpen.Name = "TrayBarMenuOpen";
            TrayBarMenuOpen.Size = new System.Drawing.Size(128, 32);
            TrayBarMenuOpen.Text = "Open";
            TrayBarMenuOpen.Click += TrayBarMenuOpen_Click;
            // 
            // TrayBarMenuStart
            // 
            TrayBarMenuStart.Name = "TrayBarMenuStart";
            TrayBarMenuStart.Size = new System.Drawing.Size(128, 32);
            TrayBarMenuStart.Text = "Start";
            TrayBarMenuStart.Click += TrayBarMenuStart_Click;
            // 
            // TrayBarMenuStop
            // 
            TrayBarMenuStop.Enabled = false;
            TrayBarMenuStop.Name = "TrayBarMenuStop";
            TrayBarMenuStop.Size = new System.Drawing.Size(128, 32);
            TrayBarMenuStop.Text = "Stop";
            TrayBarMenuStop.Click += TrayBarMenuStop_Click;
            // 
            // TrayBarMenuExit
            // 
            TrayBarMenuExit.Name = "TrayBarMenuExit";
            TrayBarMenuExit.Size = new System.Drawing.Size(128, 32);
            TrayBarMenuExit.Text = "Exit";
            TrayBarMenuExit.Click += TrayBarMenuExit_Click;
            // 
            // StopButton
            // 
            StopButton.Enabled = false;
            StopButton.Location = new System.Drawing.Point(342, 300);
            StopButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            StopButton.Name = "StopButton";
            StopButton.Size = new System.Drawing.Size(125, 44);
            StopButton.TabIndex = 10;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripMenuAbout });
            MenuStrip.Location = new System.Drawing.Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            MenuStrip.Size = new System.Drawing.Size(491, 35);
            MenuStrip.TabIndex = 13;
            // 
            // StripMenuAbout
            // 
            StripMenuAbout.Name = "StripMenuAbout";
            StripMenuAbout.Size = new System.Drawing.Size(78, 29);
            StripMenuAbout.Text = "About";
            StripMenuAbout.Click += StripMenuAbout_Click;
            // 
            // IdleScreensaverTimer
            // 
            IdleScreensaverTimer.Interval = 300;
            IdleScreensaverTimer.Tick += IdleScreensaverTimer_Tick;
            // 
            // ScreenSaverIdleTimeBox
            // 
            ScreenSaverIdleTimeBox.Location = new System.Drawing.Point(296, 201);
            ScreenSaverIdleTimeBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ScreenSaverIdleTimeBox.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            ScreenSaverIdleTimeBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ScreenSaverIdleTimeBox.Name = "ScreenSaverIdleTimeBox";
            ScreenSaverIdleTimeBox.Size = new System.Drawing.Size(84, 31);
            ScreenSaverIdleTimeBox.TabIndex = 15;
            ScreenSaverIdleTimeBox.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(48, 205);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(184, 25);
            label1.TabIndex = 14;
            label1.Text = "ScreenSaver Idle Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(392, 204);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 25);
            label2.TabIndex = 16;
            label2.Text = "second(s)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(48, 252);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(173, 25);
            label3.TabIndex = 17;
            label3.Text = "ScreenSaver Opacity";
            // 
            // ScreenSaverOpacityBox
            // 
            ScreenSaverOpacityBox.Location = new System.Drawing.Point(294, 250);
            ScreenSaverOpacityBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ScreenSaverOpacityBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ScreenSaverOpacityBox.Name = "ScreenSaverOpacityBox";
            ScreenSaverOpacityBox.Size = new System.Drawing.Size(84, 31);
            ScreenSaverOpacityBox.TabIndex = 18;
            ScreenSaverOpacityBox.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // PreviewButton
            // 
            PreviewButton.Location = new System.Drawing.Point(392, 244);
            PreviewButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            PreviewButton.Name = "PreviewButton";
            PreviewButton.Size = new System.Drawing.Size(87, 43);
            PreviewButton.TabIndex = 19;
            PreviewButton.Text = "Preview";
            PreviewButton.UseVisualStyleBackColor = true;
            PreviewButton.Click += PreviewButton_Click;
            // 
            // AutoMouseMoverForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 398);
            Controls.Add(ScreenSaverEnabledCheckBox);
            Controls.Add(PreviewButton);
            Controls.Add(ScreenSaverOpacityBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ScreenSaverIdleTimeBox);
            Controls.Add(label1);
            Controls.Add(StopButton);
            Controls.Add(StatusStrip);
            Controls.Add(MenuStrip);
            Controls.Add(MovingTimeSecondLabel);
            Controls.Add(MovingPeriodBox);
            Controls.Add(MovingPixelBox);
            Controls.Add(MovingPixelLabel);
            Controls.Add(MovingTimeLabel);
            Controls.Add(StartButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "AutoMouseMoverForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Automatic Mouse Mover";
            FormClosing += AutoMouseMoverForm_FormClosing;
            Resize += AutoMouseMoverForm_Resize;
            ((System.ComponentModel.ISupportInitialize)MovingPixelBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MovingPeriodBox).EndInit();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            TrayBarContextMenu.ResumeLayout(false);
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ScreenSaverIdleTimeBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScreenSaverOpacityBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label MovingTimeLabel;
        private System.Windows.Forms.Label MovingPixelLabel;
        private System.Windows.Forms.NumericUpDown MovingPixelBox;
        private System.Windows.Forms.NumericUpDown MovingPeriodBox;
        private System.Windows.Forms.Label MovingTimeSecondLabel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.Timer CursorTimer;
        private System.Windows.Forms.NotifyIcon TrayBarIcon;
        private System.Windows.Forms.ContextMenuStrip TrayBarContextMenu;
        private System.Windows.Forms.ToolStripMenuItem TrayBarMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem TrayBarMenuStart;
        private System.Windows.Forms.ToolStripMenuItem TrayBarMenuStop;
        private System.Windows.Forms.ToolStripMenuItem TrayBarMenuExit;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StripMenuAbout;
        private System.Windows.Forms.Timer IdleScreensaverTimer;
        private System.Windows.Forms.NumericUpDown ScreenSaverIdleTimeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ScreenSaverOpacityBox;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.CheckBox ScreenSaverEnabledCheckBox;
    }
}

