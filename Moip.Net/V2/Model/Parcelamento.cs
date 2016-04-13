using System;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Configurações de parcelamento
    /// </summary>
    public class Parcelamento
    {
        public Parcelamento()
        {
            quantity = new int[2];
        }

        /// <summary>
        /// Limitadores do plano de parcelas. Exemplo: [1, 3];
        /// </summary>
        public int[] quantity { get; set; }
        public int? Discount { get; set; }
        public int? Addition { get; set; }

    }
}