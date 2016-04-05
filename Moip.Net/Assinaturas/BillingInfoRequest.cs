namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Dados de pagamento do cliente
    /// </summary>
    public class BillingInfoRequest
    {
        /// <summary>
        /// Dados do cartão de crédito
        /// </summary>
        /// <remarks>Condicional</remarks>
        public CreditCard CreditCard { get; set; }


    }
}
