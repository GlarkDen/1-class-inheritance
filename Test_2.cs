using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_10;

namespace Lab_10_MSTest
{
    [TestClass]
    public class Test_2
    {
        [TestMethod]
        public void ProgramMethods()
        {
            Program.PrintOperations();
            Program.PrintOperations(1);
            Program.PrintOperations(2);
            Program.PrintOperations(3);

            Program.PartOneNotVitrual();
            Program.PartOneVitrual();

            Program.PartTwoEngineerCount();
            Program.PartTwoMenNames();
            Program.PartTwoProfession();
            Program.PartTwoWorkExperience();
            Program.PartTwoWorkPlace();
            Program.PartTwoWorkTime();
            Program.PartTwoAdminWorkerCount();
            Program.PartTwoAll();

            Program.PartThreeCloneable();
            Program.PartThreeIComparable();
            Program.PartThreeIComparer();
            Program.PartThreeShowIInit();
        }
    }

}
