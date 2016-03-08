using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public enum TemperatureLvl
    {
        Default, //стандартно от 0 до 5 включительно
        Freezing, // заморозка от -10 до 0
        SuperFreezing, // заморозка от -10 до 0
        Defrost, // разморозка от 6 до 15
    }
}
