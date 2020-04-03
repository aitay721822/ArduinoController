using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_Control
{
    public partial class SlideView : UserControl
    {
        public SlideView()
        {
            InitializeComponent();
        }

        private void SlideView_Load(object sender, EventArgs e)
        {
            Refreshes();
        }

        string ininame = "Pins.ini";
        private List<Slide> refreshSlideView()
        {
            List<Slide> slide = new List<Slide>();

            ini ireader = new ini();
            List<string> getAll = ireader.GetAllSection(ininame);
            for(int i = 0; i < getAll.Count; i++)
            {
                Slide newslide;
                string pins = getAll[i];
                string Status = ireader.IniReadValue(getAll[i], "Status", ininame);
                string IO = ireader.IniReadValue(getAll[i], "IO", ininame);
                string Function = ireader.IniReadValue(getAll[i], "Function", ininame);
                string Returns = ireader.IniReadValue(getAll[i], "Returns", ininame);
                newslide = new Slide(pins, Status, IO, Function, Returns);
                if(newslide.Check()) slide.Add(newslide);
            }
            return slide;
        }

        int index = 0;
        public void Refreshes()
        {
            List<Slide> source = refreshSlideView();
            if (source.Count > 0)
            {
                this.bunifuCustomLabel1.Text = "事件" +((index % source.Count)+1).ToString();
                this.bunifuCustomLabel2.Text = string.Format("" +
                    "監控腳位：{0}\r\n數位 / 類比：{1}\r\n輸入 / 輸出：{2}\r\n主要功能：{3}\r\n回傳字元：\r\n{4}",
                    source[index % source.Count].Pins,
                    source[index % source.Count].Status,
                    source[index % source.Count].IO,
                    source[index % source.Count].Function,
                    source[index % source.Count].Returns
                    );
            }
            else if(source.Count ==0)
            {
                this.bunifuCustomLabel1.Text = "事件None";
                this.bunifuCustomLabel2.Text = string.Format("" +
                    "監控腳位：{0}\r\n數位 / 類比：{1}\r\n輸入 / 輸出：{2}\r\n主要功能：{3}\r\n回傳字元：\r\n{4}",
                    "無",
                    "無",
                    "無",
                    "無",
                    "無"
                    );
            }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }        

        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            Refreshes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index <= 0) { index = 0; }
            else
            {
                index--;
                Refreshes();
            }
        }
    }
}
