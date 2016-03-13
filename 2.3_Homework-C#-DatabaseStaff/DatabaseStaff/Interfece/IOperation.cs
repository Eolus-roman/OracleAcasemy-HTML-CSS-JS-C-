using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    interface IOperation
    {
        List<Employee> Employees { get; set; }
        void NewEmp(string alias, string name, string surname, string department, string position);
        void Delete(string alias);
        Employee FindEmployee(string alias);

    }
}
