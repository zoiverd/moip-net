using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moip.Net.V2;
using Moip.Net.V2.Filter;
using Moip.Net.V2.Model;
using Moip.NetTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Moip.Net.V2.Tests
{
    [TestClass()]
    public class V2ClientTests
    {
        private V2Client v2Client = new V2Client(Settings.ApiUri, Settings.ApiToken, Settings.ApiKey);

        private string NewId(string Tipo)
        {
            return string.Format("_TEST_{0}_{1}", Tipo, DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.fff"));
        }

        #region SerializerTests

        public class TestJsonSerializer
        {
            public string NomeCompleto { get; set; }
            public int Idade { get; set; }
            public TipoCliente TipoDeCliente { get; set; }
            public DateTime Data { get; set; }
            public enum TipoCliente
            {
                ATIVO,
                INATIVO
            }
        }
        private string jsonTest = @"{
  ""nomeCompleto"": ""Rafael Gonçalves"",
  ""idade"": 19,
  ""tipoDeCliente"": ""ATIVO"",
  ""data"": ""2016-01-31T00:00:00""
}";

        [TestMethod()]
        public void ToJsonTest()
        {
            var json = v2Client.ToJson(new TestJsonSerializer
            {
                NomeCompleto = "Rafael Gonçalves",
                Idade = 19,
                TipoDeCliente = TestJsonSerializer.TipoCliente.ATIVO,
                Data = new DateTime(2016, 01, 31)
            });

            Assert.AreEqual(jsonTest, json);
        }

        [TestMethod()]
        public void FromJsonTest()
        {
            var obj = v2Client.FromJson<TestJsonSerializer>(jsonTest);

            Assert.AreEqual("Rafael Gonçalves", obj.NomeCompleto);
            Assert.AreEqual(19, obj.Idade);
            Assert.AreEqual(TestJsonSerializer.TipoCliente.ATIVO, obj.TipoDeCliente);
            Assert.AreEqual(new DateTime(2016, 01, 31), obj.Data);
        }


        #endregion

        #region Cliente
        private Cliente CriarCliente()
        {
            var custId = NewId("CUS");
            var cliente = new Cliente()
            {
                OwnId = custId,
                Fullname = "José Silva",
                Email = custId.Replace(":", "") + "@acme.com.br",
                BirthDate = DateTime.Now.Date.AddYears(-18).ToString("yyyy-MM-dd"),
                TaxDocument = new Documento()
                {
                    Type = DocumentType.CPF,
                    Number = "65374721054"
                },
                Phone = new Telefone()
                {
                    CountryCode = 55,
                    AreaCode = 11,
                    Number = 999999999
                },
                ShippingAddress = new Endereco()
                {
                    ZipCode = "01234000",
                    Street = "Avenida Faria Lima",
                    StreetNumber = "2927",
                    Complement = "SL 1",
                    City = "São Paulo",
                    District = "Itaim",
                    State = "SP",
                    Country = "BRA"
                }
            };

            return v2Client.CriarCliente(cliente);
        }

        [TestMethod]
        public void CriarClienteTest()
        {
            var clienteCriado = CriarCliente();
            Assert.IsNotNull(clienteCriado.Id);
        }

        [TestMethod()]
        public void ConsultarClienteTest()
        {
            var cliente = CriarCliente();
            var clienteCriado = v2Client.ConsultarCliente(cliente.Id);

            Assert.AreEqual(cliente.OwnId, clienteCriado.OwnId);

        }

        private MeioPagamento AdicionarCartaoAUmCliente()
        {
            var meioPagamento = new MeioPagamento()
            {
                Method = MethodType.CREDIT_CARD,
                CreditCard = new CartaoCredito()
                {
                    ExpirationMonth = 5,
                    ExpirationYear = 20,
                    Number = "5555666677778884",
                    Cvc = 123,
                    Holder = new Portador()
                    {
                        Fullname = "Jose Portador da Silva",
                        Birthdate = DateTime.Now.ToString("yyyy-MM-dd"),
                        TaxDocument = new Documento()
                        {
                            Type = DocumentType.CPF,
                            Number = "65374721054"
                        },
                        Phone = new Telefone()
                        {
                            CountryCode = 55,
                            AreaCode = 11,
                            Number = 67888888
                        }
                    }
                }
            };

            var novoCliente = CriarCliente();
            return v2Client.AdicionarCartaoAUmCliente(novoCliente.Id, meioPagamento);
        }

        [TestMethod]
        public void AdicionarCartaoAUmClienteTest()
        {
            var cartaoCriado = AdicionarCartaoAUmCliente();
            Assert.IsNotNull(cartaoCriado.CreditCard.Id);
        }
        #endregion

        #region Pedido

        private Pedido CriarPedido()
        {
            var cliente = CriarCliente();
            var pedido = new Pedido()
            {
                OwnId = NewId("ORD"),
                Amount = new Valores()
                {
                    Currency = CurrencyType.BRL,
                    Subtotals = new Subtotal()
                    {
                        Shipping = 1000
                    }
                },
                Items = new List<ItemPedido>()
                {
                    new ItemPedido()
                    {
                        Product = "Descrição do produto",
                        Quantity = 1,
                        Detail = "Detalhes",
                        Price = 1000
                    }
                },
                Customer = new Cliente()
                {
                    Id = cliente.Id
                }
            };

            return v2Client.CriarPedido(pedido);
        }

        [TestMethod]
        public void CriarPedidoTest()
        {
            var pedidoCriado = CriarPedido();
            Assert.IsNotNull(pedidoCriado.Id);
        }

        [TestMethod()]
        public void ConsultarPedidoTest()
        {
            var pedido = CriarPedido();
            var createdPedido = v2Client.ConsultarPedido(pedido.Id);
            Assert.IsNotNull(createdPedido.CreatedAt);
        }

        [TestMethod()]
        public void ListarTodosPedidosTest()
        {
            var filters = new Filters()
                .Add(new GreatherThanFilter<DateTime>("createdAt", new DateTime(2016, 01, 01)))
                .Add(new InFilter<OrderStatusType>("status", OrderStatusType.CREATED, OrderStatusType.PAID));

            var pedidos = v2Client.ListarTodosPedidos(filters: filters);
            Assert.IsTrue(pedidos.Orders.Count > 0);
        }

        #endregion

        #region Pagamento

        private Pagamento CriarPagamento(bool delayCapture)
        {
            var pedido = CriarPedido();

            var pagamento = new Pagamento()
            {
                InstallmentCount = 1,
                DelayCapture = delayCapture,
                FundingInstrument = new MeioPagamento()
                {
                    Method = MethodType.CREDIT_CARD,
                    CreditCard = new CartaoCredito()
                    {
                        Number = "5555666677778884",
                        ExpirationMonth = 5,
                        ExpirationYear = 2018,
                        Cvc = 123,
                        Holder = new Portador()
                        {
                            Fullname = "Jose Portador da Silva",
                            Birthdate = "1988-12-30",
                            TaxDocument = new Documento()
                            {
                                Type = DocumentType.CPF,
                                Number = "33333333333"
                            },
                            Phone = new Telefone()
                            {
                                CountryCode = 55,
                                AreaCode = 11,
                                Number = 66778899
                            }
                        }
                    }
                }
            };

            return v2Client.CriarPagamento(pedido.Id, pagamento);
        }

        [TestMethod()]
        public void CriarPagamentoTest()
        {
            var pagamentoCriado = CriarPagamento(false);
            Assert.AreEqual(PaymentStatusType.IN_ANALYSIS, pagamentoCriado.Status);
        }

        [TestMethod]
        public void ConsultarPagamento()
        {
            var pagamentoCriado = CriarPagamento(false);
            var pagamento = v2Client.ConsultarPagamento(pagamentoCriado.Id);
            Assert.AreEqual(pagamentoCriado.Id, pagamento.Id);
        }

        [TestMethod()]
        public void CapturarPagamentoPreAutorizadoTest()
        {
            var pagamentoCriado = CriarPagamento(true);
            //Aguarda 5 segundos para o pagamento ficar como AUTHORIZED no moip
            Thread.Sleep(5000);
            var pagamento = v2Client.CapturarPagamentoPreAutorizado(pagamentoCriado.Id);
            Assert.AreEqual(PaymentStatusType.AUTHORIZED, pagamento.Status);
        }

        [TestMethod()]
        public void CancelarPagamentoPreAutorizadoTest()
        {
            var pagamentoCriado = CriarPagamento(true);
            //Aguarda 5 segundos para o pagamento ficar como AUTHORIZED no moip
            Thread.Sleep(5000);
            var pagamento = v2Client.CancelarPagamentoPreAutorizado(pagamentoCriado.Id);
            Assert.AreEqual(PaymentStatusType.CANCELLED, pagamento.Status);
        } 
        #endregion
    }
}