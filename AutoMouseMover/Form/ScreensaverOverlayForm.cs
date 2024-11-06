using AutoMouseMover.WinWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMouseMover.Form
{
    public partial class ScreensaverOverlayForm : System.Windows.Forms.Form
    {
        public ScreensaverOverlayForm()
        {
            InitializeComponent();

            // Set the background to transparent
            this.BackColor = System.Drawing.Color.Black;
            this.TransparencyKey = System.Drawing.Color.Black;

        }

        public void InitializeAlpha(double opacity)
        {
            // Use the SetLayeredWindowAttributes to adjust the opacity
            byte alpha = (byte)((opacity / 100) * 255);
            SetLayeredWindowAttributes(this.Handle, 0, alpha, 0x02);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    }
}
