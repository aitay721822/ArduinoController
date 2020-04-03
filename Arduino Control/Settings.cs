using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Arduino_Control
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            FindComPortName();
            RefreshPins();
            Refresh_dt();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
        
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (function.Text != string.Empty && returns.Text != string.Empty && bunifuDropdown3.selectedIndex != -1)
            {
                ini ireader = new ini();
                ireader.IniWriteValue(bunifuDropdown3.selectedValue, "Function", function.Text, ininame);
                ireader.IniWriteValue(bunifuDropdown3.selectedValue, "Returns", returns.Text, ininame);
                slideView1.Refreshes();
            }
            else MessageBox.Show("請填入相關資訊", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        void Refresh_dt()
        {
            ini ireader = new ini();
            string str = ireader.IniReadValue("SystemInfo", "SendMilliSecond", Systemini);
            if (str != string.Empty && str != null)
            {
                bunifuMaterialTextbox1.Text = str;
            }
        }

        public void FindComPortName()
        {
            string[] ports = SerialPort.GetPortNames();
            bunifuDropdown1.Items = ports;
            if (bunifuDropdown1.Items.Length > 0 && bunifuDropdown1.selectedIndex == -1)
                bunifuDropdown1.selectedIndex = 0;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            FindComPortName();
        }

        string Systemini = @"System.ini";
        LineNotify Line;
        private async void RefreshLineStatus(string path)
        {
            Line = new LineNotify(path);
            bool Service = await Line.CheckStatus();
            if (Service)
            {
                label4.Text = "已連線";
                label4.ForeColor = Color.Green;
                
            }
            else
            {
                label4.Text = "尚未連線";
                label4.ForeColor = Color.Red;
            }
            ini ireader = new ini();
            ireader.IniWriteValue("SystemInfo", "IFTTT", path, Systemini);

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text != string.Empty)
            {
                RefreshLineStatus(bunifuMaterialTextbox4.Text);
            }
            else MessageBox.Show("請填入IFTTT提供的網址", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        string ininame = "Pins.ini";
        private void RefreshPins()
        {
            try
            {
                ini ireader = new ini();
                List<string> Get = ireader.GetAllSection(ininame);
                bunifuDropdown3.Items = Get.ToArray();
            }
            catch { }
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            RefreshPins();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void slideView1_Load(object sender, EventArgs e)
        {

        }

        private void selected(object sender, EventArgs e)
        {
            ini ireader = new ini();
            ireader.IniWriteValue("SystemInfo", "SerialPort", bunifuDropdown1.selectedValue, Systemini);
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            ini ireader = new ini();
            ireader.IniWriteValue("SystemInfo", "Baud", bunifuDropdown2.selectedValue, Systemini);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ini ireader = new ini();
            ireader.IniWriteValue("SystemInfo", "SendMilliSecond", bunifuMaterialTextbox1.Text, Systemini);

        }
    }
}
