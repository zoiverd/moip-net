using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace Moip.Net.JsonResolvers
{
    public class MoipContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            var snakeCase = Regex.Replace(propertyName, "([A-Z])", "_$1").ToLower().Trim('_');
            return snakeCase;
        }
        
    }
}
