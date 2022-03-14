using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegateLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLib.Tests
{
    [TestClass()]
    public class StudentTests
    {

        [TestMethod()]
        public void ToStringTest1()
        {
            Student student = new Student()
            {
                Number = 1,
                Name = "Peter"
            };

            string actual = student.ToString() ?? "";
            Assert.IsTrue(actual.StartsWith("Peter ("));
        }

        [TestMethod()]
        public void ToStringTest2()
        {
            Student student = new Student()
            {
                Number = 2,
                Name = "Lucy"
            };

            string actual = student.ToString() ?? "";
            Assert.IsTrue(actual.StartsWith("Lucy ("));
        }
    }
}