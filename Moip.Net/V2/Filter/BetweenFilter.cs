using System;

namespace Moip.Net.V2.Filter
{
    public class BetweenFilter<T> : BaseFilter
    {
        public BetweenFilter(string name, T value1, T value2) : base(name, new object[] { value1, value2 })
        {
        }

        protected override string FilterName
        {
            get
            {
                return "bt";
            }
        }
    }
}
