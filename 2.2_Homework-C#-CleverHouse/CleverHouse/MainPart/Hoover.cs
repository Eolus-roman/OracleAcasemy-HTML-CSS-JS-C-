using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CleverHouse
{
    public class Hoover : Device, IResetSettings, IUse, ILevelChange     //пылесос
    {
        private CleanLvl cleaning;
        private bool lamp;
        private bool beep;
        public bool StatusDustCollector { get; set; }
        public Hoover(bool status, int dustCollector, int accumulator)
            : base(status)
        {
            DustCollector = dustCollector;
            Accumulator = accumulator;
        }
        public int Accumulator { get; set; }
        public int DustCollector { get; set; }
        public void ResetFirstParameter() //очистка пылесборника
        {
            StatusDustCollector = false;
            lamp = false;
            if (DustCollector != 0)
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; DustCollector < 1; i++)
                {
                    DustCollector -= 1;
                }
            }
        }
        public void ResetSecondParameter() //зарядка акамулятор
        {
            beep = false;
            if (Accumulator <= 100)
            {
                System.Threading.Thread.Sleep(2000);
                for (int i = 0; Accumulator == 100; i++)
                {
                    Accumulator += 1;
                }
            }
        }
        public void Apply()
        {
            if (StatusDustCollector == true && cleaning == CleanLvl.DailyMode)
            {
                System.Threading.Thread.Sleep(2000);
                for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                {
                    DustCollector += 2;
                    Accumulator -= 1;
                }
                if (DustCollector <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (Accumulator <= 0)
                {
                    beep = true;
                }
            }

            else if (StatusDustCollector == true && cleaning == CleanLvl.OutputMode)
            {

                System.Threading.Thread.Sleep(5000);
                for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                {
                    DustCollector += 5;
                    Accumulator -= 2;
                }
                if (DustCollector <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (Accumulator <= 0)
                {
                    beep = true;
                }
            }

            else if (StatusDustCollector == true && cleaning == CleanLvl.QuickCleanMode)
            {

                System.Threading.Thread.Sleep(1000);

                for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                {
                    DustCollector += 1;
                    Accumulator -= 3;
                }
                if (DustCollector <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (Accumulator <= 0)
                {
                    beep = true;
                }
            }

            else if (StatusDustCollector == true && cleaning == CleanLvl.TotalCleanMode)
            {

                System.Threading.Thread.Sleep(10000);
                for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                {
                    DustCollector += 10;
                    Accumulator -= 5;
                }
                if (DustCollector <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (Accumulator <= 0)
                {
                    beep = true;
                }
            }
        }
        public void FirstLvl() //QuickCleanMode
        {
            cleaning = CleanLvl.QuickCleanMode;
        }
        public void SecondLvl() //DailyMode
        {
            cleaning = CleanLvl.DailyMode;
        }
        public void ThirdLvl() //OutputMode
        {
            cleaning = CleanLvl.OutputMode;
        }
        public void FourthLvl() //TotalCleanMode
        {
            cleaning = CleanLvl.TotalCleanMode;
        }
        public override string ToString()
        {

            string statusDustCollector;
            if (StatusDustCollector)
            {
                statusDustCollector = "можно убирать";
            }
            else
            {
                statusDustCollector = "нуждается в очистке";
            }
            string mode;
            if (cleaning == CleanLvl.TotalCleanMode)
            {
                mode = "великая ежемесячная уборка";
            }
            else if (cleaning == CleanLvl.DailyMode)
            {
                mode = "каждодневная уборка";
            }

            else if (cleaning == CleanLvl.OutputMode)
            {
                mode = "большая еженедельная уборка";
            }
            else if (cleaning == CleanLvl.QuickCleanMode)
            {
                mode = "быстрая уборка";
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
            return base.ToString() + "; статус пылесборника: " + statusDustCollector + "; \nРежим работы: " + mode + "; заполненность пылесборника: " + DustCollector + "%" + "; \nСостояние лампочки: " + lamp + "; сигнал: " + beep + "\nСостояние акамулятора: " + Accumulator + "%" + "\n";
        }
    }
}
