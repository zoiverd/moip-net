using System;
using System.Linq;

namespace Moip.Net.V2.Filter
{
    public class InFilter<T> : BaseFilter
    {
        public InFilter(string name, params T[] value) : base(name, value.Select(x => (object)x).ToArray())
        {
        }

        protected override string FilterName
        {
            get
            {
                return "in";
            }
        }
    }
}
