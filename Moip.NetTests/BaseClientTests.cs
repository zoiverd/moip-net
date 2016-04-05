using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moip.Net.Tests
{
    [TestClass()]
    public class BaseClientTests
    {
        public class TestJsonSerializer
        {
            public string NomeCompleto { get; set; }
            public int Idade { get; set; }
            public TipoCliente Tipo { get; set; }
            public enum TipoCliente
            {
                ATIVO,
                INATIVO
            }
        }
        private string jsonTest = @"{
  ""nome_completo"": ""Rafael Gonçalves"",
  ""idade"": 19,
  ""tipo"": ""ATIVO""
}";

        [TestMethod()]
        public void ToJsonTest()
        {
            var json = BaseClient.ToJson(new TestJsonSerializer
            {
                NomeCompleto = "Rafael Gonçalves",
                Idade = 19,
                Tipo = TestJsonSerializer.TipoCliente.ATIVO
            });

            Assert.AreEqual(jsonTest, json);
        }

        [TestMethod()]
        public void FromJsonTest()
        {
            var obj = BaseClient.FromJson<TestJsonSerializer>(jsonTest);

            Assert.AreEqual("Rafael Gonçalves", obj.NomeCompleto);
            Assert.AreEqual(19, obj.Idade);
            Assert.AreEqual(TestJsonSerializer.TipoCliente.ATIVO, obj.Tipo);
        }
    }
}