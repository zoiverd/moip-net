namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// O Plano é semelhante a um produto para o modelo de assinaturas. Um plano contém as configurações que uma assinatura vai seguir, como valor e intervalo de cobrança.
    /// </summary>
    public class CustomerResponse : Customer
    {
        /// <summary>
        /// Data de criação do cliente
        /// </summary>
        /// <remarks>Apenas retorno da API</remarks>
        public string CreationDate { get; set; }

        /// <summary>
        /// Hora de criação do cliente
        /// </summary>
        /// <remarks>Apenas retorno da API</remarks>
        public string CreationTime { get; set; }
        
        /// <summary>
        /// Node com os atributos do endereço.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        public CustomerAddress Address { get; set; }

        /// <summary>
        /// Dados de pagamento desse cliente.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        public CustomerBillingInfo BillingInfo { get; set; }
        
        /// <summary>
        /// Dados de pagamento do cliente
        /// </summary>
        public class CustomerBillingInfo
        {
            /// <summary>
            /// Dados dos cartões de crédito
            /// </summary>
            /// <remarks>Preenchido no retorno da API</remarks>
            public CustomerBillingCreditCard[] CreditCards { get; set; }
            
            /// <summary>
            /// Estrutura de dados do cartão de crédito retornada da API
            /// </summary>
            public struct CustomerBillingCreditCard
            {
                /// <summary>
                /// Nome do portador.
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                public string HolderName { get; set; }

                /// <summary>
                /// Primeiros 6 dígitos do número do cartão de crédito.
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>411111</example>
                public string FirstSixDigits { get; set; }

                /// <summary>
                /// Mês de expiração do cartão
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>01</example>
                public string ExpirationMonth { get; set; }

                /// <summary>
                /// Bandeira do cartão
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>VISA</example>
                public string Brand { get; set; }

                /// <summary>
                /// Ano de expiração do cartão.
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>16</example>
                public string ExpirationYear { get; set; }

                /// <summary>
                /// Cofre de um cartão de crédito, se já foi cadastrado para este mesmo cliente anteriormente. Caso informe o cofre, os demais dados do cartão não precisam ser informados.
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>e3er4-t1td3-rf4f4f-r4t4</example>
                public string Vault { get; set; }

                /// <summary>
                /// Ultimos 4 dígitos do cartão
                /// </summary>
                /// <remarks>Retorno da API</remarks>
                /// <example>1111</example>
                public string LastFourDigits { get; set; }
            }
        }

    }
    
    
}
