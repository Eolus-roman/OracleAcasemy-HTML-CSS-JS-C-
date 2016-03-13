using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    class Operations: IOperation
    {
        public List<Employee> Employees {get; set;}


        public void NewEmp(string alias, string name, string surname, string department, string position)
        {
            Employees.Add(new Employee(alias, name, surname, department, position));
        }

        public void Delete(string alias)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Alias == alias)
                {
                    Employees.Remove(Employees[i]);
                }
            }
        }

        public Employee FindEmployee(string alias)
        {
            Employee emp = Employees.Find(x => x.Alias == alias);
            return emp;
        }
    }
}
