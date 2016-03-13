using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    class LogRead : IReadFile
    {
        public string ReadLine()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("setting.ini", System.Text.Encoding.Default))
            {
                line = sr.ReadLine();
            }
            return line;
        }
    }
}
