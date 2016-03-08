using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class StationaryBicycle : Device, ISpeed, IResetSettings, ILevelChange//велотренажер с контролем пульса
    {
        private bool lamp; // состояние лампочки
        private int speed;
        public const int MAXPulse = 170;
        private ReliefLvl relief; // режимы заморозки


        public StationaryBicycle(bool status, int initialPulse)
            : base(status)
        {
            InitialPulse = initialPulse;
        }
        public int InitialPulse { get; set; }
        public void Low()
        {
            if (Status)
            {

                if (relief == ReliefLvl.HillsMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 10 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        InitialPulse += 2;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 15 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        InitialPulse += 2;
                    }
                }
                if (relief == ReliefLvl.HighwayMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 20 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        InitialPulse += 2;
                    }
                }
                if (relief == ReliefLvl.VelodromeMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 25 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 1;
                        InitialPulse += 2;
                    }
                }
            }
            else if (InitialPulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }

        }

        public void Unhurriedly()
        {
            if (Status)
            {

                if (relief == ReliefLvl.HillsMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 20 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        InitialPulse += 3;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 25 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        InitialPulse += 3;
                    }
                }
                if (relief == ReliefLvl.HighwayMode && InitialPulse <= MAXPulse)
                {

                    for (int i = 0, j = 0; speed < 30 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        InitialPulse += 3;
                    }
                }
                if (relief == ReliefLvl.VelodromeMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 35 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 2;
                        InitialPulse += 3;
                    }
                }

            }
            else if (InitialPulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }

        }

        public void Boost()
        {
            if (Status)
            {

                if (relief == ReliefLvl.HillsMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 30 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        InitialPulse += 4;
                    }
                }
                if (relief == ReliefLvl.DirtRoadMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 35 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        InitialPulse += 4;
                    }
                }
                if (relief == ReliefLvl.HighwayMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 40 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        InitialPulse += 4;
                    }
                }
                if (relief == ReliefLvl.VelodromeMode && InitialPulse <= MAXPulse)
                {
                    for (int i = 0, j = 0; speed < 45 && InitialPulse <= MAXPulse; i++, j++)
                    {
                        speed += 3;
                        InitialPulse += 4;
                    }
                }

            }
            else if (InitialPulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }

        }

        public void Quick()
        {
            if (relief == ReliefLvl.HillsMode && InitialPulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed < 40 && InitialPulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    InitialPulse += 5;
                }
            }

            if (relief == ReliefLvl.DirtRoadMode && InitialPulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed < 45 && InitialPulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    InitialPulse += 5;
                }
            }
            if (relief == ReliefLvl.HighwayMode && InitialPulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed < 50 && InitialPulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    InitialPulse += 5;
                }
            }
            if (relief == ReliefLvl.VelodromeMode && InitialPulse <= MAXPulse)
            {
                for (int i = 0, j = 0; speed < 55 && InitialPulse <= MAXPulse; i++, j++)
                {
                    speed += 4;
                    InitialPulse += 5;
                }
            }
            else if (InitialPulse >= MAXPulse)
            {
                lamp = true;
                Status = false;
            }

        }


        public void ResetFirstParameter() //relax
        {
            System.Threading.Thread.Sleep(1000);
            for (int i = 0; InitialPulse != 60; i++)
            {
                InitialPulse -= 1;
            }
            lamp = false;
        }
        public void ResetSecondParameter() //Slow
        {
            System.Threading.Thread.Sleep(1000);
            for (int i = 0; speed != 0; i++)
            {
                speed -= 1;
            }
        }
        public void FirstLvl() //Hills
        {
            relief = ReliefLvl.HillsMode;
        }
        public void SecondLvl() //DirtRoad
        {
            relief = ReliefLvl.DirtRoadMode;
        }
        public void ThirdLvl() //Highway
        {
            relief = ReliefLvl.HighwayMode;
        }
        public void FourthLvl() //VelodromeMode
        {
            relief = ReliefLvl.VelodromeMode;
        }

        public void ReportInfo()
        {
            if (relief == ReliefLvl.HighwayMode)
            {
                Console.WriteLine("\n\tИнформация о режиме 'шоссе'");
                Console.WriteLine("Максимальная скорость при скорости 'Low' - 20 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Unhurriedly' - 30 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Boost' - 40 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Quick' - 50 км/ч; ");

            }
            else if (relief == ReliefLvl.HillsMode)
            {
                Console.WriteLine("\n\tИнформация о режиме 'холмы'");
                Console.WriteLine("Максимальная скорость при скорости 'Low' - 10 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Unhurriedly' - 20 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Boost' - 30 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Quick' - 40 км/ч; ");
            }
            else if (relief == ReliefLvl.DirtRoadMode)
            {
                Console.WriteLine("\n\tИнформация о режиме 'холмы'");
                Console.WriteLine("Максимальная скорость при скорости 'Low' - 15 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Unhurriedly' - 25 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Boost' - 35 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Quick' - 45 км/ч; ");
            }
            else if (relief == ReliefLvl.DirtRoadMode)
            {
                Console.WriteLine("\n\tИнформация о режиме 'холмы'");
                Console.WriteLine("Максимальная скорость при скорости 'Low' - 15 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Unhurriedly' - 25 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Boost' - 35 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Quick' - 45 км/ч; ");
            }
            else if (relief == ReliefLvl.VelodromeMode)
            {
                Console.WriteLine("\n\tИнформация о режиме 'холмы'");
                Console.WriteLine("Максимальная скорость при скорости 'Low' - 25 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Unhurriedly' - 35 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Boost' - 45 км/ч; ");
                Console.WriteLine("Максимальная скорость при скорости 'Quick' - 55 км/ч; ");
            }
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
            else if (relief == ReliefLvl.VelodromeMode)
            {
                mode = "велотрек";
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

            return base.ToString() + "; \nРежим: " + mode + "; значение пульса: " + InitialPulse + "; скорость: " + speed + "; \nСостояние лампочки: " + lamp + "\n";
        }
    }


}

