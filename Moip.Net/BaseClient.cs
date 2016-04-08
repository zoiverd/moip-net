using Moip.Net.JsonResolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Moip.Net
{
    public abstract class BaseClient
    {
        #region Properties
        private readonly string ApiToken;
        private readonly string ApiKey;
        private readonly Uri ApiUri;
        private const string UserAgent = "Moip.NET.v0.0.1";
        private readonly Encoding encoding = Encoding.UTF8;
        #endregion

        public BaseClient(Uri apiUri, string apiToken, string apiKey)
        {
            ApiUri = apiUri;
            ApiToken = apiToken;
            ApiKey = apiKey;
        }

        #region JsonSerializerSettings

        public static JsonSerializerSettings _jsonSettings;
        public static JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings();
                    _jsonSettings.Converters.Add(new StringEnumConverter());
                    _jsonSettings.Formatting = Formatting.Indented;
                    _jsonSettings.ContractResolver = new MoipContractResolver();
                    _jsonSettings.NullValueHandling = NullValueHandling.Ignore;
                }
                return _jsonSettings;
            }
        }


        public static string ToJson(object item)
        {
            return JsonConvert.SerializeObject(item, JsonSettings);

        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        } 

        #endregion

        #region DoRequest

        protected virtual WebRequest CreateRequest(string method, Uri uri)
        {
            WebRequest webRequest = (WebRequest)WebRequest.Create(uri);
            webRequest.Method = method;
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;
            if (httpRequest != null)
            {
                httpRequest.UserAgent = UserAgent;
            }

            webRequest.Headers["Authorization"] = GetAuthorizationHeader();

            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                webRequest.ContentType = "application/json";
            }
            return webRequest;
        }

        private string GetAuthorizationHeader()
        {
            var base64Key = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", ApiToken, ApiKey)));
            return string.Format("Basic {0}", base64Key);
        }

        private string GetResponseAsString(WebResponse response)
        {
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
            {
                return sr.ReadToEnd();
            }
        }

        protected virtual T DoRequest<T>(Uri uri)
        {
            return DoRequest<T>(uri, "GET", null);
        }

        protected virtual T DoRequest<T>(Uri uri, string method)
        {
            return DoRequest<T>(uri, method, null);
        }

        protected virtual T DoRequest<T>(Uri uri, string method, string body)
        {
            var json = DoRequest(uri, method, body);
            return FromJson<T>(json);
        }

        protected virtual string DoRequest(Uri uri)
        {
            return DoRequest(uri, "GET", null);
        }

        protected virtual string DoRequest(Uri uri, string method)
        {
            return DoRequest(uri, method, null);
        }

        protected virtual string DoRequest(Uri uri, string method, string body)
        {
            string result = null;
            WebRequest req = CreateRequest(method, uri);

            if (body != null)
            {
                byte[] bytes = encoding.GetBytes(body.ToString());
                req.ContentLength = bytes.Length;
                using (Stream st = req.GetRequestStream())
                {
                    st.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                using (WebResponse resp = (WebResponse)req.GetResponse())
                {
                    result = GetResponseAsString(resp);
                }
            }
            catch (WebException wexc)
            {
                var httpResponse = wexc.Response as HttpWebResponse;
                if (httpResponse != null)
                {
                    string jsonResult = GetResponseAsString(wexc.Response);

                    if(httpResponse.ContentType.IndexOf("json") < 0 || string.IsNullOrEmpty(jsonResult))
                    {
                        throw new MoipException(string.Format("Erro ao acessar {0} - {1}", httpResponse.ResponseUri, httpResponse.StatusDescription), httpResponse.StatusCode);
                    }

                    if(httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new MoipException("APIKey ou Token inválidos.", httpResponse.StatusCode);
                    }

                    var responseError = FromJson<ResponseError>(jsonResult);
                    throw new MoipException(responseError, httpResponse.StatusCode);
                }
                throw;
            }
            return result;
        }
        
        protected virtual Uri PathToUri(string path, string query = null)
        {
            UriBuilder uriBuilder = new UriBuilder(ApiUri);
            uriBuilder.Path = path;
            if (!string.IsNullOrEmpty(query))
            {
                uriBuilder.Query = query;
            }
            return uriBuilder.Uri;
        }

        #endregion

    }
}
