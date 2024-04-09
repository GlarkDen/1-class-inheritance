using System;

namespace Lab_10
{
    public abstract class Person : IInit, IComparable, ICloneable
    {
        public Random randomNumber = new Random();

        protected string name;
        protected byte age;
        protected byte workExperience;
        protected string summary;

        // Чтобы доступ к работнику имел только начальник
        private string adminPassword = "forexample123";

        /// <summary>
        /// Пароль администратора
        /// </summary>
        protected string AdminPassword { get => adminPassword; }

        // Список гласных
        private string vovels = "аеёуыяиоюэ";

        // Список имён
        private string[] nameList = { "Иван", "Юлия", "Анна", "Артём", "Дмитрий", "Валерий", "Василий", 
            "Дарья", "Валентин", "Владислав", "Вячеслав", "Денис", "Николай", "Александр", "Ольга", "Алексей",
            "Михаил", "Елена", "Марина", "Мария", "Маргарита", "Матвей", "Надежда", "Полина", "Пётр",
            "Павел", "Яков", "Егор", "Виктория", "Вера", "Виктор", "Вероника", "Людмила", "Лев", "Леонид"};

        // Список фамилий
        private string[] surnameList = { "Иванов", "Васильев", "Петров", "Жуков", "Давыдов", "Ефимов",
            "Козлов", "Кузнецов", "Яковлев", "Морозов", "Зайцев", "Крылов", "Щербаков", "Калинин", "Макаров",
            "Медведев", "Тарасов", "Савельев", "Гончаров", "Дроздов", "Нечаев", "Горбачёв", "Суслов", 
            "Маркелов", "Анохин", "Гущин", "Ермолов", "Рябинин", "Кукушкин", "Гагарин", "Акимов", "Никифоров",
            "Грачёв", "Герасимов", "Беляев" };

        // Список резюме
        private string[] summaryList = { "Работал(а) на заводе всю жизнь.", 
            "Был(а) руководителем крупной IT-компании.", 
            "Сажал(а) огурцы, помидоры и картошку, на жизнь хватало.", 
            "KFC - больше никуда не приняли.", 
            "Водил(а) такси 15 лет, пока не попался злой клиент." };

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 40)
                {
                    Console.WriteLine("Боюсь, с такими данными очень трудно работать.\n" +
                        "Нельзя ли как-нибудь сократить это имя?.");
                } 
                else if (value.Length == 0)
                {
                    Console.WriteLine("Коллеги, я, конечно, не против безымянного сотрудника,\n" +
                        "но зарплату ему платить не намерен.");
                }
                else if (value.Split().Length < 2)
                {
                    Console.WriteLine("Хотелось бы увидеть здесь хотя бы имя и фамилию.");
                }
                else
                {
                    bool isDigit = false;

                    foreach (char simbol in value)
                    {
                        if (char.IsDigit(simbol))
                        {
                            Console.WriteLine("Ух ты! Не знал, что у нас в компании работают роботы.");
                            isDigit = true;
                            break;
                        }
                    }

                    if (!isDigit)
                        name = value;
                }
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age
        {
            get => age;
            set
            {
                if (value <= 10)
                {
                    Console.WriteLine("В нашей компании есть сотрудник младше 10 лет?!");
                    Console.WriteLine("Считайте, что он уволен.");
                }
                else if (value >= 100)
                {
                    Console.WriteLine("Э, да у нас тут халявщик, надеюсь, вы предпримите меры.");
                }
                else
                {
                    age = value;
                }
            }
        }

        /// <summary>
        /// Рабочий стаж
        /// </summary>
        public byte WorkExperience
        {
            get => workExperience;
            set
            {
                if (value >= 50)
                {
                    Console.WriteLine("Мы уважаем старших коллег, но, кажется," +
                        " кому то пора на пенсию...");
                }
                else
                {
                    workExperience = value;
                }
            }
        }

        /// <summary>
        /// Резюме
        /// </summary>
        public string Summary
        {
            get => summary;
            set
            {
                if (value.Length < 10)
                {
                    Console.WriteLine("Что-то оно коротковато, вам так не кажется?");
                }
                else
                    summary = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public string Gender
        {
            get
            {
                if (name.Contains("а "))
                    return "Женщина";
                return "Мужчина";
            }
        }

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="workExperience">Рабочий стаж</param>
        /// <param name="summary">Резюме</param>
        public Person(string name = "unnamed", byte age = 0, 
            byte workExperience = 0, string summary = "empty")
        {
            this.name = name;
            this.age = age;
            this.workExperience = workExperience;
            this.summary = summary;
        }

        /// <summary>
        /// Возвращает имя, возраст и стаж работы
        /// </summary>
        public virtual string GetInformation()
        {
            return $"Имя: {name}, возраст: {age} {agePrint(age)}, стаж: {workExperience} {agePrint(workExperience)}";
        }

        /// <summary>
        /// Показывает информацию о человеке
        /// </summary>
        public abstract void ShowInformation();

        /// <summary>
        /// Рандомная генерация имени, резюме, возраста и рабочего стажа
        /// </summary>
        public virtual void Init()
        {
            string randomName = nameList[randomNumber.Next(0, nameList.Length)];
            string randomSurname = surnameList[randomNumber.Next(0, surnameList.Length)];
            string randomSummary = summaryList[randomNumber.Next(0, summaryList.Length)];

            if (vovels.Contains(randomName[randomName.Length - 1]))
            {
                randomSurname += "а";

                if (randomSummary.Contains("("))
                {
                    randomSummary = randomSummary.Replace("(", "");
                    randomSummary = randomSummary.Replace(")", "");
                }

            }
            else
            {
                if (randomSummary.Contains("("))
                    randomSummary = randomSummary.Remove(randomSummary.IndexOf("("), 3);
            }

            name = randomSurname + " " + randomName;
            summary = randomSummary;
            age = (byte)randomNumber.Next(20, 60);
            workExperience = (byte)randomNumber.Next(1, age-18);

        }

        /// <summary>
        /// Возвращает корректное написание слова "лет" для возраста
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <returns>К примеру: 9 "лет", 4 "года"</returns>
        protected string agePrint(byte age)
        {
            if ((age > 4) && (age < 21)) return "лет";
            else if (age % 10 == 0) return "лет";
            else if (age % 10 == 1) return "год";
            else if (age % 10 < 5) return "года";
            else return "лет";
        }

        /// <summary>
        /// Возвращает тип объекта
        /// </summary>
        public string GetObjectType()
        {
            return "Person";
        }

        /// <summary>
        /// Возвращает тип хранимого объекта
        /// </summary>
        public abstract string GetObjectTypeVirtual();

        /// <summary>
        /// Сравнивает текущий объект Person и переданный по рабочему стажу
        /// </summary>
        /// <param name="obj"></param>
        public int CompareTo(object obj)
        {
            if (obj is Person person)
                return workExperience.CompareTo(person.workExperience);
            else
                throw new Exception("NotCompareObj");
        }

        /// <summary>
        /// Полностью копирует объект
        /// </summary>
        public abstract object Clone();
    }
}
