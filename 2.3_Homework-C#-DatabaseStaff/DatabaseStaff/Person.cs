using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStaff
{
    [Serializable]
    public abstract class Person
    {
      
        public Person() { }
        public Person(string alias, string name, string surname, string department)
        {
            Alias = alias;
            Name = name;
            Surname = surname;
            Department = department;
            

        }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }

        public override string ToString()
        {
            return "Псевдоним: " + Alias + "\nИмя:" + Name + "\nФамилия: " + Surname + "\nОтдел: " + Department;
        }








    }
}
