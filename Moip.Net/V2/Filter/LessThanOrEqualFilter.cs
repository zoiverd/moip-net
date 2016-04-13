using System;

namespace Moip.Net.V2.Filter
{
    public class LessThanOrEqualFilter<T> : BaseFilter
    {
        public LessThanOrEqualFilter(string name, T value) : base(name, new object[] { value })
        {
        }

        protected override string FilterName
        {
            get
            {
                return "le";
            }
        }
    }
}
