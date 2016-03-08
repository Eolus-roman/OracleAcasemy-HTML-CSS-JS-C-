using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface ISetTemperature
    {
        double Temperature { get; set; }
        void SetTemperature(double input);
    }
}
