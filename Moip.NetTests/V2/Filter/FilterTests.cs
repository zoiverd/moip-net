using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moip.Net.V2.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net.V2.Filter.Tests
{
    [TestClass()]
    public class FilterTests
    {
        [TestMethod()]
        public void GreatherThanTest()
        {
            var filter = new GreatherThanFilter<int>("filterName", 1);
            Assert.AreEqual("filterName::gt(1)", filter.ToString());
        }

        [TestMethod()]
        public void GreatherThanOrEqualTest()
        {
            var filter = new GreatherThanOrEqualFilter<DateTime>("filterName", new DateTime(2016, 01, 31));
            Assert.AreEqual("filterName::ge(2016-01-31)", filter.ToString());
        }

        [TestMethod()]
        public void LessThanTest()
        {
            var filter = new LessThanFilter<int>("filterName", 1);
            Assert.AreEqual("filterName::lt(1)", filter.ToString());
        }

        [TestMethod()]
        public void LessThanOrEqualTest()
        {
            var filter = new LessThanOrEqualFilter<int>("filterName", 1);
            Assert.AreEqual("filterName::le(1)", filter.ToString());
        }

        [TestMethod()]
        public void BetweenFilterTest()
        {
            var filter = new BetweenFilter<int>("filterName", 1, 10);
            Assert.AreEqual("filterName::bt(1,10)", filter.ToString());
        }

        [TestMethod()]
        public void InFilterTest()
        {
            var filter = new InFilter<OrderStatusType>("filterName", OrderStatusType.CREATED, OrderStatusType.NOT_PAID, OrderStatusType.PAID);
            Assert.AreEqual("filterName::in(CREATED,NOT_PAID,PAID)", filter.ToString());
        }
    }
}