using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moip.Net.Assinaturas
{
    /// <summary>
    /// Estrutura de intervalo do plano
    /// </summary>
    public class PlanInterval
    {
        /// <summary>
        /// A unidade de medida do intervalo de cobrança
        /// </summary>
        /// <remarks>O default é MONTH. Opções: DAY, MONTH, YEAR. Condicional</remarks>
        public IntervalUnit? Unit { get; set; }

        /// <summary>
        /// A duração do intervalo de cobrança, default é 1.
        /// </summary>
        /// <remarks>Default é 1. integer(11)</remarks>
        public int? Length { get; set; }
        
        public enum IntervalUnit
        {
            DAY,
            MONTH,
            YEAR
        }
    }
}
