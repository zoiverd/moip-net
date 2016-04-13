namespace Moip.Net.V2.Model
{

    /// <summary>
    /// Estrutura de informações do item do pedido.
    /// </summary>
    public class ItemPedido
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}