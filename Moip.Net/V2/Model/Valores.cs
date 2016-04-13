using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Valores do pedido.
    /// </summary>
    public class Valores
    {
        public int? Total { get; set; }
        public int? Fee { get; set; }
        public int? Fees { get; set; }
        public int? Refunds { get; set; }
        public int? Liquid { get; set; }
        public int? OtherReceivers { get; set; }
        public CurrencyType? Currency { get; set; }
        public Subtotal Subtotals { get; set; }
    }
}