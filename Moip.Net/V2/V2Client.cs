using Moip.Net.V2.Configuration;
using Moip.Net.V2.Filter;
using Moip.Net.V2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moip.Net.V2
{
    /// <summary>
    /// Classe para acessar as funcionalidades da API V2 no Moip
    /// </summary>
    /// <see cref="http://dev.moip.com.br/referencia-api/#introduo"/>
    public class V2Client : BaseClient
    {
        public V2Client(Uri apiUri, string apiToken, string apiKey) : base(apiUri, apiToken, apiKey) { }

        private JsonSerializerSettings _jsonSettings;
        protected override JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings();
                    _jsonSettings.Converters.Add(new StringEnumConverter());
                    _jsonSettings.Formatting = Formatting.Indented;
                    _jsonSettings.ContractResolver = new V2ContractResolver();
                    _jsonSettings.NullValueHandling = NullValueHandling.Ignore;
                }
                return _jsonSettings;
            }
        }

        protected override Uri PathToUri(string path, string query = null)
        {
            return base.PathToUri("/v2/" + path, query);
        }

        private T Query<T>(string path, int? offset = null, int? limit = null, string query = null, Filters filters = null)
        {
            var arrQuery = new List<string>();

            if (offset.HasValue)
            {
                arrQuery.Add("offset=" + offset);
            }
            
            if(limit.HasValue)
            {
                arrQuery.Add("limit=" + limit);
            }
            
            if (!string.IsNullOrEmpty(query))
            {
                arrQuery.Add("q=" + Uri.EscapeDataString(query));
            }

            if (filters != null)
            {
                arrQuery.Add("filters=" + Uri.EscapeDataString(filters.ToString()));
            }

            var uri = PathToUri(path, string.Join("&", arrQuery.ToArray()));
            return DoRequest<T>(uri);
        }

        #region Cliente

        /// <summary>
        /// Por meio desta API é possível criar um Cliente. Você pode criar um cliente com dados de cartão para utilizá-lo posteriormente.
        /// </summary>
        /// <param name="cliente">Cliente para ser criado</param>
        /// <returns>Cliente criado com os dados de request</returns>
        /// <see cref="http://dev.moip.com.br/referencia-api/#criar-cliente-post" />
        public Cliente CriarCliente(Cliente cliente)
        {
            var uri = PathToUri("customers");
            return DoRequest<Cliente>(uri, "POST", ToJson(cliente));
        }

        /// <summary>
        /// Por meio desta API é possível consultar as informações e detalhes de um cliente.
        /// </summary>
        /// <param name="id">Id MOIP do cliente</param>
        /// <returns>Dados do cliente cadastrado no moip</returns>
        /// <see cref="http://dev.moip.com.br/referencia-api/#consultar-cliente-get" />
        public Cliente ConsultarCliente(string id)
        {
            var uri = PathToUri("customers/" + id);
            return DoRequest<Cliente>(uri, "get");
        }

        /// <summary>
        /// Por meio desta API é possível adicionar um ou mais cartões de crédito a um Cliente.
        /// </summary>
        /// <param name="idCustomer">Id do cliente em formato de hash.</param>
        /// <param name="fundingInstrument">Cartão de crédito</param>
        /// <returns>Cartão de crédito criado</returns>
        public MeioPagamento AdicionarCartaoAUmCliente(string idCustomer, MeioPagamento fundingInstrument)
        {
            var uri = PathToUri(string.Format("customers/{0}/fundinginstruments", idCustomer));
            return DoRequest<MeioPagamento>(uri, "POST", ToJson(fundingInstrument));
        }

        #endregion

        #region Pedidos

        /// <summary>
        /// Por meio desta API é possível criar um Pedido no Moip que irá conter os dados da venda de um produto ou serviço. Para criar o pedido, você pode utilizar um Cliente já criado anteriormente ou informar os dados de um novo Cliente.
        /// </summary>
        /// <param name="order">Pedido a ser criado</param>
        /// <returns>Pedido criado no moip</returns>
        /// <see cref="http://dev.moip.com.br/referencia-api/#criar-pedido-post"/>
        public Pedido CriarPedido(Pedido order)
        {
            var uri = PathToUri("orders");
            return DoRequest<Pedido>(uri, "POST", ToJson(order));
        }

        /// <summary>
        /// Por meio desta API é possível consultar as informações e detalhes de um Pedido.
        /// </summary>
        /// <param name="id">Id do pedido no moip</param>
        /// <returns>Pedido do moip</returns>
        public Pedido ConsultarPedido(string id)
        {
            var uri = PathToUri("orders/" + id);
            return DoRequest<Pedido>(uri);
        }

        /// <summary>
        /// Por meio desta API é possível listar todos pedidos criados anteriormente. Os pedidos são ordenados pela data de criação, dos mais recentes para os mais antigos. Nesta versão da API são retornados apenas pedidos que contenham ao menos um pagamento. Também é possível filtrar os resultados conforme a listagem de parâmetros disponíveis do método.
        /// </summary>
        /// <param name="offset">Registro a partir do qual a busca vai retornar. O valor default é 0.</param>
        /// <param name="limit">Quantidade de registros por busca (página). O valor default é 20</param>
        /// <param name="query">Consulta um valor em específico</param>
        /// <param name="filters">Filtros</param>
        /// <returns>Lista de pedidos que atendem aos requisitos</returns>
        /// <see cref="http://dev.moip.com.br/referencia-api/#listar-todos-pedidos-get"/>
        public Pedidos ListarTodosPedidos(int? offset = null, int? limit = null, string query = null, Filters filters = null)
        {
            return Query<Pedidos>("orders", offset, limit, query, filters);
        }

        #endregion

        #region Pagamentos

        /// <summary>
        /// Por meio desta API é possível solicitar ao Moip que realize a cobrança de um pedido. Para isso, você deve enviar as informações referentes ao pagamento.
        /// </summary>
        /// <remarks>Importante: você deve fazer a criptografia dos dados do cartão de crédito antes de enviar ao Moip. Caso você tenha certificado PCI, é permitido o envio dos dados sem criptografia para o Moip.</remarks>
        /// <param name="idPedido">Id do pedido moip</param>
        /// <param name="pagamento">Pagamento a ser criado</param>
        /// <returns>Pagamento criado no moip</returns>
        public Pagamento CriarPagamento(string idPedido, Pagamento pagamento)
        {
            var uri = PathToUri(string.Format("orders/{0}/payments", idPedido));
            return DoRequest<Pagamento>(uri, "POST", ToJson(pagamento));
        }

        /// <summary>
        /// Por meio desta API é possível consultar as informações e detalhes de um Pagamento em específico.
        /// </summary>
        /// <param name="id">Id do pagamento do moip</param>
        /// <returns>Pagamento cadastrado no moip</returns>
        public Pagamento ConsultarPagamento(string id)
        {
            var uri = PathToUri("payments/" + id);
            return DoRequest<Pagamento>(uri);
        }

        /// <summary>
        /// Essa API permite a captura de um pagamento que esteja pré-autorizado no Moip. Para que você possa pré-autorizar utilize o atributo delayCapture na criação de um pagamento. Somente é possível capturar um pagamento que esteja com status PRE_AUTHORIZED.
        /// </summary>
        /// <param name="id">Id do pagamento no moip</param>
        /// <returns>Pagamento capturado</returns>
        public Pagamento CapturarPagamentoPreAutorizado(string id)
        {
            var uri = PathToUri(string.Format("payments/{0}/capture", id));
            return DoRequest<Pagamento>(uri, "POST");
        }

        /// <summary>
        /// Essa API permite o cancelamento de um pagamento que esteja pré-autorizado no Moip. Para que você possa pré-autorizar utilize o atributo delayCapture na criação de um pagamento. Somente é possível capturar um pagamento que esteja com status PRE_AUTHORIZED.
        /// </summary>
        /// <param name="id">Id do pagamento no moip</param>
        /// <returns>Pagamento cancelado</returns>
        public Pagamento CancelarPagamentoPreAutorizado(string id)
        {
            var uri = PathToUri(string.Format("payments/{0}/void", id));
            return DoRequest<Pagamento>(uri, "POST");
        }

        #endregion

    }
}
