using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface ILevelChange
    {
        void FirstLvl(); // Hills, QuickCleanMode, Defrost, Space
        void SecondLvl(); //DirtRoad, DailyMode, Default, Riot
        void ThirdLvl(); //Highway, OutputMode, Freezing, BattleForPlanet
        void FourthLvl(); //VelodromeMode, TotalCleanMode, SuperFreezing, ChaosBreakthrough
    }
}
