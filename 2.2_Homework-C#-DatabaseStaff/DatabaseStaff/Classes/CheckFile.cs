using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    class CheckFile : ICheckFile
    {
        List<Employee> list;
        public List<Employee> TickFile(ILog log, IReadFile read)
        {
            if (read.ReadLine() == "XML")
            {
                log = new LogXml();
                if (File.Exists("employees.xml"))
                {
                    list = (List<Employee>)log.LogOut();
                }
                else
                {
                    list = new List<Employee>();
                }
            }
            if (read.ReadLine() == "BIN")
            {
                log = new LogBinary();
                if (File.Exists("employees.dat"))
                {
                    list = (List<Employee>)log.LogOut();
                }
                else
                {
                    list = new List<Employee>();
                }
            }
            return list;

        }
    }
}
