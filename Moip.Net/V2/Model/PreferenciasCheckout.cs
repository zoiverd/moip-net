namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Configurações para o checkout.
    /// </summary>
    public class PreferenciasCheckout
    {
        public Redirecionamento RedirectUrls { get; set; }
        public Parcelamento Installments { get; set; }
    }
}