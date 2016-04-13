using System;
using System.Collections.Generic;

namespace Moip.Net.V2.Model
{
    /// <summary>
    /// O Pedido é a representação da venda de um produto ou serviço. Esta API possibilita a criação, consulta e listagem de pedidos.
    /// </summary>
    public class Pedido
    {
        public string Id { get; set; }
        public string OwnId { get; set; }
        public OrderStatusType? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Valores Amount { get; set; }
        public List<ItemPedido> Items { get; set; }
        public PreferenciasCheckout CheckoutPreferences { get; set; }
        public Endereco ShippingAddress { get; set; }
        public Cliente Customer { get; set; }
        public List<Pagamento> Payments { get; set; }
        public List<Reembolso> Refunds { get; set; }
        public List<Lancamento> Entries { get; set; }
        public List<Evento> Events { get; set; }
        public List<Recebedores> Receivers { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Links _links { get; set; }

        public override string ToString()
        {
            return OwnId;
        }

    }
}
