using Daamn.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Employee employee = new Employee()
            {
                Surname = ")))",
                Name = "(((",
                Patronymic = "---"
            };
            Assert.AreEqual($"{employee.Surname} {employee.Name} {employee.Patronymic}", employee.ToString());
        }
        [TestMethod]
        public void TestMethod2()
        {
            Employee employee = new Employee()
            {
                Surname = ")))",
                Name = "(((",
                Patronymic = "---"
            };
            Assert.AreNotEqual(employee, employee.ToString());
        }
    }
}
