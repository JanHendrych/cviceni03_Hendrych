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
    public class StudentsTableTests
    {
        public static IComparable GetStudentNumber(Student student) => student.Number;

        [TestMethod()]
        public void AddAndGetTest()
        {
            StudentsTable table = new StudentsTable(20, GetStudentNumber);
            table.Add(new Student() { Number = 1, Name = "Peter" });
            table.Add(new Student() { Number = 2, Name = "John" });

            Assert.IsNull(table.Get(0));
            Assert.IsNotNull(table.Get(1));
            Assert.IsNotNull(table.Get(2));
            Assert.IsNull(table.Get(3));
        }

        [TestMethod()]
        public void DeleteAndGetTest()
        {
            StudentsTable table = new StudentsTable(20, GetStudentNumber);
            table.Add(new Student() { Number = 1, Name = "Peter" });
            table.Add(new Student() { Number = 2, Name = "John" });
            table.Add(new Student() { Number = 3, Name = "John" });

            Student? actual = table.Delete(2);

            Assert.IsNotNull(actual);
            Assert.IsNull(table.Get(0));
            Assert.IsNotNull(table.Get(1));
            Assert.IsNull(table.Get(2));
            Assert.IsNotNull(table.Get(3));
            Assert.IsNull(table.Get(4));
        }
    }
}