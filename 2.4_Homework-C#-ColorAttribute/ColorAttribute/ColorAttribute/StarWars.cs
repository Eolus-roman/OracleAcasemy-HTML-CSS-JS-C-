using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorAttribute
{
    class StarWars
    {
        public StarWars(string typeOfForce, string colorSword)
        {
            TypeOfForce = typeOfForce;
            ColorSword = colorSword;
        }

    [ColorProperty(ConsoleColor.Yellow)]
        public string TypeOfForce { get; set; }


        [ColorProperty(ConsoleColor.Red)]
        public string ColorSword { get; set; }


    }
}
