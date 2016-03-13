using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    interface ICheckFile
    {
        List<Employee> TickFile(ILog log, IReadFile read);
    }
}
