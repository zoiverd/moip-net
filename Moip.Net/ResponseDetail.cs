using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moip.Net
{
    public class ResponseDetail
    {
        /// <summary>
        /// Descrição do alerta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Código do alerta
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Parâmetro relacionado ao erro (Apenas V2)
        /// </summary>
        public string Path { get; set; }
    }
}
