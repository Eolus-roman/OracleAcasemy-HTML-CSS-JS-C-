using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class CreateNew : ICreate
    {
        public Fridge NewFridge()
        {
            Fridge fr = new Fridge(false, false, 3);
            return fr;
        }

        public Television NewTV()
        {
            Television tv = new Television(false, 100);
            return tv;
        }

        public Hoover NewHoover()
        {
            Hoover h = new Hoover(false, false);
            return h;
        }

        public StationaryBicycle NewBicycle()
        {
            StationaryBicycle sb = new StationaryBicycle(false);
            return sb;
        }

        public Warhammer NewGame()
        {
            Warhammer wh = new Warhammer(false, false);
            return wh;
        }
    }
}
