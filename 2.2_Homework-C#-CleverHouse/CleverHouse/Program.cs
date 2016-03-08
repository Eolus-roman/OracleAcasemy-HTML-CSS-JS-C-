using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateNew CN = new CreateNew();
            new Menu().Show(CN);
        }
    }
}
