namespace Moip.Net.V2.Model
{
    /// <summary>
    /// A Conta bancária é o domicílio bancário de um determinado vendedor ou de um Cliente.
    /// </summary>
    public class ContaBancaria
    {
        public BankAccountType Type { get; set; }
        public string BankNumber { get; set; }
        public int AgencyNumber { get; set; }
        public int AgencyCheckNumber { get; set; }
        public int AccountNumber { get; set; }
        public int AccountCheckNumber { get; set; }
        public Portador Holder { get; set; }
    }
}