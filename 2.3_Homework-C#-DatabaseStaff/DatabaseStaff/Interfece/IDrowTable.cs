using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    interface IDrowTable
    {
        string MakeTableResults(List<Employee> listEmp);
    }
}
