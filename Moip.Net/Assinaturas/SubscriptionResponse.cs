namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Retorno da Assinatura 
    /// </summary>
    public class SubscriptionResponse : Subscription
    {
        /// <summary>
        /// Mensagem de retorno da criação da assinatura
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Erros na criação da assinatura
        /// </summary>
        public ResponseDetail[] Errors { get; set; }
        
        /// <summary>
        /// Status da assinatura
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// Dados da fatura gerada
        /// </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Alertas na criação da assinatura
        /// </summary>
        public ResponseDetail[] Alerts { get; set; }

        /// <summary>
        /// Data de criação, retorna da API
        /// </summary>
        public MoipDate CreationDate { get; set; }

        /// <summary>
        /// Próxima cobrança, retorna da API
        /// </summary>
        public MoipDate NextInvoiceDate { get; set; }

        /// <summary>
        /// Data de expiração
        /// </summary>
        public MoipDate ExpirationDate { get; set; }

        /// <summary>
        /// Início e fim do trial da assinatura
        /// </summary>
        public SubscriptionTrial Trial { get; set; }


    }
}
