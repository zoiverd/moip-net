using System;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// Eventos associados ao pagamento.
    /// </summary>
    public class Evento
    {
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}