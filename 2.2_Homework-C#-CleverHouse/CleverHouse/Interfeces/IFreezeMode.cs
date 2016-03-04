using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface IFreezeMode
    {
        double Temperature { get; set; }
        void SetFreezing();
        void SetDefault();
        void SetDefrost();
       
    }
}
