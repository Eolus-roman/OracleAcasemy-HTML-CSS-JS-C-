using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface ICleaning
    {
        void DailyCleaning();
        void WeekendCleaning();
        void QuickCleaning();
        void BigCleaning();

    }
}
