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
            Worker worker = new Worker("���� ��������", 35, 10, "��... ��� �� ��������?");

            // �������� ������������ ������ Person
            Assert.AreEqual(worker.Name, "���� ��������");
            Assert.AreEqual(worker.Age, 35);
            Assert.AreEqual(worker.WorkExperience, 10);
            Assert.AreEqual(worker.Summary, "��... ��� �� ��������?");

            // ���
            worker.Name = "����";
            worker.Name = "";
            worker.Name = "���� ���4���5";
            worker.Name = "�������� ��������������������������������";
            Assert.AreEqual(worker.Name, "���� ��������");

            // �������
            worker.Age = 200;
            worker.Age = 5;
            Assert.AreEqual(worker.Age, 35);

            // ������� ����
            worker.WorkExperience = 100;
            Assert.AreEqual(worker.WorkExperience, 10);

            // ������
            worker.Summary = "��������";
            Assert.AreEqual(worker.Summary, "��... ��� �� ��������?");

            // ���
            Assert.AreEqual(worker.Gender, "�������");
            worker.Name = "������ ����������";
            Assert.AreEqual(worker.Gender, "�������");

            Assert.AreEqual(worker.GetInformation(), "���: ������ ����������, �������: 35 ���, " +
                "����: 10 ���, ��������� ��� �� ��� ��������");

            // ���
            Assert.AreEqual(((Person)worker).GetObjectType(), "Person");

            new Administration("Name Name").AddWorker(worker);
            Assert.AreEqual(worker.Chief.Name, "Name Name");

            // ���������
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
            // �������� Worker � Admin
            Administration admin = new Administration("���������� ���");

            Worker worker = new Worker(admin, "���� ��������", 35, 10, "��... ��� �� ��������?");

            // �������� ������ � Admin
            Administration newAdmin = new Administration("��� ������������");

            worker.AddChief(newAdmin, "������");
            worker.RemoveChief("������");

            Assert.AreEqual(worker.Chief.Name, admin.Name);

            admin.RemoveWorker(worker);

            newAdmin.AddWorker(worker);

            Assert.AreEqual(worker.Chief.Name, newAdmin.Name);

            // ������
            newAdmin.GivePremium(-10, worker);
            Assert.AreEqual(worker.Premium, 0);

            newAdmin.GivePremium(100.5, worker);
            Assert.AreEqual(worker.Premium, 100.5);

            // ������������������
            worker.Sociability = 100;
            worker.Sociability = -100;
            Assert.AreEqual(worker.Sociability, 0);

            worker.Sociability = 5.4;
            Assert.AreEqual(worker.Sociability, 5.4);

            // ��������������
            worker.Efficiency = 100;
            worker.Efficiency = -100;
            Assert.AreEqual(worker.Efficiency, 0);

            worker.Efficiency = 5.4;
            Assert.AreEqual(worker.Efficiency, 5.4);

            // ��������
            worker.Salary = 0;
            worker.Salary = -100;
            Assert.AreEqual(worker.Salary, 0);

            worker.Salary = 5876.4;
            Assert.AreEqual(worker.Salary, 5876.4);

            // ������� ����
            worker.WorkTime = 100;
            Assert.AreEqual(worker.WorkTime, 0);

            worker.WorkTime = 10;
            Assert.AreEqual(worker.WorkTime, 10);

            // ��������������
            worker.Characteristic = "��������";
            Assert.AreEqual(worker.Characteristic, null);

            newAdmin.WriteCharacteristic("��������������", worker);
            newAdmin.WriteCharacteristic("��������������", new Worker());
            Assert.AreEqual(worker.Characteristic, "�������������� �� ��� ������������: ��������������\n\n");

            // ����������
            Assert.AreEqual(worker.GetInformation(), "���: ���� ��������, �������: 35 ���, ����: 10 ���, ���������: ��� ������������");

            // �������
            worker.SetChiefRating(100);
            worker.SetChiefRating(-100);
            Assert.AreEqual(newAdmin.Rating, 0);

            worker.SetChiefRating(1.45);
            Assert.AreEqual(newAdmin.Rating, 1.45);

            // ����������
            worker.QuitJob();

            worker.SetChiefRating(-2);
            Assert.AreEqual(newAdmin.Rating, 1.45);

            Assert.AreEqual(worker.GetInformation(), "���: ���� ��������, �������: 35 ���, " +
                "����: 10 ���, ��������� ��� �� ��� ��������");

            worker.QuitJob();

            // ���
            Assert.AreEqual(worker.GetObjectType(), "Worker");
            Assert.AreEqual(worker.GetObjectTypeVirtual(), ((Person)worker).GetObjectTypeVirtual(), "Worker");

            // ��������� ���������
            Worker randomWorker = new Worker();
            randomWorker.Init();

            Assert.IsFalse(randomWorker.Name == "unnamed" || randomWorker.Age == 0 
                || randomWorker.WorkExperience == 0 || randomWorker.Summary == "");

            Assert.IsFalse(randomWorker.Salary == 0 || randomWorker.WorkTime == 0
                || randomWorker.Characteristic == "");

            // ������������
            Assert.IsTrue(randomWorker.CompareTo(randomWorker.Copy()) == 0);
            Assert.IsFalse(randomWorker.CompareTo(worker) == 0);

            // �������� �����������
            new Administration("����� ���").AddWorker(randomWorker);

            Worker workerCopy = randomWorker.Clone();

            randomWorker.QuitJob();
            new Administration("����� ����� ���").AddWorker(randomWorker);

            Assert.AreEqual(workerCopy.Chief.Name, "����� ���");
            Assert.AreEqual(randomWorker.Chief.Name, "����� ����� ���");

        }

        [TestMethod]
        public void Administrator()
        {
            Administration admin = new Administration();

            Worker worker = new Worker();
            worker.Init();

            // ���������� ����������
            Assert.AreEqual(admin.CountWorkers, 0);

            admin.AddWorker(worker);
            Assert.AreEqual(admin.CountWorkers, 1);

            // �����������
            admin.Department = "���";
            Assert.AreEqual(admin.Department, "empty");

            admin.Department = "����������";
            Assert.AreEqual(admin.Department, "����������");

            // ������� �����
            admin.IssueDecree("�����-�� �����");

            // ���� �����������
            admin.AddWorker(worker);

            Worker workerAdd = new Worker();
            new Administration().AddWorker(workerAdd);

            admin.AddWorker(workerAdd);
            Assert.AreEqual(admin.CountWorkers, 1);

            for (int i = 0; i <= byte.MaxValue; i++)
                admin.AddWorker(new Worker());

            Assert.AreEqual(admin.CountWorkers, byte.MaxValue);

            // ���������� �����������
            worker.QuitJob();
            admin = new Administration();
            admin.RemoveWorker(worker);

            admin.AddWorker(worker);
            admin.RemoveWorker(worker);
            Assert.AreEqual(admin.CountWorkers, 0);

            // ����� ����������� � ������ �����������
            Assert.IsTrue(admin.HaveWorker(worker) == false);

            admin.AddWorker(worker);
            Assert.IsTrue(admin.HaveWorker(worker) == true);

            // ��������� ������ ����������� �� ������
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

            // ��������� ������ ����������
            Assert.IsTrue(admin.GetWorkers() != null);
            Assert.IsTrue(admin.GetWorkers()[0].Name == worker.Name);

            // ������ ������ �����������
            admin.GivePremium(10000, workerAdd);
            Assert.AreEqual(workerAdd.Premium, 0);

            admin.GivePremium(10000, worker);
            Assert.AreEqual(worker.Premium, 10000);

            // ������ �������� �����������
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

            // ����������� ������
            admin = new Administration(department: "���������");
            Assert.AreEqual(admin.Department, "���������");

            // ��������� ���������
            admin = new Administration();
            admin.Init();

            Assert.IsFalse(admin.Name == "unnamed" || admin.Age == 0
                || admin.WorkExperience == 0 || admin.Summary == "");

            Assert.IsFalse(admin.CountWorkers == 0 || admin.Rating == 0
                || admin.Department == "");

            Assert.IsTrue(admin.GetWorker(0) != null);

            // ���
            Assert.AreEqual(admin.GetObjectType(), "Administration");
            Assert.AreEqual(admin.GetObjectTypeVirtual(), ((Person)admin).GetObjectTypeVirtual(), "Administration");

            // ������������
            Assert.IsTrue(admin.CompareTo(admin.Clone()) == 0);
            Assert.IsFalse(admin.CompareTo(worker) == 0);

        }

        [TestMethod]
        public void Engineer()
        {
            Engineer engineer = new Engineer();
            Engineer engineerAdd = new Engineer();
            
            Administration admin = new Administration();

            // ���������
            engineer.Profession = "�����������";

            engineer.Profession = "";
            engineer.Profession = "����������� ���4���5";
            engineer.Profession = "�������������� ���� ������������ ������";

            Assert.AreEqual(engineer.Profession, "�����������");

            // ������� �����
            engineer.WorkPlace = "������";
            engineer.WorkPlace = "���";

            Assert.AreEqual(engineer.WorkPlace, "������");

            // ����������� ������, ������������ ������, � ������������
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

            // ����������� ������
            admin = new Administration();
            engineer = new Engineer(admin, "�����������");
            Assert.IsTrue(engineer.Chief.Name == admin.Name & engineer.Profession == "�����������");

            // ��������� ���������
            engineer = new Engineer();
            engineer.Init();

            Assert.IsFalse(engineer.Name == "unnamed" || engineer.Age == 0
                || engineer.WorkExperience == 0 || engineer.Summary == "");

            Assert.IsFalse(engineer.Profession == "empty" || engineer.WorkPlace == "");

            // ���
            Assert.AreEqual(engineer.GetObjectType(), "Engineer");
            Assert.AreEqual(engineer.GetObjectTypeVirtual(), ((Person)engineer).GetObjectTypeVirtual(), "Engineer");

            // ������������
            Assert.IsTrue(engineer.CompareTo(engineer.Clone()) == 0);
            Assert.IsFalse(engineer.CompareTo(engineerAdd) == 0);

        }

        [TestMethod]
        public void Money()
        {
            Money money = new Money();

            // ����������� ������ � �����
            money = new Money(10.4, 100.9, 8.3);
            Assert.AreEqual(money.Sum, 1679,9);

            // ��������� ���������
            money = new Money();
            money.Init();

            Assert.IsFalse(money.Sum == 0);

        }

        [TestMethod]
        public void SortByName()
        {
            SortByName sort = new SortByName();

            Worker workerBig = new Worker("������ ������");

            Worker workerSmall = new Worker("������ ������");

            Assert.IsTrue(sort.Compare(workerBig, workerSmall) < 0);
            Assert.IsTrue(sort.Compare(workerSmall, workerBig) > 0);

            workerSmall.Name = "������ ������";
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
