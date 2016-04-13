namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Estrutura de valores adicionais do pedido.
    /// </summary>
    public class Subtotal
    {
        public int? Shipping { get; set; }
        public int? Addition { get; set; }
        public int? Discount { get; set; }
        public int? Items { get; set; }
    }
}