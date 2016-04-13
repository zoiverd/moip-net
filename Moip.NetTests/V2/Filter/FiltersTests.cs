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
    public class FiltersTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var filters = new Filters()
                .Add(new BetweenFilter<int>("btName", 1, 10))
                .Add(new GreatherThanFilter<int>("gtName", 1));

            Assert.AreEqual("btName::bt(1,10)|gtName::gt(1)", filters.ToString());
        }
    }
}