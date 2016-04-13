using System;

namespace Moip.Net.V2.Filter
{
    public class LessThanFilter<T> : BaseFilter
    {
        public LessThanFilter(string name, T value) : base(name, new object[] { value })
        {
        }

        protected override string FilterName
        {
            get
            {
                return "lt";
            }
        }
    }
}
