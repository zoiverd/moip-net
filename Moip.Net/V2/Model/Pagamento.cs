using System;
using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Pagamento é a transação financeira que ocorre entre o Cliente e o Recebedor, seja por meio de um cartão de crédito, de um boleto bancário, ou por outro meio de pagamento. Esta API permite a criação, consulta e listagem de pagamentos.
    /// </summary>
    public class Pagamento
    {
        public string Id { get; set; }
        public PaymentStatusType? Status { get; set; }
        public Valores Amount { get; set; }
        public int InstallmentCount { get; set; }
        public bool? DelayCapture { get; set; }
        public MeioPagamento FundingInstrument { get; set; }
        public List<Taxa> Fees { get; set; }
        public List<Evento> Events { get; set; }
        public DetalhesCancelamento CancellationDetails { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Links _links { get; set; }
        public CheckoutMoip Checkout { get; set; }

    }
}