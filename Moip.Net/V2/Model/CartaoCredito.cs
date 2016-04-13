namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Cartão de crédito é o cartão utilizado pelo Cliente para pagar um Pedido.
    /// </summary>
    /// <see cref="http://dev.moip.com.br/referencia-api/#carto-de-crdito"/>
    public class CartaoCredito
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public string Number { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
        public int? Cvc { get; set; }
        public BrandType Brand { get; set; }
        public string First6 { get; set; }
        public string Last4 { get; set; }
        public Portador Holder { get; set; }

    }
}