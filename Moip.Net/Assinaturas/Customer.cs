namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Dados básicos do assinante
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Identificador do cliente na sua aplicação. Até 65 caracteres..
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>aa001</example>
        public string Code { get; set; }

        /// <summary>
        /// Nome completo do cliente. Até 150 caracteres.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>Nome Sobrenome</example>
        public string Fullname { get; set; }

        /// <summary>
        /// Email do cliente
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>nome@exemplo.com.br</example>
        public string Email { get; set; }

        /// <summary>
        /// CPF do cliente. Apenas dígitos numéricos
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>16412725297</example>
        public string Cpf { get; set; }

        /// <summary>
        /// Código de área do telefone do titular (DDD). 2 Caracteres sem máscara.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>11</example>
        public int PhoneAreaCode { get; set; }

        /// <summary>
        /// Telefone do titular, 8 ou 9 caracteres sem máscara.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example></example>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Dia do nascimento. Válido 1 a 31.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>01</example>
        public int BirthdateDay { get; set; }

        /// <summary>
        /// Mês do nascimento. Válido 1 a 12.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>01</example>
        public int BirthdateMonth { get; set; }

        /// <summary>
        /// Ano do nascimento. 4 dígitos.
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>1999</example>
        public int BirthdateYear { get; set; }
        
    }
    
    
}
