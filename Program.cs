using System;

namespace Lab_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Для выбора пункта меню
            ConsoleKeyInfo answerKey;

            // Список операций
            PrintOperations();

            // Для перехода в следующее меню
            bool nextMenu = false;

            while (true)
            {
                // Вводим данные
                answerKey = Console.ReadKey(true);

                switch (answerKey.Key)
                {
                    case ConsoleKey.D1:
                        // Список операций
                        Console.Clear();
                        PrintOperations(1);
                        nextMenu = true;

                        while (nextMenu)
                        {
                            // Вводим данные
                            answerKey = Console.ReadKey(true);

                            switch (answerKey.Key)
                            {
                                // Запрос без виртуальных методов
                                case ConsoleKey.D1:
                                    PartOneNotVitrual();
                                    break;

                                // Запрос с виртуальными методами
                                case ConsoleKey.D2:
                                    PartOneVitrual();
                                    break;

                                case ConsoleKey.Backspace:
                                    Console.Clear();
                                    PrintOperations(1);
                                    break;

                                case ConsoleKey.Escape:
                                    nextMenu = false;
                                    Console.Clear();
                                    PrintOperations();
                                    break;
                            }
                        }

                        break;

                    case ConsoleKey.D2:
                        // Список операций
                        Console.Clear();
                        PrintOperations(2);
                        nextMenu = true;

                        while (nextMenu)
                        {
                            // Вводим данные
                            answerKey = Console.ReadKey(true);

                            switch (answerKey.Key)
                            {
                                case ConsoleKey.D1:
                                    PartTwoMenNames();
                                    break;

                                case ConsoleKey.D2:
                                    PartTwoWorkExperience();
                                    break;

                                case ConsoleKey.D3:
                                    PartTwoWorkPlace();
                                    break;

                                case ConsoleKey.D4:
                                    PartTwoProfession();
                                    break;

                                case ConsoleKey.D5:
                                    PartTwoEngineerCount();
                                    break;

                                case ConsoleKey.D6:
                                    PartTwoAdminWorkerCount();
                                    break;

                                case ConsoleKey.D7:
                                    PartTwoWorkTime();
                                    break;

                                case ConsoleKey.D8:
                                    PartTwoAll();
                                    break;

                                case ConsoleKey.Backspace:
                                    Console.Clear();
                                    PrintOperations(2);
                                    break;

                                case ConsoleKey.Escape:
                                    nextMenu = false;
                                    Console.Clear();
                                    PrintOperations();
                                    break;
                            }
                        }

                        break;

                    case ConsoleKey.D3:
                        // Список операций
                        Console.Clear();
                        PrintOperations(3);
                        nextMenu = true;

                        while (nextMenu)
                        {
                            // Вводим данные
                            answerKey = Console.ReadKey(true);

                            switch (answerKey.Key)
                            {
                                case ConsoleKey.D1:
                                    PartThreeShowIInit();
                                    break;

                                case ConsoleKey.D2:
                                    PartThreeIComparable();
                                    break;

                                case ConsoleKey.D3:
                                    PartThreeIComparer();
                                    break;

                                case ConsoleKey.D4:
                                    PartThreeCloneable();
                                    break;

                                case ConsoleKey.Backspace:
                                    Console.Clear();
                                    PrintOperations(3);
                                    break;

                                case ConsoleKey.Escape:
                                    nextMenu = false;
                                    Console.Clear();
                                    PrintOperations();
                                    break;
                            }
                        }

                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Выводит список доступных операций
        /// </summary>
        public static void PrintOperations(byte number = 0)
        {
            switch (number)
            {
                case 0:
                    Print.Yellow("Части задачи:");

                    Console.WriteLine("1) Часть 1");
                    Console.WriteLine("2) Часть 2");
                    Console.WriteLine("3) Часть 3");

                    Console.WriteLine("\nEsc) Выйти из программы");
                    break;

                case 1:
                    Print.Yellow("Выберете действие:");

                    Console.WriteLine("1) Запрос без виртуальных методов");
                    Console.WriteLine("2) Запрос с виртуальными методами");

                    Console.WriteLine("\nBackspace) Очистить консоль");
                    Console.WriteLine("Esc) Назад");
                    break;

                case 2:
                    Print.Yellow("Выберете действие:");

                    Console.WriteLine("1) 1. Имена всех лиц мужского пола.");
                    Console.WriteLine("2) 4. Имена служащих со стажем не менее заданного.");
                    Console.WriteLine("3) 6. Имена рабочих заданного цеха.");
                    Console.WriteLine("4) 7. Имена рабочих заданной профессии.");
                    Console.WriteLine("5) 9. Количество инженеров на заводе.");

                    Console.WriteLine("\n6) * Количество начальников, у которых больше 3 подчинённых.");
                    Console.WriteLine("7) * Имена рабочих, работающих меньше 10 часов в день.");

                    Console.WriteLine("\n8) Все остальные запросы.");

                    Console.WriteLine("\nBackspace) Очистить консоль");
                    Console.WriteLine("Esc) Назад");
                    break;

                case 3:
                    Print.Yellow("Выберете действие:");

                    Console.WriteLine("1) Печать массива IInit");
                    Console.WriteLine("2) Сортировка массива IInit при помощи IComparable");
                    Console.WriteLine("3) Сортировка массива IInit при помощи ICompare");
                    Console.WriteLine("4) Поверхностное клонирование и копирование");

                    Console.WriteLine("\nBackspace) Очистить консоль");
                    Console.WriteLine("Esc) Назад");
                    break;
            }

        }

        public static void PartOneNotVitrual()
        {
            Print.Border("БЕЗ VIRTUAL");

            Person[] persons = new Person[9];

            int i = 0;

            for (i = 0; i < 3; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                persons[i] = admin;
            }

            for (i = 3; i < 6; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                persons[i] = worker;
            }

            for (i = 6; i < 9; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                persons[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Person person in persons)
                Console.WriteLine("* " + person.GetObjectType());

            Print.Border();
        }

        public static void PartOneVitrual()
        {
            Print.Border("VIRTUAL");

            Person[] persons = new Person[9];

            int i = 0;

            for (i = 0; i < 3; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                persons[i] = admin;
            }

            for (i = 3; i < 6; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                persons[i] = worker;
            }

            for (i = 6; i < 9; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                persons[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Person person in persons)
                Console.WriteLine("* " + person.GetObjectTypeVirtual());

            Print.Border();
        }

        public static void PartTwoMenNames()
        {
            Print.Border("ИМЕНА МУЖЧИН");

            Person[] persons = new Person[9];

            int i = 0;

            for (i = 0; i < 3; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                persons[i] = admin;
            }

            for (i = 3; i < 6; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                persons[i] = worker;
            }

            for (i = 6; i < 9; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                persons[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Person person in persons)
            {
                if (person.Gender == "Мужчина")
                    Print.DarkGreen(person.Name);
                else
                    Console.WriteLine(person.Name);
            }

            Print.Border();
        }

        public static void PartTwoWorkExperience()
        {
            Print.Border("РАБОЧИЙ СТАЖ >= 7");

            Person[] persons = new Person[9];

            int i = 0;

            for (i = 0; i < 3; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                persons[i] = admin;
            }

            for (i = 3; i < 6; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                persons[i] = worker;
            }

            for (i = 6; i < 9; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                persons[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Person person in persons)
            {
                if (person.WorkExperience >= 7)
                    Print.DarkGreen(person.GetInformation());
                else
                    Console.WriteLine(person.GetInformation());
            }

            Print.Border();
        }

        public static void PartTwoWorkPlace()
        {
            Print.Border("РАБОЧЕЕ МЕСТО ОФИС");

            Engineer[] engineers = new Engineer[10];

            for (int i = 0; i < 10; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                engineers[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Engineer engineer in engineers)
            {
                if (engineer.WorkPlace == "Офис")
                    Print.DarkGreen(engineer.GetInformation() + ", " + engineer.WorkPlace);
                else
                    Console.WriteLine(engineer.GetInformation() + ", " + engineer.WorkPlace);
            }

            Print.Border();
        }

        public static void PartTwoProfession()
        {
            Print.Border("ПРОФЕССИЯ ФИЗИК");

            Engineer[] engineers = new Engineer[10];

            for (int i = 0; i < 10; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                engineers[i] = engineer;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Engineer engineer in engineers)
            {
                if (engineer.Profession == "Физик")
                    Print.DarkGreen(engineer.GetInformation() + ", " + engineer.Profession);
                else
                    Console.WriteLine(engineer.GetInformation() + ", " + engineer.Profession);
            }

            Print.Border();
        }

        public static void PartTwoEngineerCount()
        {
            Print.Border("КОЛИЧЕСТВО ИНЖЕНЕРОВ");

            Person[] persons = new Person[10];

            int i;
            int engineerCount = new Random().Next(1, 7);

            for (i = 0; i < engineerCount; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                persons[i] = engineer;
            }

            for (i = engineerCount; i < 10; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                persons[i] = admin;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Person person in persons)
            {
                if (person.GetObjectTypeVirtual() == new Engineer().GetObjectTypeVirtual())
                    Print.DarkGreen(person.GetType().ToString());
                else
                    Console.WriteLine(person.GetType());
            }

            Print.Border();
        }

        public static void PartTwoAdminWorkerCount()
        {
            Print.Border("НАЧАЛЬНИКИ У КОТОРЫХ БОЛЬШЕ 3 ПОДЧИНЁННЫХ");

            Administration[] admins = new Administration[10];

            for (int i = 0; i < 10; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                admins[i] = admin;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Administration admin in admins)
            {
                if (admin.CountWorkers > 3)
                    Print.DarkGreen(admin.GetInformation() + ", подчинённых: " + admin.CountWorkers);
                else
                    Console.WriteLine(admin.GetInformation() + ", подчинённых: " + admin.CountWorkers);
            }

            Print.Border();
        }

        public static void PartTwoWorkTime()
        {
            Print.Border("РАБОЧИЙ ДЕНЬ МЕНЬШЕ 10 ЧАСОВ");

            Worker[] workers = new Worker[10];

            for (int i = 0; i < 10; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                workers[i] = worker;
            }

            Print.Yellow("Просмотр массива:");

            foreach (Worker worker in workers)
            {
                if (worker.WorkTime < 10)
                    Print.DarkGreen(worker.GetInformation() + ", рабочий день: " 
                        + worker.WorkTime + " часов");
                else
                    Console.WriteLine(worker.GetInformation() + ", " + worker.WorkTime + " часов");
            }

            Print.Border();
        }

        public static void PartTwoAll()
        {
            Print.Border("ВСЕ ОСТАЛЬНЫЕ ЗАПРОСЫ");

            Worker worker = new Worker();
            worker.Init();

            Print.Yellow("От Person: ");

            Person person = worker;

            Console.WriteLine("Тип: " + person.GetObjectType());
            Console.WriteLine("Имя: " + person.Name);
            Console.WriteLine("Возраст: " + person.Age);
            Console.WriteLine("Рабочий стаж: " + person.WorkExperience);
            Console.WriteLine("Резюме: " + person.Summary);
            Console.WriteLine("Пол: " + person.Gender);

            Administration admin = new Administration();
            admin.Init();
            admin.AddWorker(worker);
            admin.GivePremium(25.5, worker, $"\nВаш начальник {admin.Name} выдал Вам премию.");

            Engineer engineer = new Engineer();
            engineer.Init();
            admin.AddWorker(engineer);

            Print.Yellow("\nОт Worker: ");

            Console.WriteLine("Тип: " + worker.GetObjectType());
            Console.WriteLine("Имя: " + worker.Name);
            Console.WriteLine("Коммуникабельность: " + worker.Sociability);
            Console.WriteLine("Эффективность: " + worker.Efficiency);
            Console.WriteLine("Зарплата: " + worker.Salary);
            Console.WriteLine("Рабочий день: " + worker.WorkTime);
            Console.WriteLine("Характеристика: " + worker.Characteristic);
            Console.WriteLine("Премия: " + worker.Premium);
            Console.WriteLine("Начальник: " + worker.Chief.Name);

            Print.Yellow("\nОт Administration: ");

            Console.WriteLine("Тип: " + admin.GetObjectType());
            Console.WriteLine("Имя: " + admin.Name);
            Console.WriteLine("Количество подчинённых: " + admin.CountWorkers);
            Console.WriteLine("Рейтинг: " + admin.Rating);
            Console.WriteLine("Департамент: " + admin.Department);

            Print.Yellow("\nПодчинённые: ");
            for (byte i = 0; i < admin.CountWorkers; i++)
                Console.WriteLine(admin.GetWorker(i).GetInformation());

            Print.Yellow("\nОт Engineer: ");

            Console.WriteLine("Тип: " + engineer.GetObjectType());
            Console.WriteLine("Имя: " + engineer.Name);
            Console.WriteLine("Профессия: " + engineer.Profession);
            Console.WriteLine("Место работы: " + engineer.WorkPlace);
            Console.WriteLine("Зарплата: " + engineer.Salary);

            Console.WriteLine("Я работаю, сумма: " + engineer.Sum(5, 6, 0, -3, 9, 10));
            Console.WriteLine("Выполненная работа: " + engineer.CountOperations);

            admin.GiveSalary(engineer);
            Console.WriteLine("Заработанные деньги: " + engineer.EarnedMoney);
            Console.WriteLine("Выполненная работа: " + engineer.CountOperations);

            Print.Border();
        }

        public static void PartThreeShowIInit()
        {
            Print.Border("СОЗДАНИЕ И ПРОСМОТР МАССИВА");

            Print.Yellow("Массив IInit:");

            IInit[] objects = new IInit[4];

            Money money = new Money();
            money.Init();
            objects[0] = money;

            Worker worker = new Worker();
            worker.Init();
            objects[1] = worker;

            Engineer engineer = new Engineer();
            engineer.Init();
            objects[2] = engineer;

            Administration admin = new Administration();
            admin.Init();
            objects[3] = admin;

            foreach (IInit obj in objects)
            {
                Print.Yellow("\n" + obj.GetType().ToString());
                obj.ShowInformation();
            }

            Print.Border();

        }

        public static void PartThreeIComparable()
        {
            Print.Border("СОРТИРОВКА МАССИВА");

            Print.Yellow("Массив IInit:");

            IInit[] objects = new IInit[9];

            int i;

            Print.Yellow("Workers:");

            for (i = 0; i < 3; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                objects[i] = worker;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Engineers:");

            for (i = 3; i < 6; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                objects[i] = engineer;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Administrators:");

            for (i = 6; i < 9; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                objects[i] = admin;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Отсортированный массив:");

            Array.Sort(objects);

            foreach (IInit obj in objects)
            {
                obj.ShowInformation();
                Console.WriteLine();
            }

            Print.Border();

        }

        public static void PartThreeIComparer()
        {
            Print.Border("СОРТИРОВКА МАССИВА");

            Print.Yellow("Массив IInit:");

            IInit[] objects = new IInit[9];

            int i;

            Print.Yellow("Workers:");

            for (i = 0; i < 3; i++)
            {
                Worker worker = new Worker();
                worker.Init();
                objects[i] = worker;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Engineers:");

            for (i = 3; i < 6; i++)
            {
                Engineer engineer = new Engineer();
                engineer.Init();
                objects[i] = engineer;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Administrators:");

            for (i = 6; i < 9; i++)
            {
                Administration admin = new Administration();
                admin.Init();
                objects[i] = admin;
                objects[i].ShowInformation();
                Console.WriteLine();
            }

            Print.Yellow("Отсортированный массив:");

            Array.Sort(objects, new SortByName());

            foreach (IInit obj in objects)
            {
                obj.ShowInformation();
                Console.WriteLine();
            }

            Print.Border();

        }

        public static void PartThreeCloneable()
        {
            Print.Border("ПОВЕРХНОСТНОЕ И ГЛУБОКОЕ КОПИРОВАНИЕ ОБЪЕКТОВ");

            Print.Yellow("ГЛУБОКОЕ КОПИРОВАНИЕ");
            Print.Yellow("Worker:");

            Worker workerOriginal = new Worker();
            workerOriginal.Init();
            workerOriginal.ShowInformation();
            Administration testAdmin = new Administration("Стив");
            testAdmin.AddWorker(workerOriginal);
            Console.WriteLine(workerOriginal.Chief.Name);

            Console.WriteLine();

            Worker workerCopy = workerOriginal.Clone();

            // Меняем имя начальника
            testAdmin.Name = "Эдуард Александрович";

            workerCopy.ShowInformation();
            Console.WriteLine(workerCopy.Chief.Name);

            Print.Yellow("\nПОВЕРХНОСТНОЕ КОПИРОВАНИЕ");

            Print.Yellow("Worker:");

            workerOriginal = new Worker();
            workerOriginal.Init();
            workerOriginal.ShowInformation();
            testAdmin = new Administration("Стив");
            testAdmin.AddWorker(workerOriginal);
            Console.WriteLine(workerOriginal.Chief.Name);

            Console.WriteLine();

            workerCopy = workerOriginal.Copy();

            // Меняем имя начальника
            testAdmin.Name = "Эдуард Александрович";

            workerCopy.ShowInformation();
            Console.WriteLine(workerCopy.Chief.Name);

            Print.Yellow("\nГЛУБОКОЕ КОПИРОВАНИЕ ОСТАЛЬНЫЕ КЛАССЫ");

            Print.Yellow("\nEngineer:");

            Engineer engineerOriginal = new Engineer();
            engineerOriginal.Init();
            engineerOriginal.ShowInformation();

            Console.WriteLine();

            Engineer engineerCopy = engineerOriginal.Clone();
            engineerCopy.ShowInformation();

            Print.Yellow("\nAdministranion:");

            Administration adminOriginal = new Administration();
            adminOriginal.Init();
            adminOriginal.ShowInformation();

            Console.WriteLine();

            Administration adminCopy = adminOriginal.Clone();
            adminCopy.ShowInformation();

            Print.Border();

        }
    }
}
