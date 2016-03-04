using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CleverHouse
{
    public class Hoover : Device, ICharge, ICleaning     //пылесос
    {
        private CleanLvl cleaning;
        private int accumulator = 100;
        private int dustFullLevel = 0;
        private bool lamp;
        private bool beep;
        public bool StatusDustCollector { get; set; }
        public Hoover(bool status, bool statusDustCollector)
            : base(status)
        {
            StatusDustCollector = statusDustCollector;
        }

        public void CleaningDC() //очистка пылесборника
        {
            StatusDustCollector = false;
            lamp = false;
            if (dustFullLevel != 0)
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; dustFullLevel < 1; i++)
                {
                    dustFullLevel -= 1;
                }
            }
        }
        public void Charging() //зарядка акамулятор
        {
            beep = false;
            if (accumulator <= 100)
            {
                System.Threading.Thread.Sleep(2000);
                for (int i = 0; accumulator == 100; i++)
                {
                    accumulator += 1;
                }
            }
        }
        public void DailyCleaning()
        {
            if (StatusDustCollector == true)
            {
                cleaning = CleanLvl.DailyMode;
                System.Threading.Thread.Sleep(2000);
                for (int i = 0, j = 0; dustFullLevel <= 100 || accumulator <= 0; i++, j++)
                {
                    dustFullLevel += 2;
                    accumulator -= 1;
                }
                if (dustFullLevel <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (accumulator <= 0)
                {
                    beep = true;
                }
            }
        }
        public void WeekendCleaning()
        {
            if (StatusDustCollector == true)
            {
                cleaning = CleanLvl.OutputMode;
                System.Threading.Thread.Sleep(5000);
                for (int i = 0, j = 0; dustFullLevel <= 100 || accumulator <= 0; i++, j++)
                {
                    dustFullLevel += 5;
                    accumulator -= 2;
                }
                if (dustFullLevel <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (accumulator <= 0)
                {
                    beep = true;
                }
            }
        }
        public void QuickCleaning()
        {
            if (StatusDustCollector == true)
            {
                cleaning = CleanLvl.QuickCleanMode;
                System.Threading.Thread.Sleep(1000);

                for (int i = 0, j = 0; dustFullLevel <= 100 || accumulator <= 0; i++, j++)
                {
                    dustFullLevel += 1;
                    accumulator -= 3;
                }
                if (dustFullLevel <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (accumulator <= 0)
                {
                    beep = true;
                }
            }
        }
        public void BigCleaning()
        {
            if (StatusDustCollector == true)
            {
                cleaning = CleanLvl.TotalCleanMode;
                System.Threading.Thread.Sleep(10000);
                for (int i = 0, j = 0; dustFullLevel <= 100 || accumulator <= 0; i++, j++)
                {
                    dustFullLevel += 10;
                    accumulator -= 5;
                }
                if (dustFullLevel <= 100)
                {
                    StatusDustCollector = false;
                    lamp = true;
                }
                if (accumulator <= 0)
                {
                    beep = true;
                }
            }
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
            return base.ToString() + "; статус пылесборника: " + statusDustCollector + "; \nРежим работы: " + mode + "; заполненность пылесборника: " + dustFullLevel + "%" + "; \nСостояние лампочки: " + lamp + "; сигнал: " + beep + "\nСостояние акамулятора: " + accumulator + "%" + "\n";
        }
    }
}
