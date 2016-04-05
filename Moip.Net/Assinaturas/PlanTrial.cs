namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Estrutura de trial do plano
    /// </summary>
    public class PlanTrial
    {
        /// <summary>
        /// Número de dias de trial do plano.
        /// </summary>
        /// <remarks>integet(11)</remarks>
        public int Days { get; set; }

        /// <summary>
        /// Número de dias de trial do plano.
        /// </summary>
        /// <remarks>Default FALSE</remarks>
        public bool Enabled { get; set; }

        /// <summary>
        /// Determina se o setup_fee será cobrado antes ou após o período de trial
        /// </summary>
        /// <remarks>Opções: TRUE (após) ou FALSE (antes). Default é TRUE.</remarks>
        public bool HoldSetupFee { get; set; }
        
    }
}
