using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface IVolume
    {
        int CurrentVolume { get; set; }
        void SetVolume(int input);
        void PlusVolume();
        void MinusVolume();
        void Mute();
    }
}
