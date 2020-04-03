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
using System.Threading;

namespace Arduino_Control
{
    public partial class SerialPortWindows : UserControl
    {
        string delaytime = "1000";
        string Systemini = @"System.ini";
        string Baud = string.Empty, SerialPort = string.Empty, IFTTT_path = string.Empty;

        public SerialPortWindows()
        {
            InitializeComponent();
            ini ireader = new ini();
            Baud = ireader.IniReadValue("SystemInfo", "Baud", Systemini);
            SerialPort = ireader.IniReadValue("SystemInfo", "SerialPort", Systemini);
            IFTTT_path = ireader.IniReadValue("SystemInfo", "IFTTT", Systemini);
            delaytime = ireader.IniReadValue("SystemInfo", "SendMilliSecond", Systemini);
        }
        
        int getEvent()
        {
            int p = 0;
            ini ireader = new ini();
            List<string> getAllSection = ireader.GetAllSection(ininame);
            for (int i = 0; i < getAllSection.Count; i++)
            {
                string pins = getAllSection[i];
                string Status = ireader.IniReadValue(getAllSection[i], "Status", ininame);
                string IO = ireader.IniReadValue(getAllSection[i], "IO", ininame);
                string Function = ireader.IniReadValue(getAllSection[i], "Function", ininame);
                string Returns = ireader.IniReadValue(getAllSection[i], "Returns", ininame);
                Slide slide = new Slide(pins, Status, IO, Function, Returns);
                if (slide.Check())
                {
                    p++;
                }
            }
            return p;
        }

        int quecount = 0;
        void Add_event(string value)
        {
            ini ireader = new ini();
            List<string> getAllSection = ireader.GetAllSection(ininame);
            for (int i = 0; i < getAllSection.Count; i++)
            {
                if (value.Contains(string.Format("pin{0}=", getAllSection[i])))
                {
                    string pins = getAllSection[i];
                    string Status = ireader.IniReadValue(getAllSection[i], "Status", ininame);
                    string IO = ireader.IniReadValue(getAllSection[i], "IO", ininame);
                    string Function = ireader.IniReadValue(getAllSection[i], "Function", ininame);
                    string Returns = ireader.IniReadValue(getAllSection[i], "Returns", ininame);
                    Slide slide = new Slide(pins, Status, IO, Function, Returns);
                    if (slide.Check())
                    {
                        if (slide.Returns.Contains("[time]")) slide.Returns = slide.Returns.Replace("[time]", "[" + DateTime.Now.ToString() + "]");
                        string[] var = value.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        if (slide.Returns.Contains("[var]")) slide.Returns = slide.Returns.Replace("[var]", "[" + var[var.Length - 1].Trim('\r') + "]");
                        Pin_Queue.Add(slide);
                        if (quecount > 0) quecount--;
                    }
                }
            }
        }

        private void valueChange(object sender, EventArgs e)
        {
            
        }
        void Refresh_Serial()
        {
            ini ireader = new ini();
            Baud = ireader.IniReadValue("SystemInfo", "Baud", Systemini);
            SerialPort = ireader.IniReadValue("SystemInfo", "SerialPort", Systemini);
            IFTTT_path = ireader.IniReadValue("SystemInfo", "IFTTT", Systemini);
            if (SerialPort != string.Empty && Baud != string.Empty)
            {
                try
                {
                    serialPort = new System.IO.Ports.SerialPort(SerialPort, Convert.ToInt32(Baud));
                    serialPort.Open();
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(MyDataReceived);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("ComPort被其他程序占走了哦!", "ComPort Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.ScrollToCaret();
            }
            catch
            {
                richTextBox1.Text = string.Empty;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            serialPort.WriteLine(bunifuMaterialTextbox1.Text);
            bunifuMaterialTextbox1.Text = string.Empty;
        }

        private void Keydown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bunifuFlatButton1_Click(sender, e);
            }
        }

        void MyDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                UpdateUI(serialPort.ReadLine(), richTextBox1);
            }
            catch { }
        }

        string ininame = "Pins.ini";
        async void SendMessage_Line()
        {
            if(IFTTT_path != string.Empty)
            {
                if (Pin_Queue.Count > 0)
                {
                    bool Sending = false;

                    LineNotify ln = new LineNotify(IFTTT_path);
                    Slide Send = Pin_Queue[0]; Pin_Queue.Remove(Send);
                    Sending = await ln.SendMessageAsync(Send.Returns);
                   
                    if (!Sending)
                    {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.AppendText("傳送失敗" + Environment.NewLine);
                    }
                    else
                    {
                        richTextBox1.SelectionColor = Color.Green;
                        richTextBox1.AppendText("傳送成功" + Environment.NewLine);
                    }
                }
            }
        }
        
        List<Slide> Pin_Queue = new List<Slide>();
        DateTime previous = DateTime.Now;
        private delegate void UpdateUICallBack(string value, Control ctl);
        private void UpdateUI(string value, Control ctl)
        {
            if (this.InvokeRequired)
            {
                UpdateUICallBack uu = new UpdateUICallBack(UpdateUI);
                this.Invoke(uu, value, ctl);
            }
            else
            {
                ctl.Text += value;

                ini ireader = new ini();
                delaytime = ireader.IniReadValue("SystemInfo", "SendMilliSecond", Systemini);
                TimeSpan ts = DateTime.Now - previous;
                if (delaytime != null && delaytime != string.Empty)
                {
                    if (ts.TotalMilliseconds >= Convert.ToInt32(delaytime) || quecount > 0) 
                    {
                        if (quecount == 0) quecount = getEvent();
                        Add_event(value);
                        previous = DateTime.Now;
                    }
                    label1.ForeColor = Color.Green;
                    label1.Text = "已依照已設置的傳送間距秒數傳送(LineNotify)";
                }
                else
                {
                    if (ts.TotalMilliseconds >= 1000 || quecount > 0)
                    {
                        if (quecount == 0) quecount = getEvent();
                        Add_event(value);
                        previous = DateTime.Now;
                    }
                    label1.ForeColor = Color.Red;
                    label1.Text = "依預設傳送間距秒數傳送，請到-設定-設置間距";
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(serialPort!=null && serialPort.IsOpen)
            {
                try
                {
                    Thread closeSerial = new Thread(new ThreadStart(Serial_Close));
                    closeSerial.Start();
                }
                catch
                {
                }
            }
            else { MessageBox.Show("請打開SerialPort才能結束連線哦", "Err", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Serial_Close()
        {
            try
            {
                serialPort.DataReceived -= MyDataReceived;
                serialPort.Close();
            }
            catch
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Refresh_Serial();
        }

        private void event_trigger_Tick(object sender, EventArgs e)
        {
            SendMessage_Line();
        }

        System.IO.Ports.SerialPort serialPort;
        private void SerialPortWindows_Load(object sender, EventArgs e)
        {
            
        }
    }
}
