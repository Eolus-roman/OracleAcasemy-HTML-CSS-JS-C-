using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    public class Television : Device, IChannel, IVolume, ILinkChennel
    {
        private bool chanLink; // настроены каналы или нет
        private int maxChannel; // максимальное количество каналов
        private int currentVolume; // текущая громкость
        private int currentChannel; // текущий канал
        private int temp;
        private int number = 0;
        private string namechannel; // название канала
        private List<string> channels;

        public Television(bool status, int maxChannel)
            : base(status)
        {
            MaxChannel = maxChannel;
        }

        public int MaxChannel { get; set; }
        public int CurrentVolume
        {
            get
            {
                return currentVolume;
            }
            set
            {
                if (value >= 0 && value <= MaxChannel)
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
                if (value <= MaxChannel && value > 0)
                {
                    currentChannel = value;
                }
            }
        }
        public override void On()
        {
            if (Status == false)
            {
                Status = true;
                LinkChannel();
                CurrentChannel = 1;
            }
        }

        public void MaxVolume()
        {
            if (Status)
            {
                if (CurrentVolume < 100)
                {
                    CurrentVolume += 5;
                }
            }
        }

        public void MinVolume()
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
        public string LinkChannel()
        {
            string str = "";
            if (Status)
            {
                channels = new List<string>();
                chanLink = true;
                
                for (int i = 0; i < MaxChannel; i++)
                {
                    str += "\n№" + number + ", Отклик канала - есть.";
                    if (number == 0)
                    {
                        channels.Add("NBC");
                    }
                    if (number == 1)
                    {
                        channels.Add("Eurosport");
                    }
                    if (number == 2)
                    {
                        channels.Add("Eurosport 2");
                    }
                    if (number == 3)
                    {
                        channels.Add("Euronews");
                    }
                    if (number == 4)
                    {
                        channels.Add("Discovery Channel");
                    }
                    if (number == 5)
                    {
                        channels.Add("Science");
                    }
                    if (number == 6)
                    {
                        channels.Add("Science");
                    }
                    if (number == 7)
                    {
                        channels.Add("Animal Planet");
                    }
                    if (number == 8)
                    {
                        channels.Add("National Geographic channel");
                    }
                    if (number == 9)
                    {
                        channels.Add("Histiry");
                    } 
                    if (number == 10)
                    {
                        channels.Add("MyNetworkTV");
                    } 
                    if (number == 11)
                    {
                        channels.Add("Golf Channel");
                    } 
                    if (number == 12)
                    {
                        channels.Add("Food Network");
                    }
                    if (number == 13)
                    {
                        channels.Add("Lifetime");
                    }
                    if (number == 14)
                    {
                        channels.Add("Comedy Central");
                    }
                    if (number == 15)
                    {
                        channels.Add("Disney Channe");
                    }
                    if (number == 16)
                    {
                        channels.Add("Cartoon Networ");
                    }
                    if (number == 17)
                    {
                        channels.Add("Fox");
                    }
                    number += 1;
                    
                }
                
                СhangeTheСhannel();

            }
            return str;
        }

        public string ListChannel()
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

            if (chanLink)
            {
                if (CurrentChannel <= channels.Count && CurrentChannel > 0)
                {
                    namechannel = channels[CurrentChannel - 1];
                }
                else
                {
                    namechannel = "";
                }
            }
            else
            {
                namechannel = "";
            }
        }
        public override string ToString()
        {
            
            return base.ToString() + "; громкость: " + CurrentVolume + "; текущий канал: " + CurrentChannel + ", \nИмя текущего канала: " + namechannel + ";\n";
        }
    }
}
