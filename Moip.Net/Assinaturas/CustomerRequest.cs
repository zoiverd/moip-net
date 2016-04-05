namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// O Plano é semelhante a um produto para o modelo de assinaturas. Um plano contém as configurações que uma assinatura vai seguir, como valor e intervalo de cobrança.
    /// </summary>
    public class CustomerRequest : Customer
    {
        /// <summary>
        /// Node com os atributos do endereço.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        public CustomerAddress Address { get; set; }

        /// <summary>
        /// Dados de pagamento desse cliente.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        public BillingInfoRequest BillingInfo { get; set; }

    }
    
    
}
