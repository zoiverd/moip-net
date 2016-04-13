using Newtonsoft.Json.Serialization;

namespace Moip.Net.V2.Configuration
{
    public class V2ContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var camelCase = propertyName[0].ToString().ToLower() + propertyName.Substring(1);
            return camelCase;
        }

    }
}
