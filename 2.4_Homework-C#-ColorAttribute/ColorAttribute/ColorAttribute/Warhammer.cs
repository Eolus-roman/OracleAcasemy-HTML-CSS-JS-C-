using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorAttribute
{
    class Warhammer
    {
         
        public Warhammer(string name, string loyalty, string motto)
        {
            Name = name;
            Loyalty = loyalty;
            Motto = motto;
        }

       [ColorProperty(ConsoleColor.Cyan)]
        public string Name { get; set; }

        [ColorProperty(ConsoleColor.Magenta)]
        public string Loyalty { get; set; }

        [ColorProperty(ConsoleColor.Blue)]
        public string Motto { get; set; }





    }
}
