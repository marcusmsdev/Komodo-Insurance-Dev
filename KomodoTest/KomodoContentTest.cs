using Developer_Team_Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTest
{
    [TestClass]
    public class KomodoContentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Developer content = new Developer();

            content.UniqueId = 201;

            int expected = 201;
            int actual = content.UniqueId;

            Assert.AreEqual(expected, actual);
        }
    }
}
