using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Moip.NetTests
{
    public static class Settings
    {
        public static Uri ApiUri
        {
            get
            {
                return new Uri(ConfigurationManager.AppSettings["ApiUri"]);
            }
        }

        public static string ApiToken
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiToken"];
            }
        }

        public static string ApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiKey"];
            }
        }
        
    }
}
