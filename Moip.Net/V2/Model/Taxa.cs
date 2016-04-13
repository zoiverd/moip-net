namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Tarifas do pagamento
    /// </summary>
    public class Taxa
    {
        public FeeType Type { get; set; }
        public int Amount { get; set; }
    }
}