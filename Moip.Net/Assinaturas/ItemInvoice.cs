namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Detalhamento dos ítens que compõem a fatura
    /// </summary>
    public class ItemInvoice
    {
        /// <summary>
        /// Descrição do ítem (ex. "Valor da assinatura", "Taxa de contratação" etc)
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Valor do ítem em centavos. Em assinaturas com período de Trial gratuito o valor da primeira fatura é 0
        /// </summary>
        public string Amount { get; set; }

    }
}