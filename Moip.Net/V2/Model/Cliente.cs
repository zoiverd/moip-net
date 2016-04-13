using System;
using System.Collections.Generic;

namespace Moip.Net.V2.Model
{

    /// <summary>
    /// Cliente é o usuário de um serviço ou o comprador de uma determinada loja virtual. 
    /// </summary>
    /// <see cref="http://dev.moip.com.br/referencia-api/#clientes"/>
    public class Cliente
    {
        public string Id { get; set; }
        public string OwnId { get; set; }
        public string Fullname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Email { get; set; }
        public Telefone Phone { get; set; }
        /// <summary>
        /// Birthdate é string no formato 'yyyy-MM-dd'
        /// </summary>
        public string BirthDate { get; set; }
        public Documento TaxDocument { get; set; }
        public Endereco ShippingAddress { get; set; }
        public List<MeioPagamento> FundingInstruments { get; set; }
        public Links _links { get; set; }

        public override string ToString()
        {
            return OwnId;
        }
    }
    
    
}
