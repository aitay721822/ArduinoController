using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arduino_Control
{
    class Readasd
    {
        private string file { get; set; }

        public Readasd(string path)
        {
            file = path;
        }

        private string[] GetFileStr()
        {
            StreamReader str = new StreamReader(file);
            string s = str.ReadToEnd();
            string[] result = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            str.Close();
            return result;
        }

        private string[] toArr(string f)
        {
            f = f.Trim(new char[] { '{', '}' });
            string[] result = f.Split(' ');
            return result;
        }

        public List<Pin> Load()
        {
            List<Pin> result = new List<Pin>();
            string[] f = GetFileStr();
            for(int i = 1; i < f.Length; i++)
            {
                try
                {
                    string strings = f[i];
                    strings = strings.Trim(new char[] { '[', ']' });
                    string[] Array = strings.Split(',');
                    Pin data = new Pin();
                    data.Names = Array[0];
                    data.digitalPins = toArr(Array[1]);
                    data.digitalPins_Pwm = toArr(Array[2]);
                    data.analogPins = toArr(Array[3]);
                    result.Add(data);
                }
                catch { }
            }
            return result;
        }
    }
}
