using System;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Débito online é o meio de pagamento disponibilizado pelos bancos para débito em conta corrente. Ao selecionar está opção o Cliente é redirecionado ao internet banking escolhido para finalização do seu pagamento.
    /// </summary>
    public class DebitoOnline
    {
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public DateTime DataExpiracaoBoleto { get; set; }
        public string ReturnUri { get; set; }
    }
}