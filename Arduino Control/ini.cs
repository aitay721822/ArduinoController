using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Arduino_Control
{
    class ini
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section,
        string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
        string key, string def, StringBuilder retVal,
        int size, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        public void IniWriteValue(string Section, string Key, string Value, string inipath)
        {
            WritePrivateProfileString(Section, Key, Value, Application.StartupPath + "\\" + inipath);
        }
        public string IniReadValue(string Section, string Key, string inipath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, Application.StartupPath + "\\" + inipath);
            return temp.ToString();
        }

        public List<string> GetAllSection(string inipath)
        {
            byte[] buffer = new byte[1024];
            GetPrivateProfileSectionNames(buffer, buffer.Length, Application.StartupPath + "\\" + inipath);
            string allSections = System.Text.Encoding.Default.GetString(buffer);
            List<string> result = allSections.Trim('\0').Split(new string[] { "\0\0\0" },StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            for (int i = 0; i < result.Count; i++) result[i] = result[i].Replace("\0","");
            return result;
        }
    }
}
