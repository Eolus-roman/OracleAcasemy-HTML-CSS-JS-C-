using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseStaff
{
    class Menu
    {

        public ILog Log { get; set; }
        public void Show(IOperation operation, IReadFile read, ICheckFile check, IDrowTable draw)
        {
            // operation.Employees = check.CheckFile(Log, read);
            operation.Employees = check.TickFile(Log, read);
            string alias;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите команду: ");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "add":

                        Console.Clear();

                        Console.WriteLine("Введите псевдоним сотрудника: ");
                        alias = Console.ReadLine();

                        if (alias.Length >= 15)
                        {
                            Console.WriteLine("Приносим извенения, но ваш псевдоним слишком длинный.");
                            Console.ReadKey();
                            continue;
                        }

                        //if (operation.Employees.Exists(x => x.Alias == alias))
                        //{

                            string name;
                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("Введите имя сотрудника: ");
                                name = Console.ReadLine();
                                if (name.Length >= 16)
                                {
                                    Console.WriteLine("Приносим извенения, но имя слишком длинное слишком длинное. Пожалуйста, используйте сокращенную форму имени.");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    break;
                                }
                            }
                            string surname;
                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("Введите фамилию сотрудника: ");
                                surname = Console.ReadLine();
                                if (surname.Length >= 18)
                                {
                                    Console.WriteLine("Приносим извенения, но фамилия слишком длинное слишком длинное. Пожалуйста, используйте сокращенную форму фамилии.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            string department;
                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("Введите отдел сотрудника: ");
                                department = Console.ReadLine();
                                if (surname.Length >= 22)
                                {
                                    Console.WriteLine("Некорректный ввод названия отдела.");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    break;
                                }
                            }


                            string position;
                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("Введите дожность сотрудника: ");
                                position = Console.ReadLine();
                                if (surname.Length >= 20)
                                {
                                    Console.WriteLine("Некорректный наименования должности.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            operation.NewEmp(alias, name, surname, department, position);
                            Console.WriteLine("Сотрудник успешно добавлен в базу данных.");

                        //}
                        //else
                        //{
                        //    Console.WriteLine("Сотрудник с такими паспортными данными уже существует!");
                        //}


                        Console.ReadKey();
                        break;

                    case "delete":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите псевдоним сотрудника, которого вы хотите удалить");
                            alias = Console.ReadLine();
                            if (operation.Employees.Exists(x => x.Alias == alias))
                            {
                                operation.Delete(alias);
                                Console.WriteLine("Сотрудник был успешно удален с базы данных");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Сотрудника с таким псевдонимом не найдено.");
                                Console.ReadKey();
                                break;
                            }


                        }
                        break;
                    case "all":

                        Console.Clear();
                        Console.WriteLine(draw.MakeTableResults(operation.Employees));
                        Console.ReadKey();
                        break;
                    case "find":

                        Console.Clear();
                        Console.WriteLine("Введите псевдоним сотрудника, которого вы хотите найти");
                        alias = Console.ReadLine();
                        if (operation.Employees.Exists(x => x.Alias == alias))
                        {
                            operation.Delete(alias);
                            Console.WriteLine(operation.FindEmployee(alias).ToString());
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Сотрудника с таким псевдонимом не найдено.");
                            Console.ReadKey();
                            break;
                        }
                    case "exit":
                        if (read.ReadLine() == "XML")
                        {
                            Log = new LogXml();
                        }
                        if (read.ReadLine() == "BIN")
                        {
                            Log = new LogBinary();
                        }
                        Log.LogSave(operation.Employees);
                        return;
                }
                if (command.ToLower() != "add" && command.ToLower() != "delete" && command.ToLower() != "all" &&
                    command.ToLower() != "find" && command.ToLower() != "exit")
                {
                    Help();
                }

            }
        }
        private static void Help()
        {
            Console.WriteLine("\tДоступные команды:");
            Console.WriteLine("\nadd создать запись сотрудника");
            Console.WriteLine("delete - удалить запись сотрудника");
            Console.WriteLine("all - просмотреть все записи сотрудников");
            Console.WriteLine("find - просмотреть запись конкретного сотрудника");

            Console.WriteLine("\n \texit - выход");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }
}


