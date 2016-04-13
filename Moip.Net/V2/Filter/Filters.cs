using System.Collections.Generic;
using System.Linq;

namespace Moip.Net.V2.Filter
{
    public class Filters : List<BaseFilter>
    {
        public new Filters Add(BaseFilter filter)
        {
            base.Add(filter);
            return this;
        }

        public override string ToString()
        {
            var values = this.Select(x => x.ToString()).ToArray();
            return string.Join("|", values);
        }
    }
}
