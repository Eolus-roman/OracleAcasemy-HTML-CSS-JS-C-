using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class Menu
    {
        private IDictionary<string, Device> DevicesDictionary = new Dictionary<string, Device>();

        private int temp;
        private double t;
        public string Input { get; set; }
        public ICreate CN { get; set; }
        public void Show()
        {
            CN = new CreateNew();
           
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
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }
                if (commands.Length != 3)
                {
                    Help();
                    continue;
                }
                if (commands[1].ToLower() == "add" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    if (commands[0] == "FR")
                    {
                        DevicesDictionary.Add(commands[2], CN.NewFridge());
                        continue;
                    }
                    if (commands[0] == "TV")
                    {
                        DevicesDictionary.Add(commands[2], CN.NewTV());
                        continue;
                    }
                    if (commands[0] == "HR")
                    {
                        DevicesDictionary.Add(commands[2], CN.NewHoover());
                        continue;
                    }
                    if (commands[0] == "SB")
                    {
                        DevicesDictionary.Add(commands[2], CN.NewBicycle());
                        continue;
                    }
                    if (commands[0] == "WH")
                    {
                        DevicesDictionary.Add(commands[2], CN.NewGame());
                        continue;
                    }
                }
                if (commands[1].ToLower() == "add" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    continue;
                }
                if (commands[1].ToLower() == "delete" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Устройство с таким именем не существует!");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    continue;
                }
                if (!DevicesDictionary.ContainsKey(commands[2]))
                {
                    Help();
                    continue;
                }
                if (commands[1].ToLower() == "delete" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    DevicesDictionary.Remove(commands[2]);
                    continue;
                }
                switch (commands[1].ToLower())
                {
                    case "on":
                        DevicesDictionary[commands[2]].On();
                        break;
                    case "off":
                        DevicesDictionary[commands[2]].Off();
                        break;
                }
                //начало команд для телевизора
                if (DevicesDictionary[commands[2]] is ILinkChennel)
                {
                    ILinkChennel il = (ILinkChennel)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "link_ch":
                            Console.Clear();
                            Console.WriteLine(il.LinkChannel());
                            Console.ReadKey();
                            break;
                        case "list_ch":
                            Console.WriteLine(il.ListChannel());
                            Console.ReadKey();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is IChannel)
                {
                    IChannel ch = (IChannel)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
 
                        case "next_ch":
                            ch.NextChannel();
                            break;
                        case "previous_ch":
                            ch.PreviousChannel();
                            break;
                        case "set_ch":
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
                if (DevicesDictionary[commands[2]] is IVolume)
                {
                    IVolume vl = (IVolume)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "mute_vol":
                            vl.Mute();
                            break;
                        case "plus_vol":
                            vl.MaxVolume();
                            break;
                        case "minus_vol":
                            vl.MinVolume();
                            break;
                        case "set_vol":
                            Console.WriteLine("Введите желаемый уровень громкости в диапазоне от 0 до 100: ");
                            Input = Console.ReadLine();
                            if (Int32.TryParse(Input, out temp))
                            {
                                if (temp >= 0 && 100 <= temp)
                                {
                                    vl.SetVolume(temp);
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
                //конец команд для телевизора
                // начало команд для холодильника
                if (DevicesDictionary[commands[2]] is IOpenOrClose)
                {
                    IOpenOrClose rf = (IOpenOrClose)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "open":
                            rf.Open();
                            break;
                        case "close":
                            rf.Close();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is IFreezeMode)
                {
                    IFreezeMode rf = (IFreezeMode)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "freez":
                            rf.SetFreezing();
                            break;
                        case "default":
                            rf.SetDefault();
                            break;
                        case "defrost":
                            rf.SetDefrost();
                            break;
                        case "worm":
                            rf.SetDefrost();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ISetTemperature)
                {
                    ISetTemperature rf = (ISetTemperature)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "temp":
                            Console.WriteLine("Введите желаемую температуру (в диапазоне от -18 до +15): ");
                            Input = Console.ReadLine();
                            if (Double.TryParse(Input, out t))
                            {
                                if (t > -18 && t <15)
                                {
                                    Console.WriteLine("Eror! Недопустимое значение температуры.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    rf.SetTemperature(t);
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

                //конец команд для холодильника
                // начало команд для пылесоса
                if (DevicesDictionary[commands[2]] is ICleaning)
                {
                    ICleaning hr = (ICleaning)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "daily":
                            {
                                hr.DailyCleaning();
                                break;
                            }
                        case "weekend":
                            {
                                hr.WeekendCleaning();
                                break;
                            }
                        case "quick":
                            {
                                hr.QuickCleaning();
                                break;
                            }
                        case "big_cl":
                            {
                                hr.BigCleaning();
                                break;
                            }
                    }
                }
                if (DevicesDictionary[commands[2]] is ICharge)
                {
                    ICharge hr = (ICharge)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "clean_dc":
                            {
                                hr.CleaningDC();
                                break;
                            }
                        case "charging":
                            {
                                hr.Charging();
                                break;
                            }

                    }
                }
                //конец команд для пылесоса
                //начало команд для велотренажера
                if (DevicesDictionary[commands[2]] is IShiftRelief)
                {
                    IShiftRelief b = (IShiftRelief)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "highway":
                            {
                                b.Highway();
                                break;
                            }
                        case "hills":
                            {
                                b.Hills();
                                break;
                            }
                        case "dirt_road":
                            {
                                b.DirtRoad();
                                break;
                            }
                    }
                }
                if (DevicesDictionary[commands[2]] is ISpeed)
                {
                    ISpeed b = (ISpeed)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "low":
                            b.Low();
                            break;
                        case "unhur":
                            b.Unhurriedly();
                            break;
                        case "boost":
                            b.Boost();
                            break;
                        case "quick":
                            b.Quick();
                            break;
                        case "info":
                            b.ReportInfo();
                            Console.ReadKey();
                            break;

                    }
                }
                if (DevicesDictionary[commands[2]] is IRest)
                {
                    IRest b = (IRest)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "slow":
                            b.Slow();
                            break;
                        case "relax":
                            b.Relaxation();
                            break;
                    }
                }
                //конец команд для велотренажера
                // начало команд для Вархаммера
                if (DevicesDictionary[commands[2]] is IChooseBattlefield)
                {
                    IChooseBattlefield w = (IChooseBattlefield)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "space":
                            w.DoSpace();
                            break;
                        case "riot":
                            w.DoRiot();
                            break;
                        case "planet":
                            w.DoBattleForPlanet();
                            break;
                        case "hive":
                            w.DoBattleForWorldHive();
                            break;
                        case "chaos":
                            w.DoChaosBreakthrough();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is IBattle)
                {
                    IBattle w = (IBattle)DevicesDictionary[commands[2]];
                    switch (commands[1].ToLower())
                    {
                        case "play":
                            w.PlayBattle();
                            break;
                    }
                }
                // конец команд для Вархаммера
                //конец while
            }
        }
        // this help
        private static void Help()
        {
            Console.WriteLine("\tДоступные команды:");
            Console.WriteLine("TV add NameDevice - добавить телевизор");
            Console.WriteLine("FR add NameDevice - добавить холодильник");
            Console.WriteLine("HR add NameDevice - добавить пылесос.");
            Console.WriteLine("SB add NameDevice - добавить велотренажер.");
            Console.WriteLine("WH add NameDevice - добавить настольную игру Warhammer.");

            Console.WriteLine("\nDevice delete nameDevice");
            Console.WriteLine("Device on nameDevice");
            Console.WriteLine("Device off nameDevice");
            Console.WriteLine("\nде Devise - начальное наименование девайса. (TV, FR и т.д.) ");

            Console.WriteLine("\n\tКоманды для телевизора:");

            Console.WriteLine("TV list_ch NameDevice - показывает список телеканалов.");
            Console.WriteLine("TV next_ch NameDevice - следующий канал.");
            Console.WriteLine("TV previous_ch NameDevice - предыдущий канал.");
            Console.WriteLine("TV set_ch NameDevice - переход на конкретный канал.");
            Console.WriteLine("TV mute_vol NameDevice - выключить звук.");
            Console.WriteLine("TV plus_vol NameDevice - увеличить звук.");
            Console.WriteLine("TV minus_vol NameDevice - уменьшить звук.");
            Console.WriteLine("TV set_vol NameDevice - установить значение звука.");

            Console.WriteLine("\n \tКоманды для холодильника:");
            Console.WriteLine("FR open NameDevice - открыть холодильник.");
            Console.WriteLine("FR close NameDevice - закрыть холодильник.");
            Console.WriteLine("FR freez NameDevice - установить режим заморозки.");
            Console.WriteLine("FR default NameDevice - установить стандартный режим.");
            Console.WriteLine("FR defrost NameDevice - установить режим разморозки.");
            Console.WriteLine("FR temp NameDevice - Установить желаемую температуру.");

            Console.WriteLine("\n\tКоманды для пылесоса:");

            Console.WriteLine("HR daily NameDevice - установить режим ежедневной уборки.");
            Console.WriteLine("HR weekend NameDevice - установить режим еженедельной уборки.");
            Console.WriteLine("HR quick NameDevice - установить режим быстрой уборки.");
            Console.WriteLine("HR big_cl NameDevice - установить режим генеральной уборки.");
            Console.WriteLine("HR clean_dc NameDevice - очистить пылесборник.");
            Console.WriteLine("HR charging NameDevice - зарядить акамулятор.");

            Console.WriteLine("\n\tКоманды для велотренажера:");

            Console.WriteLine("SB info NameDevice - информация о установленном режиме.");
            Console.WriteLine("SB highway NameDevice - установить режим шоссе.");
            Console.WriteLine("SB hills NameDevice - установить режим холмистой местности.");
            Console.WriteLine("SB dirt_road NameDevice - установить режим грунтовой дороги.");
            Console.WriteLine("SB low NameDevice - медленная езда.");
            Console.WriteLine("SB unhur NameDevice - неторопливая езда.");
            Console.WriteLine("SB boost NameDevice - езда с ускорением.");
            Console.WriteLine("SB quick NameDevice - бустрая езда.");
            Console.WriteLine("SB slow NameDevice - сбросить скорость.");
            Console.WriteLine("SB relax NameDevice - отдохнуть, восстановить пульс.");

            Console.WriteLine("\n\tКоманды для настольной игры Warhammer:");
            Console.WriteLine("WH space NameDevice - установить карту 'Бескрайний Космос'.");
            Console.WriteLine("WH riot NameDevice - установить карту 'Зерна Ереси'.");
            Console.WriteLine("WH planet NameDevice - установить карту 'Битва за планету'.");
            Console.WriteLine("WH hive NameDevice - установить карту 'Нападение на Мир-Улей'.");
            Console.WriteLine("WH chaos NameDevice - установить карту 'Прорыв Хаоса'.");
            Console.WriteLine("WH play NameDevice - играть в Warhammer.");

            Console.WriteLine("\n\texit - выход.");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }

}

