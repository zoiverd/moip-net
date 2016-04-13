using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    public class Links
    {
        public Link Self { get; set; }
        public Link Order { get; set; }
        public Link Payment { get; set; }
        public Link Multiorder { get; set; }
        public Link Next { get; set; }
        public Link Previous { get; set; }
        public CheckoutMoip Checkout { get; set; }
    }
}