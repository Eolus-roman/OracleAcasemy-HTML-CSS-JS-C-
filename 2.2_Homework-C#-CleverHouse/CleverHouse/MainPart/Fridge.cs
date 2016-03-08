using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    public class Fridge : Device, IOpenOrClose, ILevelChange, ISetTemperature
    {
        private bool lamp; // состояние лампочки
        private bool beep; // // сигнал
        private TemperatureLvl freeze; // режимы заморозки
        private double temperature; // значение температуры
        private double temp;

        public Fridge(bool status, bool statusDoor, double temperature)
            : base(status)
        {
            StatusOpen = statusDoor;
            Temperature = temperature;
        }
        public bool StatusOpen { get; set; }
        public double Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                if (value >= -18 && value <= 15)
                {
                    if (value > 5 && value <= 15)
                    {
                        freeze = TemperatureLvl.Defrost;
                        temperature = value;
                    }
                    if (value >= 0 && value <= 5)
                    {
                        freeze = TemperatureLvl.Default;
                        temperature = value;
                    }

                    if (value > 10 && value < 0)
                    {
                        freeze = TemperatureLvl.Freezing;
                        temperature = value;
                    }
                    if (value >= -10 && value <= -18)
                    {
                        freeze = TemperatureLvl.SuperFreezing;
                        temperature = value;
                    }
                }
            }
        }
        public void Open()
        {
            if (StatusOpen == false)
            {
                StatusOpen = true;
                lamp = true;
                if (Temperature >= -18 && Temperature <= 15)
                {
                    System.Threading.Thread.Sleep(1000);
                    for (int i = 0; Temperature < 6; i++)
                    {
                        Temperature += 0.25;
                    }
                }
                if (Temperature <= 6)
                {
                    beep = true;
                }
            }
        }
        public void Close()
        {
            if (StatusOpen)
            {
                StatusOpen = false;
                lamp = false;
                beep = false;
                if (Temperature > 3)
                {
                    for (int i = 0; Temperature > temp; i++)
                    {
                        Temperature -= 0.25;
                    }
                }
            }
        }
        public void FirstLvl() // режим  заморозки 
        {
            if (Status)
            {
                freeze = TemperatureLvl.Defrost;
                Temperature = 10;
                temp = Temperature;
            }
        }
        public void SecondLvl() // режим  заморозки 
        {
            if (Status)
            {
                freeze = TemperatureLvl.Default;
                Temperature = 3;
                temp = Temperature;
            }
        }
        public void ThirdLvl() // режим  заморозки 
        {
            if (Status)
            {
                freeze = TemperatureLvl.Freezing;
                Temperature = -5;
                temp = Temperature;
            }
        }
        public void FourthLvl() // режим  заморозки 
        {
            if (Status)
            {
                freeze = TemperatureLvl.SuperFreezing;
                Temperature = -13;
                temp = Temperature;
            }
        }


        public void SetTemperature(double input) // установить температуру холодильника
        {
            if (Status)
            {
                Temperature = input;
                temp = Temperature;
            }
        }
        public override string ToString()
        {

            string statusDoor;
            if (StatusOpen)
            {
                statusDoor = "открыта";
            }
            else
            {
                statusDoor = "закрыта";
            }

            string mode;
            if (freeze == TemperatureLvl.Default)
            {
                mode = "стандартный";
            }
            else if (freeze == TemperatureLvl.Freezing)
            {
                mode = "заморозка";
            }

            else if (freeze == TemperatureLvl.Defrost)
            {
                mode = "разморозка";
            }
            else
            {
                mode = "не определен";
            }

            string lamp;
            if (this.lamp)
            {
                lamp = "светится";
            }
            else
            {
                lamp = "не светится";
            }

            string beep;
            if (this.beep)
            {
                beep = "пиликает";
            }
            else
            {
                beep = "молчит";
            }

            return base.ToString() + "; статус двери: " + statusDoor + "; \nРежим работы: " + mode + "; значение температуры: " + Temperature + "; \nСостояние лампочки: " + lamp + "; сигнал: " + beep + ";\n";
        }
    }


}
