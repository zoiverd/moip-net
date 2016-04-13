using System;

namespace Moip.Net.V2.Model
{
    public class Portador
    {
        public string Fullname { get; set; }
        public string BirthDate { get; set; }
        public Telefone Phone { get; set; }
        public Documento TaxDocument { get; set; }
        public Endereco BillingAddress { get; set; }
    }
}