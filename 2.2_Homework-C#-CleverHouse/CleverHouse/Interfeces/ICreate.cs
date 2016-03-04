using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface ICreate
    {
        Fridge NewFridge();
        Television NewTV();
        Hoover NewHoover();
        StationaryBicycle NewBicycle();
        Warhammer NewGame();
    }
}
