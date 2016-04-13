namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Endereço é o conjunto de dados que representam um local associado ao Cliente como endereço para entrega(shippingAddress) ou associado ao Cartão de crédito como endereço de cobrança(billingAddress).
    /// </summary>
    /// <see cref="http://dev.moip.com.br/referencia-api/#endereo"/>
    public class Endereco
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }


    }
}