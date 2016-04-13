using System;

namespace Moip.Net.V2.Filter
{
    public class GreatherThanFilter<T> : BaseFilter
    {
        public GreatherThanFilter(string name, T value) : base(name, new object[] { value })
        {
        }

        protected override string FilterName
        {
            get
            {
                return "gt";
            }
        }
    }
}
