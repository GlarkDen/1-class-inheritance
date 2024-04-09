using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_10;

namespace Lab_10_MSTest
{
    [TestClass]
    public class Test_1
    {
        [TestMethod]
        public void Person()
        {
            Worker worker = new Worker("Анна Неволина", 35, 10, "Хм... Оно не короткое?");

            // Свойства абстрактного класса Person
            Assert.AreEqual(worker.Name, "Анна Неволина");
            Assert.AreEqual(worker.Age, 35);
            Assert.AreEqual(worker.WorkExperience, 10);
            Assert.AreEqual(worker.Summary, "Хм... Оно не короткое?");

            // Имя
            worker.Name = "Анна";
            worker.Name = "";
            worker.Name = "Анна Бип4Буп5";
            worker.Name = "Валентин Аааааааааааааааааааааааааааааааа";
            Assert.AreEqual(worker.Name, "Анна Неволина");

            // Возраст
            worker.Age = 200;
            worker.Age = 5;
            Assert.AreEqual(worker.Age, 35);

            // Рабочий стаж
            worker.WorkExperience = 100;
            Assert.AreEqual(worker.WorkExperience, 10);

            // Резюме
            worker.Summary = "Короткое";
            Assert.AreEqual(worker.Summary, "Хм... Оно не короткое?");

            // Пол
            Assert.AreEqual(worker.Gender, "Женщина");
            worker.Name = "Андрей Болконский";
            Assert.AreEqual(worker.Gender, "Мужчина");

            Assert.AreEqual(worker.GetInformation(), "Имя: Андрей Болконский, возраст: 35 лет, " +
                "стаж: 10 лет, начальник ещё не был назначен");

            // Тип
            Assert.AreEqual(((Person)worker).GetObjectType(), "Person");

            new Administration("Name Name").AddWorker(worker);
            Assert.AreEqual(worker.Chief.Name, "Name Name");

            // Сравнение
            Assert.IsTrue(worker.CompareTo(new Worker()) > 0);
            Assert.IsTrue(worker.CompareTo(new Worker(workExperience: 100)) < 0);
            Assert.IsTrue(worker.CompareTo(worker.Clone()) == 0);

            try
            {
                worker.CompareTo(1);
                Assert.IsTrue("testCompare" == "False");
            }
            catch
            {
                Assert.IsTrue("testCompare" == "testCompare");
            }

        }

        [TestMethod]
        public void Worker()
        {
            // Создание Worker с Admin
            Administration admin = new Administration("Интересное Имя");

            Worker worker = new Worker(admin, "Анна Неволина", 35, 10, "Хм... Оно не короткое?");

            // Проверка работы с Admin
            Administration newAdmin = new Administration("Имя Поинтереснее");

            worker.AddChief(newAdmin, "Пароль");
            worker.RemoveChief("Пароль");

            Assert.AreEqual(worker.Chief.Name, admin.Name);

            admin.RemoveWorker(worker);

            newAdmin.AddWorker(worker);

            Assert.AreEqual(worker.Chief.Name, newAdmin.Name);

            // Премия
            newAdmin.GivePremium(-10, worker);
            Assert.AreEqual(worker.Premium, 0);

            newAdmin.GivePremium(100.5, worker);
            Assert.AreEqual(worker.Premium, 100.5);

            // Коммуникабельность
            worker.Sociability = 100;
            worker.Sociability = -100;
            Assert.AreEqual(worker.Sociability, 0);

            worker.Sociability = 5.4;
            Assert.AreEqual(worker.Sociability, 5.4);

            // Эффекстивность
            worker.Efficiency = 100;
            worker.Efficiency = -100;
            Assert.AreEqual(worker.Efficiency, 0);

            worker.Efficiency = 5.4;
            Assert.AreEqual(worker.Efficiency, 5.4);

            // Зарплата
            worker.Salary = 0;
            worker.Salary = -100;
            Assert.AreEqual(worker.Salary, 0);

            worker.Salary = 5876.4;
            Assert.AreEqual(worker.Salary, 5876.4);

            // Рабочий день
            worker.WorkTime = 100;
            Assert.AreEqual(worker.WorkTime, 0);

            worker.WorkTime = 10;
            Assert.AreEqual(worker.WorkTime, 10);

            // Характеристика
            worker.Characteristic = "Характер";
            Assert.AreEqual(worker.Characteristic, null);

            newAdmin.WriteCharacteristic("Характеристика", worker);
            newAdmin.WriteCharacteristic("Характеристика", new Worker());
            Assert.AreEqual(worker.Characteristic, "Характеристика от Имя Поинтереснее: Характеристика\n\n");

            // Информация
            Assert.AreEqual(worker.GetInformation(), "Имя: Анна Неволина, возраст: 35 лет, стаж: 10 лет, начальник: Имя Поинтереснее");

            // Рейтинг
            worker.SetChiefRating(100);
            worker.SetChiefRating(-100);
            Assert.AreEqual(newAdmin.Rating, 0);

            worker.SetChiefRating(1.45);
            Assert.AreEqual(newAdmin.Rating, 1.45);

            // Увольнение
            worker.QuitJob();

            worker.SetChiefRating(-2);
            Assert.AreEqual(newAdmin.Rating, 1.45);

            Assert.AreEqual(worker.GetInformation(), "Имя: Анна Неволина, возраст: 35 лет, " +
                "стаж: 10 лет, начальник ещё не был назначен");

            worker.QuitJob();

            // Тип
            Assert.AreEqual(worker.GetObjectType(), "Worker");
            Assert.AreEqual(worker.GetObjectTypeVirtual(), ((Person)worker).GetObjectTypeVirtual(), "Worker");

            // Рандомная генерация
            Worker randomWorker = new Worker();
            randomWorker.Init();

            Assert.IsFalse(randomWorker.Name == "unnamed" || randomWorker.Age == 0 
                || randomWorker.WorkExperience == 0 || randomWorker.Summary == "");

            Assert.IsFalse(randomWorker.Salary == 0 || randomWorker.WorkTime == 0
                || randomWorker.Characteristic == "");

            // Клонирование
            Assert.IsTrue(randomWorker.CompareTo(randomWorker.Copy()) == 0);
            Assert.IsFalse(randomWorker.CompareTo(worker) == 0);

            // Глубокое копирование
            new Administration("Новый Шеф").AddWorker(randomWorker);

            Worker workerCopy = randomWorker.Clone();

            randomWorker.QuitJob();
            new Administration("Новый Новый Шеф").AddWorker(randomWorker);

            Assert.AreEqual(workerCopy.Chief.Name, "Новый Шеф");
            Assert.AreEqual(randomWorker.Chief.Name, "Новый Новый Шеф");

        }

        [TestMethod]
        public void Administrator()
        {
            Administration admin = new Administration();

            Worker worker = new Worker();
            worker.Init();

            // Количество работников
            Assert.AreEqual(admin.CountWorkers, 0);

            admin.AddWorker(worker);
            Assert.AreEqual(admin.CountWorkers, 1);

            // Департамент
            admin.Department = "Деп";
            Assert.AreEqual(admin.Department, "empty");

            admin.Department = "Финансовый";
            Assert.AreEqual(admin.Department, "Финансовый");

            // Издание указа
            admin.IssueDecree("Какой-то текст");

            // Найм подчинённого
            admin.AddWorker(worker);

            Worker workerAdd = new Worker();
            new Administration().AddWorker(workerAdd);

            admin.AddWorker(workerAdd);
            Assert.AreEqual(admin.CountWorkers, 1);

            for (int i = 0; i <= byte.MaxValue; i++)
                admin.AddWorker(new Worker());

            Assert.AreEqual(admin.CountWorkers, byte.MaxValue);

            // Увольнение подчинённого
            worker.QuitJob();
            admin = new Administration();
            admin.RemoveWorker(worker);

            admin.AddWorker(worker);
            admin.RemoveWorker(worker);
            Assert.AreEqual(admin.CountWorkers, 0);

            // Поиск подчинённого в списке сотрудников
            Assert.IsTrue(admin.HaveWorker(worker) == false);

            admin.AddWorker(worker);
            Assert.IsTrue(admin.HaveWorker(worker) == true);

            // Получение данных подчинённого из списка
            Assert.IsTrue(admin.GetWorker(0) != null);

            try
            {
                admin.GetWorker(100);
                Assert.IsTrue("CheckFalse" == "");
            }
            catch
            {
                Assert.IsTrue("CheckTrue" == "CheckTrue");
            }

            // Получение списка подчинённых
            Assert.IsTrue(admin.GetWorkers() != null);
            Assert.IsTrue(admin.GetWorkers()[0].Name == worker.Name);

            // Выдача премии подчинённому
            admin.GivePremium(10000, workerAdd);
            Assert.AreEqual(workerAdd.Premium, 0);

            admin.GivePremium(10000, worker);
            Assert.AreEqual(worker.Premium, 10000);

            // Выдача зарплаты подчинённому
            Engineer engineer = new Engineer();
            engineer.Salary = 1000;
            admin.AddWorker(engineer);

            engineer.Sum(5, 7);
            admin.GiveSalary(engineer);
            Assert.AreEqual(engineer.EarnedMoney, 1000);

            Engineer engineerAdd = new Engineer();
            engineerAdd.Salary = 1000;

            engineerAdd.Sum(5, 7);
            admin.GiveSalary(engineerAdd);
            Assert.IsTrue(engineerAdd.EarnedMoney == 0);

            // Конструктор класса
            admin = new Administration(department: "Налоговый");
            Assert.AreEqual(admin.Department, "Налоговый");

            // Рандомная генерация
            admin = new Administration();
            admin.Init();

            Assert.IsFalse(admin.Name == "unnamed" || admin.Age == 0
                || admin.WorkExperience == 0 || admin.Summary == "");

            Assert.IsFalse(admin.CountWorkers == 0 || admin.Rating == 0
                || admin.Department == "");

            Assert.IsTrue(admin.GetWorker(0) != null);

            // Тип
            Assert.AreEqual(admin.GetObjectType(), "Administration");
            Assert.AreEqual(admin.GetObjectTypeVirtual(), ((Person)admin).GetObjectTypeVirtual(), "Administration");

            // Клонирование
            Assert.IsTrue(admin.CompareTo(admin.Clone()) == 0);
            Assert.IsFalse(admin.CompareTo(worker) == 0);

        }

        [TestMethod]
        public void Engineer()
        {
            Engineer engineer = new Engineer();
            Engineer engineerAdd = new Engineer();
            
            Administration admin = new Administration();

            // Профессия
            engineer.Profession = "Конструктор";

            engineer.Profession = "";
            engineer.Profession = "Конструктор Бип4Буп5";
            engineer.Profession = "Контрукторское бюро технического отдела";

            Assert.AreEqual(engineer.Profession, "Конструктор");

            // Рабочее место
            engineer.WorkPlace = "Станок";
            engineer.WorkPlace = "Мир";

            Assert.AreEqual(engineer.WorkPlace, "Станок");

            // Выполненная работа, заработааные деньги, и суммирование
            engineer = new Engineer();
            admin.AddWorker(engineer);
            engineer.Salary = 12500;
            Assert.AreEqual(engineer.EarnedMoney, 0);
            Assert.AreEqual(engineer.CountOperations, 0);

            Assert.AreEqual(engineer.Sum(5, 7), 12);
            Assert.AreEqual(engineer.Sum(-5, 84), 79);

            Assert.AreEqual(engineer.CountOperations, 2);
            admin.GiveSalary(engineer);

            Assert.AreEqual(engineer.CountOperations, 0);
            Assert.AreEqual(engineer.EarnedMoney, 25000);

            // Конструктор класса
            admin = new Administration();
            engineer = new Engineer(admin, "Программист");
            Assert.IsTrue(engineer.Chief.Name == admin.Name & engineer.Profession == "Программист");

            // Рандомная генерация
            engineer = new Engineer();
            engineer.Init();

            Assert.IsFalse(engineer.Name == "unnamed" || engineer.Age == 0
                || engineer.WorkExperience == 0 || engineer.Summary == "");

            Assert.IsFalse(engineer.Profession == "empty" || engineer.WorkPlace == "");

            // Тип
            Assert.AreEqual(engineer.GetObjectType(), "Engineer");
            Assert.AreEqual(engineer.GetObjectTypeVirtual(), ((Person)engineer).GetObjectTypeVirtual(), "Engineer");

            // Клонирование
            Assert.IsTrue(engineer.CompareTo(engineer.Clone()) == 0);
            Assert.IsFalse(engineer.CompareTo(engineerAdd) == 0);

        }

        [TestMethod]
        public void Money()
        {
            Money money = new Money();

            // Конструктор класса и сумма
            money = new Money(10.4, 100.9, 8.3);
            Assert.AreEqual(money.Sum, 1679,9);

            // Рандомная генерация
            money = new Money();
            money.Init();

            Assert.IsFalse(money.Sum == 0);

        }

        [TestMethod]
        public void SortByName()
        {
            SortByName sort = new SortByName();

            Worker workerBig = new Worker("Андрей Иванов");

            Worker workerSmall = new Worker("Богдан Иванов");

            Assert.IsTrue(sort.Compare(workerBig, workerSmall) < 0);
            Assert.IsTrue(sort.Compare(workerSmall, workerBig) > 0);

            workerSmall.Name = "Андрей Иванов";
            Assert.IsTrue(sort.Compare(workerSmall, workerBig) == 0);

            try
            {
                sort.Compare(workerSmall, new Money());
                Assert.IsTrue("Check" == "False");
            }
            catch
            {
                Assert.IsTrue("Check" == "Check");
            }

            try
            {
                sort.Compare(new SortByName(), workerBig);
                Assert.IsTrue("Check" == "False");
            }
            catch
            {
                Assert.IsTrue("Check" == "Check");
            }
        }
    }
}
