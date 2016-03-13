using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    [Serializable]
    public class Employee : Person
    {
        public Employee() { }
        public Employee(string alias, string name, string surname, string department, string position)
        {
            alias = Alias;
            name = Name;
            surname = Surname;
            department = Department;
            position = Position;
        }

        public string Position { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\nДолжность: " + Position;
        }

    }
}
