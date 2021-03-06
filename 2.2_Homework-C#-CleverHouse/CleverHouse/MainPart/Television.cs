﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    public class Television : Device, IChannel, IVolume, ILinkChennel
    {
        private int currentVolume; // текущая громкость
        private int currentChannel; // текущий канал
        private int temp;
        
        private List<string> channels;
        const int MinVoluve = 0;
        const int MaxVolume = 100;
        public Television(bool status, int maxChannel, int channelNumber)
            : base(status)
        {
            MaxChannel = maxChannel;
            ChannelNumber = channelNumber;
        }
        public int MaxChannel { get; set; }
        public int ChannelNumber { get; set; }
        public int CurrentVolume
        {
            get
            {
                return currentVolume;
            }
            set
            {
                if (value >= MinVoluve && value <= MaxVolume)
                {
                    currentVolume = value;
                }
            }
        }

        public int CurrentChannel
        {
            get
            {
                return currentChannel;
            }
            set
            {
                if (value <= MaxChannel && value >= 0)
                {
                    currentChannel = value;
                }
            }
        }
        public string NameChannel { get; set; }
        public override void On()
        {
            if (Status == false)
            {
                Status = true;
                CurrentChannel = 0;
            }
        }

        public void PlusVolume()
        {
            if (Status)
            {
                if (CurrentVolume < 100)
                {
                    CurrentVolume += 5;
                }
            }
        }

        public void MinusVolume()
        {
            if (Status)
            {
                if (CurrentVolume > 0)
                {
                    CurrentVolume -= 5;
                }
            }
        }
        public void Mute()
        {
            if (Status)
            {
                CurrentVolume = 0;
            }
        }




        public void NextChannel()
        {
            if (Status)
            {
                temp = CurrentChannel;
                if (CurrentChannel < MaxChannel)
                {
                    CurrentChannel += 1;
                }
                else
                {
                    CurrentChannel = 1;
                }
                СhangeTheСhannel();
            }
        }
        public void PreviousChannel()
        {
            if (Status)
            {
                CurrentChannel = temp;
                СhangeTheСhannel();
            }
        }
        public void SetVolume(int input)
        {
            if (Status)
            {
                CurrentVolume = input;
            }
        }
        public void GoToChannel(int input)
        {
            if (Status)
            {
                temp = CurrentChannel;
                CurrentChannel = input;
                СhangeTheСhannel();
            }
        }
        public string LinkChannelList()
        {
            string str = "";
            if (Status)
            {
                channels = new List<string>();
                //chanLink = true;

                for (int i = 0; i < MaxChannel; i++)
                {
                    str += "\n№" + ChannelNumber + ", Отклик канала - есть.";
                    if (ChannelNumber == 0)
                    {
                        channels.Add("NBC");
                    }
                    if (ChannelNumber == 1)
                    {
                        channels.Add("Eurosport");
                    }
                    if (ChannelNumber == 2)
                    {
                        channels.Add("Eurosport 2");
                    }
                    if (ChannelNumber == 3)
                    {
                        channels.Add("Euronews");
                    }
                    if (ChannelNumber == 4)
                    {
                        channels.Add("Discovery Channel");
                    }
                    if (ChannelNumber == 5)
                    {
                        channels.Add("Science");
                    }
                    if (ChannelNumber == 6)
                    {
                        channels.Add("Science");
                    }
                    if (ChannelNumber == 7)
                    {
                        channels.Add("Animal Planet");
                    }
                    if (ChannelNumber == 8)
                    {
                        channels.Add("National Geographic channel");
                    }
                    if (ChannelNumber == 9)
                    {
                        channels.Add("Histiry");
                    }
                    if (ChannelNumber == 10)
                    {
                        channels.Add("MyNetworkTV");
                    }
                    if (ChannelNumber == 11)
                    {
                        channels.Add("Golf Channel");
                    }
                    if (ChannelNumber == 12)
                    {
                        channels.Add("Food Network");
                    }
                    if (ChannelNumber == 13)
                    {
                        channels.Add("Lifetime");
                    }
                    if (ChannelNumber == 14)
                    {
                        channels.Add("Comedy Central");
                    }
                    if (ChannelNumber == 15)
                    {
                        channels.Add("Disney Channe");
                    }
                    if (ChannelNumber == 16)
                    {
                        channels.Add("Cartoon Networ");
                    }
                    if (ChannelNumber == 17)
                    {
                        channels.Add("Fox");
                    }
                    ChannelNumber += 1;

                }

                СhangeTheСhannel();

            }
            return str;
        }

        public string ChannelListToStr()
        {

            string str = "\nСписок каналов: ";
            if (Status)
            {
                for (int i = 0; i < channels.Count; i++)
                {
                    str += "\n№" + i + " - " + channels[i];

                }
            }
            return str;
        }

        protected void СhangeTheСhannel()
        {

            if (channels.Count != 0)
            {
                if (CurrentChannel <= channels.Count && CurrentChannel >= 0)
                {
                    NameChannel = channels[CurrentChannel];
                }
                else
                {
                    NameChannel = "";
                }
            }
            else
            {
                NameChannel = "";
            }
        }
        public override string ToString()
        {

            return base.ToString() + "; громкость: " + CurrentVolume + "; текущий канал: " + CurrentChannel + ", \nИмя текущего канала: " + NameChannel + ";\n";
        }
    }
}
