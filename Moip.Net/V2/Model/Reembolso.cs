using System;
using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Reembolso é devolução de um pagamento para o consumidor. Por meio desta API é possível realizar reembolsos e consultar os detalhes de determinado reembolso.
    /// </summary>
    public class Reembolso
    {
        public string Id { get; set; }
        public RefundStatusType? Status { get; set; }
        public Valores Amount { get; set; }
        public RefundType? Type { get; set; }
        public MeioPagamento RefundingInstrument { get; set; }
        public List<Evento> Events { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Links _links { get; set; }

    }
}