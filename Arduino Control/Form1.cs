using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bunifu;

namespace Arduino_Control
{
    public partial class Monitor : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void _headPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public Monitor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ChangePage(object sender, EventArgs e)
        {
            List<UserControl> uc = new List<UserControl>() { ino2,serialPortWindows1, settings1 };
            for (int i = 0; i < uc.Count; i++) uc[i].Visible = false;
            switch (((Bunifu.Framework.UI.BunifuFlatButton)sender).TabIndex)
            {
                case 1:
                    ino2.Visible = true;
                    break;
                case 2:
                    serialPortWindows1.Visible = true;
                    break;
                case 3:
                    settings1.Visible = true;
                    break;
            }
           
        }

        private void settings1_Load(object sender, EventArgs e)
        {

        }

        private void ino2_Load(object sender, EventArgs e)
        {

        }

        private void serialPortWindows1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("製作者：林鍾宇","Maker",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
