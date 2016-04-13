namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Instrumento de cobrança
    /// </summary>
    public class MeioPagamento
    {
        public MethodType Method { get; set; }
        public CartaoCredito CreditCard { get; set; }
        public Boleto Boleto { get; set; }
        public DebitoOnline OnlineDebit { get; set; }
        public ContaBancaria BankAccount { get; set; }


    }
}