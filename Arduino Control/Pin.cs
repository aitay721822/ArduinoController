using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Control
{
    public class Pin
    {
        public string Names { get; set; }
        public string[] digitalPins { get; set; }
        public string[] digitalPins_Pwm { get; set; }
        public string[] analogPins { get; set; }

        private bool checkStatus()
        {
            if (Names == null || digitalPins == null || digitalPins_Pwm == null || analogPins == null) return false;
            else return true;
        }

        public string[] getDigitalPins()
        {
            if (checkStatus())
            {
                List<string> DigitalPins = new List<string>();
                for (int i = 0; i < digitalPins.Length; i++) DigitalPins.Add(digitalPins[i]);
                for (int i = 0; i < digitalPins_Pwm.Length; i++) DigitalPins.Add(digitalPins_Pwm[i]);
                return DigitalPins.ToArray();
            }
            return null;
        }

        public string[] getAnalogPins()
        {
            if (checkStatus())
            {
                return analogPins;
            }
            return null;
        }

        public string[] getAllpins()
        {
            if (checkStatus())
            {
                List<string> Allpins = new List<string>();
                for (int i = 0; i < digitalPins.Length; i++) Allpins.Add(digitalPins[i]);
                for (int i = 0; i < digitalPins_Pwm.Length; i++) Allpins.Add(digitalPins_Pwm[i]);
                for (int i = 0; i < analogPins.Length; i++) Allpins.Add(analogPins[i]);
                return Allpins.ToArray();
            }
            return null;
        }

        public bool isDigitalPins(string i)
        {
            if (digitalPins.ToList<string>().IndexOf(i) >= 0) return true;
            else if(digitalPins_Pwm.ToList<string>().IndexOf(i) >= 0) return true;
            else if(analogPins.ToList<string>().IndexOf(i) >= 0) return false;
            return false;
        }
    }

}
