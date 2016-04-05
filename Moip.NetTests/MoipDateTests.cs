using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moip.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net.Tests
{
    [TestClass()]
    public class MoipDateTests
    {
        [TestMethod()]
        public void ToDateTest()
        {
            var dateTest = new DateTime(2015, 01, 20, 10, 20, 30);
            var moipDate = new MoipDate()
            {
                Year = dateTest.Year,
                Month = dateTest.Month,
                Day = dateTest.Day,
                Hour = dateTest.Hour,
                Minute = dateTest.Minute,
                Second = dateTest.Second
            };

            Assert.AreEqual(moipDate.ToDate(), dateTest);
        }

        [TestMethod()]
        public void FromDateTest()
        {
            var dateTest = new DateTime(2015, 01, 20, 10, 20, 30);
            var moipDate = MoipDate.FromDate(dateTest);

            Assert.AreEqual(dateTest.Year, moipDate.Year);
            Assert.AreEqual(dateTest.Month, moipDate.Month);
            Assert.AreEqual(dateTest.Day, moipDate.Day);
            Assert.AreEqual(dateTest.Hour, moipDate.Hour);
            Assert.AreEqual(dateTest.Minute, moipDate.Minute);
            Assert.AreEqual(dateTest.Second, moipDate.Second);
        }
    }
}