namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Estrutura de retorno das datas de início e fim do período de Trial (retorna do detalhe da assinatura)
    /// </summary>
    public class SubscriptionTrial
    {
        /// <summary>
        /// Data de inicio do período de Trial
        /// </summary>
        public MoipDate Start { get; set; }
        /// <summary>
        /// Data fim do período de Trial
        /// </summary>
        public MoipDate End { get; set; }
    }
}