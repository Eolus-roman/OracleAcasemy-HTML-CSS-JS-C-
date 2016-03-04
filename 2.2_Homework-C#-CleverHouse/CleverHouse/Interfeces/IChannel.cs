using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public interface IChannel
    {
        string ListChannel();
        int MaxChannel { get; set; }
        void NextChannel();
        void PreviousChannel();
        void GoToChannel(int input);

        void AddChannels();
    }
}
