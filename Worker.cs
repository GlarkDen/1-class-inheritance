using System;

namespace Lab_10
{
    public class Worker : Person
    {
        protected double sociability;
        protected double efficiency;
        protected double salary;
        protected byte workTime;
        protected string characteristic;

        protected Administration chief;
        protected double premium;

        // Список характеристик
        private string[] characteristicList = { 
            "Тот ещё лентяй(ка), ему(ей), к сожалению, никто не объяснил, что деньги нужно ЗАРАБАТЫВАТЬ!!!",
            "Работает исправно, не к чему придраться. Правда не очень общительный.",
            "Вроде и старается, видно, что хороший человек, но выходит у него пока плохо.",
            "Профи своего дела, явно идёт на повышение.",
            "Уже долгое время копает под начальство... уволить бы его(её)."};

        /// <summary>
        /// Начальник
        /// </summary>
        public Administration Chief
        {
            // При отсутствии можно кинуть Exception, чтобы сразу было видно
            get => chief;
        }

        /// <summary>
        /// Добавление начальника сотруднику (доступно только начальнику)
        /// </summary>
        /// <param name="chief">Начальник</param>
        /// <param name="password">Пароль администратора</param>
        public void AddChief(Administration chief, string password)
        {
            if (password == AdminPassword)
                this.chief = chief;
            else
                Console.WriteLine("Неверный пароль.");
        }

        /// <summary>
        /// Удаление начальника у сотрудника (доступно только начальнику)
        /// </summary>
        /// <param name="password">Пароль администратора</param>
        public void RemoveChief(string password)
        {
            if (password == AdminPassword)
                this.chief = null;
            else
                Console.WriteLine("Неверный пароль.");
        }

        /// <summary>
        /// Премия
        /// </summary>
        public double Premium
        {
            get => premium;
            set
            {
                if (value <= 0)
                    Console.WriteLine("Ну кто ж выдаёт такие премии?");
                else
                    premium += value;
            }
        }

        /// <summary>
        /// Коммуникабельность
        /// </summary>
        public double Sociability
        {
            get => sociability;
            set
            {
                if (value > 10 || value < -10)
                    Console.WriteLine("Для вашего же удобства коммуникабельность оценивается по шкале от -10 до 10.");
                else
                    sociability = value;
            }
        }

        /// <summary>
        /// Эффективность работы
        /// </summary>
        public double Efficiency
        {
            get => efficiency;
            set
            {
                if (value > 10 || value < -10)
                    Console.WriteLine("Для вашего же удобства эффективность оценивается по шкале от -10 до 10.");
                else
                    efficiency = value;
            }
        }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary
        {
            get => salary;
            set
            {
                if (value < 0)
                    Console.WriteLine("Как это, не мы им платим, а они нам?");
                else if (value == 0)
                    Console.WriteLine("Боюсь, на нас подадут в суд...");
                else
                    salary = value;
            }
        }

        /// <summary>
        /// Рабочий день (в часах)
        /// </summary>
        public byte WorkTime
        {
            get => workTime;
            set
            {
                if (value > 24)
                    Console.WriteLine("Увы, в сутках только 24 часа.");
                else
                    workTime = value;
            }
        }

        /// <summary>
        /// Характеристика
        /// </summary>
        public string Characteristic
        {
            get => characteristic;
            set
            {
                if (value.Length < 10)
                    Console.WriteLine("Как его приняли на работу? Он точно умеет писать?");
                else
                    characteristic += value + "\n\n"; 
            }
        }

        /// <summary>
        /// Поставить рейтинг начальнику
        /// </summary>
        /// <param name="rating">Рейтинг</param>
        public void SetChiefRating(double rating)
        {
            if (chief != null)
                chief.Rating = rating;
            else
                Console.WriteLine("У этого сотрудника пока нет руководителя.");
        }

        /// <summary>
        /// Уволиться
        /// </summary>
        public void QuitJob()
        {
            if (chief == null)
                Console.WriteLine("Дак вы же и так не работаете...");
            else
            {
                chief.RemoveWorker(this);
                chief = null;
            }
        }

        /// <summary>
        /// Рабочий и его начальник
        /// </summary>
        /// <param name="chief">Начальник</param>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="workExperience">Рабочий стажы</param>
        /// <param name="summary">Резюме</param>
        public Worker(Administration chief, string name = "unnamed", byte age = 0, 
            byte workExperience = 0, string summary = "empty") : base(name, age, workExperience, summary)
        {
            chief.AddWorker(this);
        }

        /// <summary>
        /// Рабочий
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="workExperience">Рабочий стажы</param>
        /// <param name="summary">Резюме</param>
        public Worker(string name = "unnamed", byte age = 0, 
            byte workExperience = 0, string summary = "empty")
            : base(name, age, workExperience, summary)
        {

        }

        /// <summary>
        /// Возвращает имя, возраст, стаж работы и имя начальника работника
        /// </summary>
        public override string GetInformation()
        {
            if (chief != null)
                return base.GetInformation() + $", начальник: {chief.Name}";
            else
                return base.GetInformation() + ", начальник ещё не был назначен";
        }

        /// <summary>
        /// Выводит в консоль имя, возраст, стаж работы и личную характеристику работника
        /// </summary>
        public override void ShowInformation()
        {;
            Console.WriteLine($"Имя: {name}, возраст: {age} {agePrint(age)}, стаж: {workExperience} {agePrint(workExperience)}.");
            Console.WriteLine($"Комуникабельность: {sociability}, эффективность: {efficiency}.");
            Console.WriteLine($"Характеристика: {characteristic}");
        }

        /// <summary>
        /// Рандомная герерация коммуникабельности, эффективности, зарплаты, рабочего стажа и характеристики
        /// </summary>
        public override void Init()
        {
            base.Init();

            sociability = Math.Round(randomNumber.NextDouble() * 2 * randomNumber.Next(-5, 6), 2);
            efficiency = Math.Round(randomNumber.NextDouble() * 2 * randomNumber.Next(-5, 6), 2);
            salary = Math.Round(randomNumber.NextDouble() * 100000, 2);
            workTime = (byte)randomNumber.Next(5, 15);

            characteristic = characteristicList[randomNumber.Next(0, characteristicList.Length)];

        }

        /// <summary>
        /// Возвращает тип объекта
        /// </summary>
        new public string GetObjectType()
        {
            return "Worker";
        }

        /// <summary>
        /// Возвращает тип хранимого объекта
        /// </summary>
        public override string GetObjectTypeVirtual()
        {
            return "Worker";
        }

        public override Worker Clone()
        {
            Worker worker = new Worker(name, age, workExperience, summary);
            worker.premium = premium;
            worker.salary = salary;
            worker.efficiency = efficiency;
            worker.sociability = sociability;
            worker.workTime = workTime;
            worker.characteristic = characteristic;

            if (chief == null)
                return worker;

            worker.chief = chief.Clone();

            return worker;
        }

        /// <summary>
        /// Поверхностно копирует объект
        /// </summary>
        public Worker Copy()
        {
            return (Worker)this.MemberwiseClone();
        }

    }
}
