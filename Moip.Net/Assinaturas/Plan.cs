namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// O Plano é semelhante a um produto para o modelo de assinaturas. Um plano contém as configurações que uma assinatura vai seguir, como valor e intervalo de cobrança.
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// Identificador do plano na sua aplicação
        /// </summary>
        /// <remarks>string(65), Obrigatório</remarks>
        public string Code { get; set; }

        /// <summary>
        /// Nome do plano na sua aplicação
        /// </summary>
        /// <remarks>string(65), Obrigatório</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do plano
        /// </summary>
        /// <remarks>string(65), Obrigatorio</remarks>
        public string Description { get; set; }

        /// <summary>
        /// Valor do plano a ser cobrado em centavos de Real.
        /// </summary>
        /// <remarks>integer(11), obrigatório</remarks>
        public int Amount { get; set; }
        /// <summary>
        /// Taxa de contratação a ser cobrada na assinatura em centavos de Real
        /// </summary>
        /// <remarks>Integer(11)</remarks>
        public int? SetupFee { get; set; }

        /// <summary>
        /// Estrutura de intervalo do plano
        /// </summary>
        public PlanInterval Interval { get; set; }

        /// <summary>
        /// Estrutura de trial
        /// </summary>
        public PlanTrial Trial { get; set; }

        /// <summary>
        /// Status do plano.
        /// </summary>
        /// <remarks>Pode ser ACTIVE ou INACTIVE. O default é ACTIVE.</remarks>
        public StatusPlan? Status { get; set; }

        /// <summary>
        /// Quantidade máxima de assinaturas do plano
        /// </summary>
        /// <remarks>Se não informado, não haverá limite. Integer(11)</remarks>
        public int? MaxQty { get; set; }

        /// <summary>
        /// Quantidade de ciclos (faturas) que a assinatura terá até expirar (se não informar, não haverá expiração).
        /// </summary>
        /// <example>12</example>
        public int? BillingCycles { get; set; }

        /// <summary>
        /// Formas de pagamentos aceitas no plano.
        /// </summary>
        /// <remarks>BOLETO, CREDIT_CARD ou ALL. Caso o atributo não seja informado, a forma de pagamento default é CREDIT_CARD.</remarks>
        public PaymentMethodPlan? PaymentMethod { get; set; }


        public enum StatusPlan
        {
            ACTIVE,
            INACTIVE
        }


        public enum PaymentMethodPlan
        {
            BOLETO,
            CREDIT_CARD,
            ALL
        }


    }
    
    
}
