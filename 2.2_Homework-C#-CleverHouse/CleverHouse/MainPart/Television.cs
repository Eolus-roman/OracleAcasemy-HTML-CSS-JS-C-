using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    public class Television : Device, IChannel, IVolume
    {
        private int maxChannel; // максимальное количество каналов
        private int currentVolume; // текущая громкость
        private int currentChannel; // текущий канал
        private int temp;
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
        protected void СhangeTheСhannel()
        {

            if (CurrentChannel <= channels.Count && CurrentChannel > 0)
            {
                namechannel = channels[CurrentChannel - 1];
            }
            else
            {
                namechannel = "канал не выбран";
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
        public string ListChannel()
        {
            channels = new List<string>();
            AddChannels();
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
        public virtual void AddChannels()
        {
            channels.Add("NBC");
            channels.Add("Eurosport");
            channels.Add("Eurosport 2");
            channels.Add("Euronews");
            channels.Add("Discovery Channel");
            channels.Add("Science");
            channels.Add("Animal Planet");
            channels.Add("National Geographic channel");
            channels.Add("Histiry");
            channels.Add("MyNetworkTV");
            channels.Add("Golf Channel");
            channels.Add("Food Network");
            channels.Add("Lifetime");
            channels.Add("Comedy Central");
            channels.Add("Disney Channe");
            channels.Add("Cartoon Networ");
            channels.Add("Fox");
        }

        public override string ToString()
        {

            return base.ToString() + "; громкость: " + CurrentVolume + "; текущий канал: " + CurrentChannel + ", \nИмя текущего канала: " + namechannel + "\n";
        }
    }
}
