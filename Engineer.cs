using System;

namespace Lab_10
{
    public class Engineer : Worker
    {
        private string profession;
        private string workPlace;
        private int countOperations;
        private double earnedMoney;

        // Список профессий
        private string[] professionList = { "Программист", "Сисадмин", "Механик", "Наладчик",
            "Конструктор", "Тестировщик", "Сварщик", "Литейщик", "Физик", "Химик", "Математик",
            "Чертёжник", "Электрик", "Оператор" };

        // Список рабочих мест
        private string[] workPlaceList = { "Офис", "Станок", "Цех", "Фабрика",
            "Мастерская", "Лаборатория", "Научная станция", "Сменное", "Серверная", "Склад",
            "Главный офис", "Прибор", "Охранное предприятие" };

        /// <summary>
        /// Профессия
        /// </summary>
        public string Profession
        {
            get => profession;
            set
            {
                if (value.Length > 30)
                {
                    Console.WriteLine("Насколько мне известно, у нас нет таких специальностей...");
                }
                else if (value.Length == 0)
                {
                    Console.WriteLine("Как вы думаете, какую зарплату получают такие рабочие?");
                }
                else
                {
                    bool isDigit = false;

                    foreach (char simbol in value)
                    {
                        if (char.IsDigit(simbol))
                        {
                            Console.WriteLine("Когда это специальности обрели нумерацию?");
                            isDigit = true;
                            break;
                        }
                    }

                    if (!isDigit)
                        profession = value;
                }
            }
        }

        /// <summary>
        /// Рабочее место
        /// </summary>
        public string WorkPlace
        {
            get => workPlace;
            set
            {
                if (value.Length < 5)
                    Console.WriteLine("Это вы где такое место нашли? Ну ка покажите!");
                else
                    workPlace = value;
            }
        }

        /// <summary>
        /// Выполненная работа
        /// </summary>
        public int CountOperations
        {
            get => countOperations;
        }

        /// <summary>
        /// Заработанные деньги
        /// </summary>
        public double EarnedMoney
        {
            get => earnedMoney;
            set
            {
                earnedMoney = value;
                countOperations = 0;
            }
        }

        /// <summary>
        /// Инженер и начальник
        /// </summary>
        /// <param name="chief">Начальник</param>
        /// <param name="profession">Профессия</param>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="workExperience">Рабочий стаж</param>
        /// <param name="summary">Резюме</param>
        public Engineer(Administration chief, string profession, string name = "unnamed", 
            byte age = 0,byte workExperience = 0, string summary = "empty"): base(chief, name, age, workExperience, summary)
        {
            Profession = profession;
        }

        /// <summary>
        /// Инженер
        /// </summary>
        public Engineer(string name = "unnamed", byte age = 0, 
            byte workExperience = 0, string summary = "empty")
            : base(name, age, workExperience, summary)
        {

        }

        /// <summary>
        /// Складывает целые числа
        /// </summary>
        /// <param name="numbers">Целые числа</param>
        /// <returns>Сумма чисел</returns>
        public long Sum(params int[] numbers)
        {
            if (Chief == null)
            {
                Console.WriteLine("Мне не на кого работать.");
                return 0;
            }

            long sum = 0;
            foreach (int number in numbers)
                sum += number;

            countOperations++;

            return sum;
        }

        /// <summary>
        /// Показывает информацию о сотруднике, его личные данные, профессию и место работы
        /// </summary>
        public override void ShowInformation()
        {
            base.ShowInformation();
            Console.WriteLine($"Профессия: {profession}, место работы: {workPlace}");
        }

        /// <summary>
        /// Генерирует личные данные, профессию и место работы сотрудника
        /// </summary>
        public override void Init()
        {
            base.Init();

            profession = professionList[randomNumber.Next(0, professionList.Length)];
            workPlace = workPlaceList[randomNumber.Next(0, workPlaceList.Length)];
        }

        /// <summary>
        /// Возвращает тип объекта
        /// </summary>
        new public string GetObjectType()
        {
            return "Engineer";
        }

        /// <summary>
        /// Возвращает тип хранимого объекта
        /// </summary>
        public override string GetObjectTypeVirtual()
        {
            return "Engineer";
        }

        public override Engineer Clone()
        {
            Engineer engineer = new Engineer(name, age, workExperience, summary);
            engineer.premium = premium;
            engineer.salary = salary;
            engineer.efficiency = efficiency;
            engineer.sociability = sociability;
            engineer.workTime = workTime;
            engineer.characteristic = characteristic;
            engineer.chief = chief;

            engineer.profession = profession;
            engineer.workPlace = workPlace;
            engineer.countOperations = countOperations;
            engineer.earnedMoney = earnedMoney;

            return engineer;
        }

    }
}
