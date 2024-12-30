/*
 * Copyright (c) 2020 Emanuele Bellocchia
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using AutoMouseMover.Form;
using AutoMouseMover.Logic;
using AutoMouseMover.Utils;
using AutoMouseMover.WinWrapper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AutoMouseMover
{
    //
    // Main form
    //
    public partial class AutoMouseMoverForm : System.Windows.Forms.Form
    {
        //
        // Constants
        //
        #region Constants

        // Idle status string
        private const string STATUS_IDLE_STR = "idle";
        // Running status string
        private const string STATUS_RUNNING_STR = "running";
        // Balloon tip timeout
        private const int BALLOON_TIP_TIMEOUT = 500;

        #endregion

        //
        // Members
        //
        #region Members

        // Automatic mouse mover
        private AutomaticMouseMover mAutoMouseMover;
        // Settings
        private SettingsHelper mSettings;

        private bool mApplicationExiting;
        ComponentResourceManager Resources;

        private ScreensaverOverlayForm OverlayForm;
        private DateTime lastInputTime;
        private bool mMouseMovedByApplication;
        private bool isDoubleClick = false;

        #endregion

        //
        // Constructor
        //
        #region Constructor

        // Constructor
        public AutoMouseMoverForm()
        {
            this.Resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoMouseMoverForm));
            InitializeComponent();
            DoubleClickTimer.Interval = SystemInformation.DoubleClickTime;
            // Create classes
            mAutoMouseMover = new AutomaticMouseMover();
            mSettings = new SettingsHelper();
            // Load settings
            LoadSettings();
            // Set status
            SetStatus(STATUS_IDLE_STR);
            MinimizeWindowToTrayBar();
            OverlayForm = new ScreensaverOverlayForm();
            OverlayForm.Hide();
        }

        #endregion

        //
        // GUI events
        //
        #region GUI events

        // Start button
        private void StartButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            // Disable GUI on start
            DisableGuiOnStart();
            // Set status
            SetStatus(STATUS_RUNNING_STR);

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AutoMouseMover.app_icon_green.ico"))
            {
                if (stream != null)
                {
                    TrayBarIcon.Icon = new Icon(stream);
                }
            }

            // Initialize auto mouse mover class
            mAutoMouseMover.Initialize((int)MovingPixelBox.Value);
            // Set timer interval and start it
            CursorTimer.Interval = ((int)MovingPeriodBox.Value) * 1000;
            CursorTimer.Start();

            if (mSettings.ScreenSaverEnabled)
            {
                HookManager.KeyPress -= HookManager_KeyPress;
                HookManager.MouseAction -= HookManager_MouseAction;
                HookManager.KeyPress += HookManager_KeyPress;
                HookManager.MouseAction += HookManager_MouseAction;
                lastInputTime = DateTime.Now;
                IdleScreensaverTimer.Interval = mSettings.ScreenSaverIdleTimeInSeconds;
                IdleScreensaverTimer.Start();
            }
        }

        // Stop button
        private void StopButton_Click(object sender, EventArgs e)
        {
            SetStatus(STATUS_IDLE_STR);
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AutoMouseMover.app_icon_white.ico"))
            {
                if (stream != null)
                {
                    TrayBarIcon.Icon = new Icon(stream);
                }
            }
            EnableGuiOnStop();
            CursorTimer.Stop();

            HookManager.KeyPress -= HookManager_KeyPress;
            HookManager.MouseAction -= HookManager_MouseAction;
            IdleScreensaverTimer.Stop();
        }

        // Tray icon double clicked
        private void TrayBarIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDoubleClick = true;
                DoubleClickTimer.Stop();

                if (CursorTimer.Enabled)
                {
                    StopButton_Click(this, EventArgs.Empty);
                }
                else
                {
                    StartButton_Click(this, EventArgs.Empty);
                }

                Thread.Sleep(DoubleClickTimer.Interval);
                isDoubleClick = false;
            }
        }

        // Tray icon double clicked
        private void TrayBarIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoubleClickTimer.Start();
            }
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            DoubleClickTimer.Stop();
            if (!isDoubleClick)
            {
                // Handle single-click event
                // MessageBox.Show("Single Clicked!");
                RestoreWindowFromTrayBar();
            }

            isDoubleClick = false;
        }

        // About button in menu strip
        private void StripMenuAbout_Click(object sender, EventArgs e)
        {
            AboutForm about_form = new AboutForm();
            about_form.ShowDialog();
        }

        private void StripMenuExit_Click(object sender, EventArgs e)
        {
            TrayBarMenuExit_Click(this, e);
        }

        // Open button in tray bar context menu
        private void TrayBarMenuOpen_Click(object sender, EventArgs e)
        {
            RestoreWindowFromTrayBar();
        }

        // Start button in tray bar context menu
        private void TrayBarMenuStart_Click(object sender, EventArgs e)
        {
            StartButton_Click(this, EventArgs.Empty);
        }

        // Stop button in tray bar context menu
        private void TrayBarMenuStop_Click(object sender, EventArgs e)
        {
            StopButton_Click(this, EventArgs.Empty);
        }

        // Exit button in tray bar context menu
        private void TrayBarMenuExit_Click(object sender, EventArgs e)
        {
            CursorTimer.Stop();
            mApplicationExiting = true;
            Close();
        }

        #endregion

        //
        // Other events
        //
        #region Other events

        // Closing form event
        private void AutoMouseMoverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            this.Hide();
            if (!mApplicationExiting)
            {
                e.Cancel = true;
            }
        }

        // Form resize
        private void AutoMouseMoverForm_Resize(object sender, EventArgs e)
        {
            // If window is minized when timer is enabled, minimize it to tray bar
            if ((WindowState == FormWindowState.Minimized))
            {
                MinimizeWindowToTrayBar();
            }
        }

        // Cursor timer elapsed
        private void CursorTimer_Tick(object sender, EventArgs e)
        {
            mMouseMovedByApplication = true;
            mAutoMouseMover.MoveMouse();
            mMouseMovedByApplication = false;
        }

        //IdleScreensaverTimer elapsed
        private void IdleScreensaverTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastInputTime).TotalSeconds > mSettings.ScreenSaverIdleTimeInSeconds)
            {
                OverlayForm.InitializeAlpha(mSettings.ScreenSaverOpacity);
                OverlayForm.Show();
                OverlayForm.BringToFront();
            }
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            lastInputTime = DateTime.Now;
            if (OverlayForm.Visible)
            {
                OverlayForm.Hide();
            }
        }

        private async void HookManager_MouseAction(object sender, MouseEventArgs e)
        {
            if (!mMouseMovedByApplication)
            {
                lastInputTime = DateTime.Now;

                if (e.Button == MouseButtons.Middle && e.Delta != 0)
                {
                    var title = ActiveWindow.GetActiveWindowTitle();
                    if (title == this.Text || title == OverlayForm.Text)
                    {
                        var variance = e.Delta / 100;
                        var newValue = ScreenSaverOpacityBox.Value + variance;
                        if (newValue >= ScreenSaverOpacityBox.Minimum && newValue <= ScreenSaverOpacityBox.Maximum)
                        {
                            ScreenSaverOpacityBox.Value = newValue;
                            mSettings.ScreenSaverOpacity = (int)newValue;
                            OverlayForm.InitializeAlpha(mSettings.ScreenSaverOpacity);
                        }
                    }
                }
                else
                {
                    if (OverlayForm.Visible)
                    {
                        OverlayForm.Hide();
                    }
                }
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            HookManager.KeyPress -= HookManager_KeyPress;
            HookManager.MouseAction -= HookManager_MouseAction;
            HookManager.KeyPress += HookManager_KeyPress;
            HookManager.MouseAction += HookManager_MouseAction;
            mSettings.ScreenSaverOpacity = (int)ScreenSaverOpacityBox.Value;
            OverlayForm.InitializeAlpha(mSettings.ScreenSaverOpacity);
            OverlayForm.ShowDialog();
            HookManager.KeyPress -= HookManager_KeyPress;
            HookManager.MouseAction -= HookManager_MouseAction;
            this.BringToFront();
        }

        #endregion

        //
        // Private methods
        //
        #region Private methods

        // Load settings
        private void LoadSettings()
        {
            try
            {
                MovingPeriodBox.Value = mSettings.MovingTime;
                MovingPixelBox.Value = mSettings.MovingPixel;
                ScreenSaverEnabledCheckBox.Checked = mSettings.ScreenSaverEnabled;
                ScreenSaverIdleTimeBox.Value = mSettings.ScreenSaverIdleTimeInSeconds;
                ScreenSaverOpacityBox.Value = (decimal)mSettings.ScreenSaverOpacity;
            }
            catch
            {
                // Default settings in case of errors
                mSettings.LoadDefault();
                // Set again
                MovingPeriodBox.Value = mSettings.MovingTime;
                MovingPixelBox.Value = mSettings.MovingPixel;
                ScreenSaverEnabledCheckBox.Checked = mSettings.ScreenSaverEnabled;
                ScreenSaverIdleTimeBox.Value = mSettings.ScreenSaverIdleTimeInSeconds;
                ScreenSaverOpacityBox.Value = (decimal)mSettings.ScreenSaverOpacity;
            }
        }

        // Save settings
        private void SaveSettings()
        {
            mSettings.MovingTime = (int)MovingPeriodBox.Value;
            mSettings.MovingPixel = (int)MovingPixelBox.Value;
            mSettings.ScreenSaverEnabled = ScreenSaverEnabledCheckBox.Checked;
            mSettings.ScreenSaverIdleTimeInSeconds = (int)ScreenSaverIdleTimeBox.Value;
            mSettings.ScreenSaverOpacity = (int)ScreenSaverOpacityBox.Value;
            mSettings.Save();
        }

        // Disable GUI on start
        private void DisableGuiOnStart()
        {
            MovingPeriodBox.Enabled = false;
            MovingPixelBox.Enabled = false;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            TrayBarMenuStart.Enabled = false;
            TrayBarMenuStop.Enabled = true;
            ScreenSaverEnabledCheckBox.Enabled = false;
            ScreenSaverIdleTimeBox.Enabled = false;
            ScreenSaverOpacityBox.Enabled = false;
            PreviewButton.Enabled = false;
        }

        // Enable GUI on stop
        private void EnableGuiOnStop()
        {
            MovingPeriodBox.Enabled = true;
            MovingPixelBox.Enabled = true;
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            TrayBarMenuStart.Enabled = true;
            TrayBarMenuStop.Enabled = false;
            ScreenSaverEnabledCheckBox.Enabled = true;
            if (mSettings.ScreenSaverEnabled)
            {
                ScreenSaverIdleTimeBox.Enabled = true;
                ScreenSaverOpacityBox.Enabled = true;
                PreviewButton.Enabled = true;
            }
            else
            {
                ScreenSaverIdleTimeBox.Enabled = false;
                ScreenSaverOpacityBox.Enabled = false;
                PreviewButton.Enabled = false;
            }
        }


        private void ScreenSaverEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ScreenSaverEnabledCheckBox.Checked)
            {
                ScreenSaverIdleTimeBox.Enabled = true;
                ScreenSaverOpacityBox.Enabled = true;
                PreviewButton.Enabled = true;
            }
            else
            {
                ScreenSaverIdleTimeBox.Enabled = false;
                ScreenSaverOpacityBox.Enabled = false;
                PreviewButton.Enabled = false;
            }
        }

        // Set status
        private void SetStatus(string cText)
        {
            StatusLabel.Text = String.Format("Status: {0}", cText);
        }

        // Minimize window to tray bar
        private void MinimizeWindowToTrayBar()
        {
            ShowInTaskbar = false;
            TrayBarIcon.ShowBalloonTip(BALLOON_TIP_TIMEOUT);
            Hide();
        }

        // Restore window from tray bar
        private void RestoreWindowFromTrayBar()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        #endregion
    }
}
