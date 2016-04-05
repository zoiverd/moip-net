using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moip.Net.JsonResolvers.Tests
{
    [TestClass()]
    public class MoipContractResolverTests
    {
        [TestMethod()]
        public void ResolvePropertyNameTest()
        {
            var resolver = new MoipContractResolver();
            var privateClass = new PrivateObject(resolver);
            string retorno = (string)privateClass.Invoke("ResolvePropertyName", "SnakeCase");
            Assert.AreEqual(retorno, "snake_case");
        }
        
    }
}