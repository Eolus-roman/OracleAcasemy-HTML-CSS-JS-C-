using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseStaff
{
    [Serializable]
    public class Employee : Person
    {
       
        public Employee() { }
        public Employee(string alias, string name, string surname, string department, string position)
             :base (alias, name, surname, department)
        {
            
            Position = position;
        }

        public string Position { get; set; }

        public override string ToString()
        {
            return base.ToString() + "\nДолжность: " + Position;
        }

    }
}
