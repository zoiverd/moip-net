using Newtonsoft.Json;

namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Uma assinatura permite a cobrança recorrente de um cliente(assinante) de forma automática e simples. Para criar uma nova assinatura, basta informar o plano, o cliente da assinatura e um identificador para ela. Se quiser, é possível criar o cliente e seus dados de pagamento junto com a assinatura. 
    /// </summary>
    public class Subscriptions
    {
        /// <summary>
        /// Identificador da assinatura na sua aplicação. Até 65 caracteres.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>assinatura01</example>
        public string Code { get; set; }

        /// <summary>
        /// Valor da assinatura (sobrescreve o valor do plano contratado) atenção: o cliente deve estar ciente e de acordo em ser cobrado um valor diferente do plano escolhido.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>9990</example>
        public int? Amount { get; set; }

        /// <summary>
        /// Node de informações do plano que será usado na assinatura (preencher apenas o code)
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>new Plan() { .code = "plano001" }</example>
        public Plan Plan { get; set; }

        /// <summary>
        /// Node de informações do plano que será usado na assinatura. Identificador do cliente previamente criado e que será usado na assinatura. importante: se o cliente ainda não tiver sido criado, todos os parâmetros do clientes devem ser enviados, consulte a documentação de Clientes.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>new Cliente() { .code = "cliente001" }</example>
        public Customer Customer { get; set; }

        /// <summary>
        /// Data de criação, retorna da API
        /// </summary>
        public MoipDate CreationDate { get; set; }

        /// <summary>
        /// Próxima cobrança, retorna da API
        /// </summary>
        public MoipDate NextInvoice { get; set; }
    }
}
