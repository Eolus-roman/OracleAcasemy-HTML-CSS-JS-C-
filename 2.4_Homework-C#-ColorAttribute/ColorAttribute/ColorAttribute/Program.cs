using ColorConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Warhammer wh = new Warhammer("Ultramarines", "Loyalist", "Courage and Honour!");
            StarWars sw = new StarWars("Sith", "RedSword\n");

            Console.WriteLine("Свойства объекта " + wh.GetType() + " :");
            ColorProperty.ColorPrint(wh);
            Console.WriteLine("\n");
            Console.WriteLine("Свойства объекта " + sw.GetType() + " :");
            ColorProperty.ColorPrint(sw);
            
        }
    }
}
