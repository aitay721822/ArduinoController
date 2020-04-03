using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Arduino_Control
{
    public partial class ino : UserControl
    {
        public ino()
        {
            InitializeComponent();
            try
            {
                Readasd Read = new Readasd(Application.StartupPath + @"\ArduinoSettings.asd");
                pins = Read.Load();
            }
            catch { }
            List<string> ArdName = new List<string>();
            for(int i = 0; i < pins.Count; i++)
                ArdName.Add(pins[i].Names);
            this.bunifuDropdown2.Items = ArdName.ToArray();
            if (this.bunifuDropdown2.Items.Length > 0) this.bunifuDropdown2.selectedIndex = 0;
            refresh();
        }

        string Code = string.Empty;
        string path = string.Empty;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "請開啟一個ino檔案";
            ofd.Filter = "ino Files|*.ino";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
                if (ofd.OpenFile() != null)
                {
                    StreamReader str = new StreamReader(ofd.OpenFile(),Encoding.Default);
                    Code = str.ReadToEnd();
                    label7.ForeColor = Color.Green;
                    label7.Text = String.Format("上傳狀態：{0}", Path.GetFileName(ofd.FileName));
                    path = ofd.FileName;
                    str.Close();
                    str.Dispose();

                }
                else
                {
                    label7.ForeColor = Color.FromArgb(192, 0, 0);
                    label7.Text = String.Format("上傳狀態：無");
                }
            ofd.Dispose();

        }
        List<Pin> pins = new List<Pin>();
        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {

        }

        public void refresh()
        {
            if(this.bunifuDropdown2.Items.Length>0 && this.bunifuDropdown2.selectedIndex >= 0)
            {
                for (int i = 0; i < pins.Count; i++)
                {
                    if (this.bunifuDropdown2.selectedValue == pins[i].Names)
                    {
                        this.bunifuDropdown1.Items = pins[i].getAllpins();
                    }
                }
            }
        }

        public void refreshdeletekey()
        {
            List<string> keys = new List<string>();
            ini ireader = new ini();
            string ininame = @"Pins.ini";
            for (int i = 0; i < this.bunifuDropdown1.Items.Length; i++)
            {
                string receive = ireader.IniReadValue(this.bunifuDropdown1.Items[i], "Status", ininame);
                if (receive != null && receive != string.Empty) keys.Add(this.bunifuDropdown1.Items[i]);
            }
            this.bunifuDropdown5.Items = keys.ToArray();
        }

        public void refreshAdding(TextBox tb)
        {
            ini ireader = new ini();
            string ininame = @"Pins.ini";
            string get = string.Empty;
            for (int i = 0; i < this.bunifuDropdown1.Items.Length; i++)
            {
                string status = ireader.IniReadValue(this.bunifuDropdown1.Items[i], "Status", ininame);
                string IO = ireader.IniReadValue(this.bunifuDropdown1.Items[i], "IO", ininame);
                if ((status != null && IO != null) && (status != string.Empty && IO != string.Empty)) 
                    get += string.Format("腳位：{0} , 腳位狀態：{1} , I/O狀態：{2}\r\n", this.bunifuDropdown1.Items[i], status, IO);
            }
            tb.Text = get;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            ini ireader = new ini();
            string ininame = @"Pins.ini";
            ireader.IniWriteValue(this.bunifuDropdown1.selectedValue, "Status", this.bunifuDropdown3.selectedValue,ininame);
            ireader.IniWriteValue(this.bunifuDropdown1.selectedValue, "IO", this.bunifuDropdown4.selectedValue, ininame);
            refreshAdding(Ms);
            refreshdeletekey();
        }

        private void Selected(object sender, EventArgs e)
        {
            refresh();
            refreshAdding(Ms);
            refreshdeletekey();
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < pins.Count; i++)
                if (this.bunifuDropdown2.selectedValue == pins[i].Names)
                {
                    index = i; break;
                }

            if (index != -1)
            {
                bool isD = pins[index].isDigitalPins(bunifuDropdown1.selectedValue);
                if (isD)
                {
                    bunifuDropdown3.selectedIndex = 0;
                    bunifuDropdown3.Enabled = false;
                }
                else
                {
                    bunifuDropdown3.selectedIndex = 1;
                    bunifuDropdown3.Enabled = true;
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            ini ireader = new ini();
            string ininame = @"Pins.ini";
            ireader.IniWriteValue(this.bunifuDropdown5.selectedValue, null, null,ininame);
            refreshAdding(Ms);
            refreshdeletekey();
        }

        private class PinAndStatus
        {
            public string Pin;
            public string Status;
        }

        string Systemini = @"System.ini";
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (Code != string.Empty && path != string.Empty)
            {
                List<string> codeSTR = Code.Split(new string[] { "\n","\r\n","\r" }, StringSplitOptions.None).ToList<string>();
                for(int i = 0; i < codeSTR.Count; i++)
                    if (codeSTR[i].ToLower().Contains("void") && codeSTR[i].ToLower().Contains("setup"))
                    {
                        int countdown = 0, j = i;
                        bool flag = false;
                        while (j != codeSTR.Count - 1)
                        {
                            if (codeSTR[j].ToLower().Contains("{")) { countdown++; }
                            if (codeSTR[j].ToLower().Contains("}") && countdown > 0) { countdown--; }
                            if (codeSTR[j].ToLower().Contains("}") && countdown == 0) { break; }

                            if (codeSTR[j].ToLower().Contains("serial.begin"))
                            {
                                ini inireader = new ini();
                                string Baud = inireader.IniReadValue("SystemInfo", "Baud", Systemini);
                                DialogResult result = MessageBox.Show("已存在Serial.begin語法，繼續添加的話可能會影響到傳送的訊息，是否繼續添加?", "Adding Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    if (Baud != string.Empty && Baud != null)
                                    {
                                        codeSTR.Insert(i + 1, string.Format("Serial.begin({0});", Baud));
                                        MessageBox.Show(string.Format("添加成功，您的鮑率已設置成{0}", Baud), "Done", MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        codeSTR.Insert(i + 1, string.Format("Serial.begin(9600);"));
                                        MessageBox.Show(string.Format("添加成功，您的鮑率已設置成{0}", "9600"), "Done", MessageBoxButtons.OK);
                                    }
                                }
                                flag = true;
                                break;
                            }
                            j++;
                        }
                        if (!flag)
                        {
                            codeSTR.Insert(i + 1, string.Format("Serial.begin(9600);"));
                        }

                    }

                ini ireader = new ini();
                string ininame = @"Pins.ini";
                string get = string.Empty;
                List<PinAndStatus> pinadd = new List<PinAndStatus>();
                for (int i = 0; i < this.bunifuDropdown1.Items.Length; i++)
                {
                    string status = ireader.IniReadValue(this.bunifuDropdown1.Items[i], "Status", ininame);
                    string IO = ireader.IniReadValue(this.bunifuDropdown1.Items[i], "IO", ininame);
                    if ((status != null && IO != null) && (status != string.Empty && IO != string.Empty))
                    {
                        PinAndStatus pas = new PinAndStatus();
                        if (status == "數位Digital") pas.Status = "digitalRead";
                        else pas.Status = "analogRead";
                        pas.Pin = this.bunifuDropdown1.Items[i];
                        pinadd.Add(pas);
                    }
                }

                int index = -1;
                for (int i = 0; i < codeSTR.Count; i++)
                    if (codeSTR[i].ToLower().Contains("void") && codeSTR[i].ToLower().Contains("loop"))
                        index = i;

                for(int i=0;i<pinadd.Count; i++)
                {
                    codeSTR.Insert(index + 1, string.Format(@"Serial.println(""pin{0}="" + String({1}({2})));",pinadd[i].Pin, pinadd[i].Status, pinadd[i].Pin));
                }

                SaveFileDialog save = new SaveFileDialog();
                save.Title = "儲存Ino檔案";
                save.Filter = "ino Files|*.ino";
                save.CheckPathExists = true;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (save.FileName != null && save.FileName != string.Empty)
                    {
                        InsertText(codeSTR, save.FileName);
                    }
                }
                MessageBox.Show("注意，如果您Serial或訊息傳送速度太快，傳送會失敗哦!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("現在請打開您的ArduinoIDE上傳剛才儲存的程式碼哦!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else MessageBox.Show("請上傳ino檔案哦！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InsertText(List<string> Coding,string paths)
        {
            FileStream stream = File.Create(paths);
            stream.Close();
            StreamWriter sw = new StreamWriter(paths, false);
            string All = string.Empty;
            for(int i = 0; i < Coding.Count; i++) { All += Coding[i] + "\r\n"; }
            sw.Write(All);
            sw.Close();
        }

        private void Ms_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown5_onItemSelected(object sender, EventArgs e)
        {

        }
    }
}
