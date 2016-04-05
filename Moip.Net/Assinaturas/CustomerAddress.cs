namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Dados do endereço do cliente
    /// </summary>
    public class CustomerAddress
    {
        /// <summary>
        /// Logradouro do endereço
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>Rua do Valentes</example>
        public string Street { get; set; }

        /// <summary>
        /// Número do logradouro
        /// </summary>
        /// <remarks>Opcional</remarks>
        /// <example>100</example>
        public string Number { get; set; }

        /// <summary>
        /// Complemento do endereço
        /// </summary>
        /// <remarks>Opcional</remarks>
        /// <example>AP 51</example>
        public string Complement { get; set; }

        /// <summary>
        /// Bairro do cliente
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>Lapa</example>
        public string District { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>São Paulo</example>
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>SP</example>
        public string State { get; set; }

        /// <summary>
        /// País
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>BRA</example>
        public string Country { get; set; }

        /// <summary>
        /// CEP do endereço. Sem máscara
        /// </summary>
        /// <remarks>Obrigatório</remarks>
        /// <example>00000000</example>
        public string Zipcode { get; set; }
    }
}
