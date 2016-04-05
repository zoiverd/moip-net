namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Estrutura de dados do cartão de crédito
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// Nome do portador.
        /// </summary>
        /// <remarks>Condicional</remarks>
        /// <example>Nome Completo</example>
        public string HolderName { get; set; }

        /// <summary>
        /// Número do cartão de crédito.
        /// </summary>
        /// <remarks>Condicional</remarks>
        /// <example>4111111111111111</example>
        public string Number { get; set; }

        /// <summary>
        /// 4111111111111111
        /// </summary>
        /// <remarks>Condicional</remarks>
        /// <example>01</example>
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// Ano de expiração do cartão.
        /// </summary>
        /// <remarks>Condicional</remarks>
        /// <example>16</example>
        public string ExpirationYear { get; set; }

        /// <summary>
        /// Cofre de um cartão de crédito, se já foi cadastrado para este mesmo cliente anteriormente. Caso informe o cofre, os demais dados do cartão não precisam ser informados.
        /// </summary>
        /// <remarks>Retorno da API</remarks>
        /// <example>e3er4-t1td3-rf4f4f-r4t4</example>
        public string Vault { get; set; }

    }
}
