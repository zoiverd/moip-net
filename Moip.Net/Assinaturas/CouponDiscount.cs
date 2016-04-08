namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Node dos atributos do desconto. Ver valores possíveis.
    /// </summary>
    public class CouponDiscount
    {
        /// <summary>
        /// Node dos atributos do desconto. Ver valores possíveis.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Define se o tipo de desconto é percentual ou em reais (R$).
        /// </summary>
        public DiscountType Type { get; set; }
    }

    public enum DiscountType
    {
        PERCENT,
        AMOUNT
    }
}