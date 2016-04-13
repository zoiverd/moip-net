namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Detalhes do cancelamento de pagamentos de cartão de crédito
    /// </summary>
    public class DetalhesCancelamento
    {
        public CancelledByType CancelledBy { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
}