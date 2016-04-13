namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Checkout Moip é a interface de pagamento criada e mantida pelo Moip, os links presentes nessa estrutura devem ser utilizados para redirecionar o cliente final (pagador) ao ambiente seguro Moip.
    /// </summary>
    public class CheckoutMoip
    {
        public Link PayCreditCard { get; set; }
        public Link PayBoleto { get; set; }
        public Link PayOnlineBankDebitItau { get; set; }
        public Link PayOnlineBankDebitBradesco { get; set; }
        public Link payOnlineBankDebitBB { get; set; }
        public Link PayOnlineBankDebitBanrisul { get; set; }
    }
}