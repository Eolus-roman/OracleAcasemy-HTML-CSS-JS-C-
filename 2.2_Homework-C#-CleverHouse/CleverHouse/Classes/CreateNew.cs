using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class CreateNew : ICreate
    {
        public Television NewTV()
        {
            Television tv = new Television(false, 100, 0);
            return tv;
        }
        public Fridge NewFridge()
        {
            Fridge fr = new Fridge(false, false, 3);
            return fr;
        }
        public Hoover NewHoover()
        {
            Hoover h = new Hoover(false, 0, 100);
            return h;
        }

        public StationaryBicycle NewBicycle()
        {
            StationaryBicycle sb = new StationaryBicycle(false, 60);
            return sb;
        }

        public Warhammer NewGame()
        {
            Warhammer wh = new Warhammer(false, "Игрок, ты еще не сыграл ни одной битвы!");
            return wh;
        }
    }
}
