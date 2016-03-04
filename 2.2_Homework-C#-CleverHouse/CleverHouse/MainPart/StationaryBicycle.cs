using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class StationaryBicycle : Device, ISpeed, IRest, IShiftRelief//велотренажер с контролем пульса
        
    {
        private bool lamp; // состояние лампочки

        private int pulse = 60;
     
        private int speed;
        public const int MAXPulse = 170;

        private ReliefLvl relief; // режимы заморозки
        public StationaryBicycle(bool status)
            : base(status)
        {
        }

        public void Low()
        {
            if (Status)
            {
                if (relief == ReliefLvl.HighwayMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 20 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        pulse += 1;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 15 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        pulse += 2;
                    }
                }
                if (relief == ReliefLvl.HillsMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 10 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        pulse += 2;
                    }
                }
            }
            else if (pulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; speed != 0; i++)
                {
                    speed -= 1;
                }
            }
        }

        public void Unhurriedly()
        {
            if (Status)
            {
                if (relief == ReliefLvl.HighwayMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 30 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        pulse += 2;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 25 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        pulse += 2;
                    }
                }
                if (relief == ReliefLvl.HillsMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 20 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        pulse += 4;
                    }
                }
            }
            else if (pulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; speed != 0; i++)
                {
                    speed -= 1;
                }
            }
        }

        public void Boost()
        {
            if (Status)
            {
                if (relief == ReliefLvl.HighwayMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 40 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        pulse += 3;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 35 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        pulse += 4;
                    }
                }
                if (relief == ReliefLvl.HillsMode && pulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed <= 30 && pulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        pulse += 5;
                    }
                }
            }
            else if (pulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; speed != 0; i++)
                {
                    speed -= 1;
                }
            }
        }

        public void Quick()
        {
            if (relief == ReliefLvl.HighwayMode && pulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed <= 50 && pulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    pulse += 4;
                }
            }
            if (relief == ReliefLvl.DirtRoadMode && pulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed <= 45 && pulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    pulse += 5;
                }
            }
            if (relief == ReliefLvl.HillsMode && pulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed <= 40 && pulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    pulse += 6;
                }
            }
            else if (pulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; speed != 0; i++)
                {
                    speed -= 1;
                }
            }
        }
        public void Slow()
        {
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; speed != 0; i++)
            {
                speed -= 1;
            }
        }

        public void Relaxation()
        {
            System.Threading.Thread.Sleep(2000);
            for (int i = 0; pulse != 60; i++)
            {
                pulse -= 1;
            }
            lamp = false;
        }

        public void Highway()
        {
            relief = ReliefLvl.HighwayMode;
        }

        public void Hills()
        {
            relief = ReliefLvl.HillsMode;
        }

        public void DirtRoad()
        {
            relief = ReliefLvl.DirtRoadMode;
        }
        public override string ToString()
        {
            string mode;
            if (relief == ReliefLvl.HighwayMode)
            {
                mode = "шоссе";
            }
            else if (relief == ReliefLvl.HillsMode)
            {
                mode = "холмы";
            }
            else if (relief == ReliefLvl.DirtRoadMode)
            {
                mode = "грунтовая дорога";
            }
            else
            {
                mode = "не определен";
            }

            string lamp;
            if (this.lamp)
            {
                lamp = "горит";
            }
            else
            {
                lamp = "не горит";
            }

            return base.ToString() + "; \nРежим: " + mode + "; значение пульса: " + pulse + "; скорость: " + speed + "; \nСостояние лампочки: " + lamp + "\n";
        }
    }


}

