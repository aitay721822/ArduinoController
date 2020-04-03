using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_Control
{
    public class Slide
    {
        public string Pins { get; set; }
        public string Status { get; set; }
        public string IO { get; set; }
        public string Function { get; set; }
        public string Returns { get; set; }
        public Slide(string pins, string status, string io, string function, string returns)
        {
            Status = status;
            IO = io;
            Pins = pins;
            Function = function;
            Returns = returns;
        }

        public bool Check()
        {
            string[] g = new string[] { Pins, Status, IO, Function, Returns };
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i] == null || g[i] == string.Empty) return false;
            }
            return true;
        }
    }
}
