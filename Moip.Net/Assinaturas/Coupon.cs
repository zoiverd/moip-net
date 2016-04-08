namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Um coupon permite oferecer a um determinado cliente um desconto em valor percentual ou inteiro. Esse desconto pode ser configurado para que seja aplicado apenas uma vez, inúmeras vezes ou pra sempre, além de outras configurações de duração e limite de associações.
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Código do identificador do coupon.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Código do identificador do coupon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do coupon.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Node dos atributos do desconto. Ver valores possíveis.
        /// </summary>
        public CouponDiscount Discount { get; set; }

        /// <summary>
        /// Coupons ativos podem ser associados em assinaturas, coupons inativos não podem ser associados, mas ainda podem estar relacionados com assinaturas já existentes.
        /// </summary>
        public CouponStatus Status { get; set; }

        /// <summary>
        /// Coupons ativos podem ser associados em assinaturas, coupons inativos não podem ser associados, mas ainda podem estar relacionados com assinaturas já existentes.
        /// </summary>
        public CouponDuration Duration { get; set; }

        /// <summary>
        /// Número máximo de submits do coupon até que ele seja inativado automaticamente.
        /// </summary>
        public int? MaxRedemptions { get; set; }

        /// <summary>
        /// Data de inativação do coupon, quando ele não poderá mais ser associado a novas assinaturas.
        /// </summary>
        public MoipDate ExpirationDate { get; set; }

        /// <summary>
        /// Data e hora da criação do coupon.
        /// </summary>
        public MoipDate CreationDate { get; set; }

        /// <summary>
        /// Informa se o coupon está ou não aplicando suas regras em alguma assinatura.
        /// </summary>
        public bool? InUse { get; set; }

        public enum CouponStatus
        {
            ACTIVE,
            INACTIVE
        }

    }
}
