namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// As assinaturas criadas geram faturas de acordo com as configurações do plano contratado.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Identificador da fatura no Moip Assinaturas
        /// </summary>
        /// <example>31</example>
        public int Id { get; set; }

        /// <summary>
        /// Valor total cobrado do cliente, em centavos
        /// </summary>
        /// <example>9990</example>
        public int Amount { get; set; }

        /// <summary>
        /// Código da assinatura
        /// </summary>
        /// <example>assinatura01</example>
        public string SubscriptionCode { get; set; }

        /// <summary>
        /// Ocorrência da fatura
        /// </summary>
        /// <remarks>ex. 3 para a terceira fatura</remarks>
        /// <example>1</example>
        public int Occurrence { get; set; }

        /// <summary>
        /// Status da fatura
        /// </summary>
        public StatusInvoice Status { get; set; }

        /// <summary>
        /// Detalhamento dos ítens que compõe a fatura
        /// </summary>
        public ItemInvoice[] Items { get; set; }

        /// <summary>
        /// Dados do plano referente à fatura
        /// </summary>
        public Plan Plan { get; set; }

        /// <summary>
        /// Node do cliente referente à fatura
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Data e hora da criação da fatura
        /// </summary>
        public MoipDate CreationDate { get; set; }

    }
    
    
}
