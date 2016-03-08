using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHouse
{
    class Menu
    {
        private IDictionary<string, Device> DevicesDictionary = new Dictionary<string, Device>();

        private int temp;
        private double t;
        public string Input { get; set; }
        public ICreate CN { get; set; }

        public void Show(CreateNew CN)
        {
            DevicesDictionary.Add("TV", CN.NewTV());
            DevicesDictionary.Add("FR", CN.NewFridge());
            DevicesDictionary.Add("HR", CN.NewHoover());
            DevicesDictionary.Add("SB", CN.NewBicycle());
            DevicesDictionary.Add("WH", CN.NewGame());
            while (true)
            {
                Console.Clear();
                foreach (var dev in DevicesDictionary)
                {
                    Console.WriteLine(dev.Key + "." + dev.Value.ToString());
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');

                if (commands.Length == 1) // команды в одну строку
                {
                    if (commands[0] == "exit")
                    {
                        return;
                    }
                    if (commands[0] == "help")
                    {
                        Help();
                        continue;
                    }
                    if (commands[0] == "tv")
                    {
                        HeplTV();
                        continue;
                    }
                    if (commands[0] == "fr")
                    {
                        HelpFR();
                        continue;
                    }
                    if (commands[0] == "hr")
                    {
                        HelpHR();
                        continue;
                    }
                    if (commands[0] == "sb")
                    {
                        HelpSB();
                        continue;
                    }
                    if (commands[0] == "wh")
                    {
                        HelpWH();
                        continue;
                    }
                    else
                    {
                        Help();
                        continue;
                    }
                }
                if (commands.Length == 2)
                {
                    if (DevicesDictionary[commands[1]] is IStatus)
                    {
                        IStatus st = (IStatus)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "on":
                                st.On();
                                break;
                            case "off":
                                st.Off();
                                break;
                        }
                    }
                    if (commands[0].ToLower() == "delete" && DevicesDictionary.ContainsKey(commands[1]))
                    {
                        DevicesDictionary.Remove(commands[1]);
                        continue;
                    }
                    if (commands[0].ToLower() == "delete" && !DevicesDictionary.ContainsKey(commands[1]))
                    {
                        Console.WriteLine("Устройство с таким именем не существует!");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        continue;
                    }
                    if (!DevicesDictionary.ContainsKey(commands[1]))
                    {
                        Eror();
                        continue;
                    }


                    if (DevicesDictionary[commands[1]] is IResetSettings)
                    {
                        IResetSettings rs = (IResetSettings)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "down": //запускает очистку пылесборника, или сброс скорости
                                rs.ResetFirstParameter();
                                break;
                            case "relax": // запускает зарядку аккаулятора, или снижение пульса
                                rs.ResetSecondParameter();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is ILevelChange)
                    {
                        ILevelChange lc = (ILevelChange)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "first_lvl": // Hills, QuickCleanMode, Defrost, Space
                                lc.FirstLvl();
                                break;
                            case "second_lvl"://DirtRoad, DailyMode, Default, Riot
                                lc.SecondLvl();
                                break;
                            case "third_lvl": //Highway, OutputMode, Freezing, BattleForPlanet
                                lc.ThirdLvl();
                                break;
                            case "fourth_lvl": //VelodromeMode, TotalCleanMode, SuperFreezing, ChaosBreakthrough
                                lc.FourthLvl();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is IUse)
                    {
                        IUse u = (IUse)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "apply":
                                u.Apply();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is IOpenOrClose)
                    {
                        IOpenOrClose oc = (IOpenOrClose)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "open":
                                oc.Open();
                                break;
                            case "close":
                                oc.Close();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is ISetTemperature)
                    {
                        ISetTemperature st = (ISetTemperature)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "temp":
                                Console.WriteLine("Введите желаемую температуру (в диапазоне от -18 до +15): ");
                                Input = Console.ReadLine();
                                if (Double.TryParse(Input, out t))
                                {
                                    if (t > -18 && t < 15)
                                    {
                                        Console.WriteLine("Eror! Недопустимое значение температуры.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        st.SetTemperature(t);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Eror! Некорректный ввод температуры.");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is IChannel)
                    {
                        IChannel ch = (IChannel)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "next":
                                ch.NextChannel();
                                break;
                            case "prev":
                                ch.PreviousChannel();
                                break;
                            case "channel":
                                Console.WriteLine("Введите номер канала: ");
                                Input = Console.ReadLine();
                                if (Int32.TryParse(Input, out temp))
                                {
                                    if (temp < 0 && temp > ch.MaxChannel)
                                    {
                                        Console.WriteLine("Eror! Такого канала не существует!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        ch.GoToChannel(temp);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Eror! Некорректный ввод номера канала.");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is IVolume)
                    {
                        IVolume vol = (IVolume)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "mute":
                                vol.Mute();
                                break;
                            case "plus":
                                vol.PlusVolume();
                                break;
                            case "minus":
                                vol.MinusVolume();
                                break;
                            case "volume":
                                Console.WriteLine("Введите желаемый уровень громкости в диапазоне от 0 до 100: ");
                                Input = Console.ReadLine();
                                if (Int32.TryParse(Input, out temp))
                                {
                                    if (temp >= 0 && 100 <= temp)
                                    {
                                        vol.SetVolume(temp);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Eror! Недопустимое значение громкости!");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Eror! Некорректный ввод громкости.");
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is ISpeed)
                    {
                        ISpeed sp = (ISpeed)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "low":
                                sp.Low();
                                break;
                            case "unh":
                                sp.Unhurriedly();
                                break;
                            case "boost":
                                sp.Boost();
                                break;
                            case "quick":
                                sp.Quick();
                                break;
                            case "info":
                                sp.ReportInfo();
                                break;
                        }
                    }
                    if (DevicesDictionary[commands[1]] is ILinkChennel)
                    {
                        ILinkChennel lch = (ILinkChennel)DevicesDictionary[commands[1]];
                        switch (commands[0].ToLower())
                        {
                            case "link":
                                lch.LinkChannelList();
                                break;
                            case "list":
                                lch.ChannelListToStr();
                                break;
                        }
                    }


                } // конец строк в 2 команды
                if (commands.Length == 3)
                {
                    if (commands[0].ToLower() == "add" && !DevicesDictionary.ContainsKey(commands[2]))
                    {
                        if (commands[1] == "TV")
                        {
                            DevicesDictionary.Add(commands[2], CN.NewTV());
                            continue;
                        }
                        if (commands[1] == "fridge")
                        {
                            DevicesDictionary.Add(commands[2], CN.NewFridge());
                            continue;
                        }
                        if (commands[1] == "hoover")
                        {
                            DevicesDictionary.Add(commands[2], CN.NewHoover());
                            continue;
                        }
                        if (commands[1] == "bicycle")
                        {
                            DevicesDictionary.Add(commands[2], CN.NewBicycle());
                            continue;
                        }
                        if (commands[1] == "game")
                        {
                            DevicesDictionary.Add(commands[2], CN.NewGame());
                            continue;
                        }
                    }
                    if (commands[0].ToLower() == "add" && DevicesDictionary.ContainsKey(commands[2]))
                    {
                        Console.WriteLine("Устройство с таким именем уже существует");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        Eror();
                        continue;
                    }

                }// конец строк команд в 3 строки
                if (commands.Length > 3)
                {
                    Eror();
                    continue;
                }



                // конец while
            }
        }// конец метода Menu
        public void Help()
        {
            Console.WriteLine("\n\tСписок общих команд:");
            Console.WriteLine("add TV  NameTV - добавить Телевизор");
            Console.WriteLine("add fridge  NameFridge - добавить Холодильник");
            Console.WriteLine("add hoover NameHoover - добавить Пылесос.");
            Console.WriteLine("add bicycle NameBicycle - добавить Велотренажер.");
            Console.WriteLine("add game NameGame - добавить настольную игру Warhammer.");

            Console.WriteLine("\ndelete nameDevice");

            Console.WriteLine("\non nameDevice");
            Console.WriteLine("off nameDevice");

            Console.WriteLine("\ntv - команды для Телевизора");
            Console.WriteLine("fr - команды для Холодильника");
            Console.WriteLine("hr - команды для Пылесоса");
            Console.WriteLine("sb - команды для Велотренажера");
            Console.WriteLine("wh - команды для Warhammer's");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            // список общих команд команд
        }

        public void HeplTV()
        {
            Console.WriteLine("\tКоманды для Телевизора:");
            Console.WriteLine("\nlink NameTV - проверить связь с провайдером;");
            Console.WriteLine("list NameTV - получить список каналов от провайдера;");
            Console.WriteLine("next NameTV - следующий канал;");
            Console.WriteLine("prev NameTV - предыдущий канал;");
            Console.WriteLine("channel NameTV - перейти на канал;");
            Console.WriteLine("mute NameTV - установить безвучный режим;");
            Console.WriteLine("plus NameTV - увеличить звук;");
            Console.WriteLine("minus NameTV - уменьшить звук;");
            Console.WriteLine("volume NameTV - установить звук;");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        public void HelpFR()
        {
            Console.WriteLine("\tКоманды для Холодильника:");
            Console.WriteLine("\nopen NameFridge - открыть холодильник;");
            Console.WriteLine("close NameFridge - закрыть холодильник;");
            Console.WriteLine("temp NameFridge - установить температуру;");
            Console.WriteLine("first_lvl NameFridge - установить режим разморозки;");
            Console.WriteLine("second_lvl NameFridge - установить стандартный режим;");
            Console.WriteLine("third_lvl NameFridge - установить режим заморозки;");
            Console.WriteLine("fourth_lvl NameFridge - установить режим супер заморозки;");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        public void HelpHR()
        {
            Console.WriteLine("\tКоманды для Пылесоса:");
            Console.WriteLine("\napply NameHoover - запустить пылесос;");
            Console.WriteLine("down NameHoover - запустить очистку пылесборника;");
            Console.WriteLine("relax NameHoover -  начать зарядку аккумулятора;");
            Console.WriteLine("first_lvl NameHoover - установить режим быстрой уборки;");
            Console.WriteLine("second_lvl NameHoover - установить режим ежедневной уборки;");
            Console.WriteLine("third_lvl NameHoover - установить режим еженедельной уборки;");
            Console.WriteLine("fourth_lvl NameHoover - установить режим великой ежемесячной уборки;");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        public void HelpSB()
        {
            Console.WriteLine("\tКоманды для Велотренажера:");
            Console.WriteLine("\ndown NameHoover - сбросить скорость;");
            Console.WriteLine("relax NameHoover -  отдохнуть, для восстановления пульса;");
            Console.WriteLine("first_lvl NameHoover - установить режим холмистой местности;");
            Console.WriteLine("second_lvl NameHoover - установить режим грунтовой дороги;");
            Console.WriteLine("third_lvl NameHoover - установить режим шоссе;");
            Console.WriteLine("fourth_lvl NameHoover - установить режим  велотрек;");
            Console.WriteLine("low NameHoover - медленная езда;");
            Console.WriteLine("unh NameHoover - неторопливая езда;");
            Console.WriteLine("boost NameHoover - езда с ускорением;");
            Console.WriteLine("quick NameHoover - быстрая езда;");
            Console.WriteLine("info NameHoover - информация о режимах;");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        public void HelpWH()
        {
            Console.WriteLine("\tКоманды для настольной игры:");
            Console.WriteLine("\napply NameGame - начать игру;");
            Console.WriteLine("first_lvl NameGame - установить режим 'Бескрайний Космос';");
            Console.WriteLine("second_lvl NameGame - установить режим 'Зерна Ереси';");
            Console.WriteLine("third_lvl NameGame - установить режим 'Битва за планету';");
            Console.WriteLine("fourth_lvl NameGame - установить режим 'Прорыв Хаоса';");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
        public void Eror()
        {
            Console.WriteLine("\n\tКоманда была введена неправильно, или такой команды не существует");
            Console.WriteLine("\ntexit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }


    }
}
