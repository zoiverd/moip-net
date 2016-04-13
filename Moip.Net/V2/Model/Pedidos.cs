using System;
using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Lista de pedidos filtrados
    /// </summary>
    public class Pedidos
    {
        public Resumo Summary { get; set; }
        public List<Pedido> Orders { get; set; }
        public Links _links { get; set; }
    }
}
