using System;

namespace Moip.Net.V2.Filter
{
    public class GreatherThanOrEqualFilter<T> : BaseFilter
    {
        public GreatherThanOrEqualFilter(string name, T value) : base(name, new object[] { value })
        {
        }

        protected override string FilterName
        {
            get
            {
                return "ge";
            }
        }
    }
}
