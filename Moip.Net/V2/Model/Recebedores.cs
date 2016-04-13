namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Estrutura de recebedores dos pagamentos.
    /// </summary>
    public class Recebedores
    {
        public ReceiverType? Type { get; set; }
        public ContaMoip moipAccount { get; set; }
        public Valores Amount { get; set; }
    }
}