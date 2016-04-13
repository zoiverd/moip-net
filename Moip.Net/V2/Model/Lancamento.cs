using System;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Lançamento é um crédito ou débito associado a conta de um recebedor. Ele é gerado quando um pagamento é autorizado, um reembolso é realizado ou em qualquer outra situação em que ocorram movimentações de valores na conta Moip de um lojista.
    /// </summary>
    public class Lancamento
    {
        public int? Id { get; set; }
        public string Event { get; set; }
        public EntryStatusType? Status { get; set; }
        public OperationType? Operation { get; set; }
        public Valores Amount { get; set; }
        public string Description { get; set; }
        public Parcela Occurrence { get; set; }
        public DateTime? ScheduledFor { get; set; }
        public DateTime? SettledAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreateAt { get; set; }
        public Links _links { get; set; }
    }
}