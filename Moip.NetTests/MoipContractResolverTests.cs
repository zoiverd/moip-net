using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moip.Net.Assinaturas.Tests
{
    [TestClass()]
    public class MoipContractResolverTests
    {
        [TestMethod()]
        public void ResolvePropertyNameTest()
        {
            var resolver = new AssinaturasMoipContractResolver();
            var privateClass = new PrivateObject(resolver);
            string retorno = (string)privateClass.Invoke("ResolvePropertyName", "SnakeCase");
            Assert.AreEqual(retorno, "snake_case");
        }
        
    }
}