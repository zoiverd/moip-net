namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Node de duração do coupon em uma assinatura. Ver valores possíveis.
    /// </summary>
    public class CouponDuration
    {
        /// <summary>
        /// Determina se um coupon será válido apenas em uma cobrança, ou em um número específico diferente de 1 ou em todas.
        /// </summary>
        public DurationType Type { get; set; }

        /// <summary>
        /// Representa o número de ocorrências que receberão o desconto. Válido apenas quando o type for repeating.
        /// </summary>
        public int Occurrences { get; set; }

        public enum DurationType
        {
            ONCE,
            REPEATING,
            FOREVER
        }
    }
}