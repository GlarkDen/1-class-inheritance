using System;

namespace Lab_10
{
    public class Administration : Person
    {
        private byte countWorkers;
        private double rating;
        private string department;

        // Список подчинённых
        private Worker[] workers = new Worker[byte.MaxValue];

        // Список департаментов (отделов)
        private string[] departmentList = { "Производственный", "Обслуживающий", "Научный", 
            "Исследовательский", "Строительный", "Информационный" };

        /// <summary>
        /// Количество подчинённых
        /// </summary>
        public byte CountWorkers
        {
            get => countWorkers;
        }

        /// <summary>
        /// Рейтинг, выставляется подчинёнными
        /// </summary>
        public double Rating
        {
            get => rating;
            set
            {
                if (value > 10 || value < -10)
                    Console.WriteLine("Для вашего же удобства рейтинг оценивается по шкале от -10 до 10.");
                else
                    rating = value;
            }
        }

        /// <summary>
        /// Департамент
        /// </summary>
        public string Department
        {
            get => department;
            set
            {
                if (value.Length <= 3)
                    Console.WriteLine("Если вы покажете мне отдел с таким " +
                        "коротким названием, я выдам вам премию!");
                else
                    department = value;

            }
        }

        /// <summary>
        /// Издать указ
        /// </summary>
        /// <param name="text">Текст указа</param>
        public void IssueDecree(string text)
        {
            Console.WriteLine($"Сотрудник {Name} издаёт указ!");
            Console.WriteLine("Постановляю: ");
        }

        /// <summary>
        /// Нанять подчинённого
        /// </summary>
        /// <param name="worker">Подчинённый</param>
        public void AddWorker(Worker worker)
        {
            if (countWorkers < byte.MaxValue)
            {
                if (worker.Chief == null)
                {
                    workers[countWorkers++] = worker;
                    worker.AddChief(this, AdminPassword);
                }
                else if (worker.Chief == this)
                    Console.WriteLine("Вы уже являетесь начальником этого бедолаги");
                else
                    Console.WriteLine("Этот работник подчиняется другому начальнику.");
            }
            else
            {
                Console.WriteLine("Что-то многовато у него подчинённых...");
            }
        }

        /// <summary>
        /// Уволить подчинённого
        /// </summary>
        /// <param name="worker">Подчинённый</param>
        public void RemoveWorker(Worker worker)
        {
            if (this.HaveWorker(worker))
            {
                worker.RemoveChief(AdminPassword);

                int index = Array.IndexOf(workers, worker);

                if (index != countWorkers-1)
                    for (int i = 0; i < countWorkers - index - 1; i++)
                        workers[index + i] = workers[index + i + 1];

                workers[--countWorkers] = null;
            } 
            else
            {
                Console.WriteLine("В списке ваших подчинённых такого работника нет.");
            }
        }

        /// <summary>
        /// Показывает, подчиняется ли сотрудник этому начальнику
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool HaveWorker(Worker worker){
            if (Array.IndexOf(workers, worker) < 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Возвращает подчинённого из списка
        /// </summary>
        /// <param name="number">Порядковый номер</param>
        public Worker GetWorker(byte number)
        {
            if (number < countWorkers)
                return workers[number];
            else
                throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Возвращает список подчинённых
        /// </summary>
        /// <returns></returns>
        public Worker[] GetWorkers()
        {
            return workers;
        }

        /// <summary>
        /// Выводит список подчинённых начальника
        /// </summary>
        public void ShowWorkers()
        {
            if (countWorkers == 0)
                Console.WriteLine("У этого начальника нет подчинённых.");
            else
            {
                Console.WriteLine("Список подчинённых:");

                for (int i = 0; i < countWorkers; i++)
                    Console.WriteLine($"{i+1}){workers[i].GetInformation()}");
            }
        }

        /// <summary>
        /// Выдаёт подчинённому премию
        /// </summary>
        /// <param name="premium">Размер премии</param>
        /// <param name="worker">Подчинённый</param>
        /// <param name="text">Текст</param>
        public void GivePremium(double premium, Worker worker, string text = "")
        {
            int index = Array.IndexOf(workers, worker);
            if (index < 0)
                Console.WriteLine("К сожалению, у данного " +
                    "администротора нет такого подчинённого.");
            else
            {
                worker.Premium = premium;
                Console.WriteLine(text);
                Console.WriteLine($"Cотрудник {worker.Name}, поздравляем!");
            }      
        }

        /// <summary>
        /// Пишет подчинённому характеристику
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="worker">Подчинённый</param>
        public void WriteCharacteristic(string text, Worker worker)
        {
            int index = Array.IndexOf(workers, worker);
            if (index >= 0)
                worker.Characteristic = $"Характеристика от {Name}: {text}";
            else
                Console.WriteLine("В списке ваших подчинённых такого работника нет.");
        }

        /// <summary>
        /// Выдаёт подчинённому зарплату
        /// </summary>
        /// <param name="engineer"></param>
        public void GiveSalary(Engineer engineer)
        {
            int index = Array.IndexOf(workers, engineer);
            if (index >= 0)
                engineer.EarnedMoney = engineer.Salary * engineer.CountOperations;
            else
                Console.WriteLine("Вы точно хотите отдать свои деньги чужому работнику?");
        }

        /// <summary>
        /// Администратор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="workExperience">Рабочий стаж</param>
        /// <param name="summary">Резюме</param>
        /// <param name="department">Департамент</param>
        public Administration(string name = "unnamed", byte age = 0, byte workExperience = 0, 
            string summary = "empty", string department = "empty"): base(name, age, workExperience, summary)
        {
            Department = department;
        }

        /// <summary>
        /// Выводит в консоль имя, возраст, стаж работы, рейтинг и департамент
        /// </summary>
        public override void ShowInformation()
        {
            Console.WriteLine($"Имя: {name}, возраст: {age} {agePrint(age)}, стаж: {workExperience} {agePrint(workExperience)}.");
            Console.WriteLine($"Рейтинг: {rating}, отдел: {department}.");
        }

        /// <summary>
        /// Генерирует личные данные, департамент, рейтинг и список подчинённых
        /// </summary>
        public override void Init()
        {
            base.Init();

            department = departmentList[randomNumber.Next(0, departmentList.Length)];
            rating = Math.Round(randomNumber.NextDouble() * 2 * randomNumber.Next(-5, 6), 2);

            byte countNewWorkers = (byte)randomNumber.Next(2, 6);

            for (int i = 0; i < countNewWorkers; i++)
            {
                Worker worker = new Worker();
                AddWorker(worker);
                worker.Init();
            }
        }

        /// <summary>
        /// Возвращает тип объекта
        /// </summary>
        new public string GetObjectType()
        {
            return "Administration";
        }

        /// <summary>
        /// Возвращает тип хранимого объекта
        /// </summary>
        public override string GetObjectTypeVirtual()
        {
            return "Administration";
        }

        public override Administration Clone()
        {
            Administration admin = new Administration(name, age, workExperience, summary, department);
            admin.rating = rating;
            admin.countWorkers = countWorkers;
            Array.Copy(workers, admin.workers, workers.Length);

            return admin;
        }
    }
}
