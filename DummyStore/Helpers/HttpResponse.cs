using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DummyStore.Helpers
{
    public static class HttpResponse
    {
        public static async Task<HttpResponseMessage> HttpRequestHeaderMethod<T>(string resourceId, HttpMethod httpVerb, string url, T obj)
        {
            ///Token Generation method with request header
            //AuthenticationResult BearerToken = null;

            //if (!string.IsNullOrEmpty(resourceId))
            //{
            //    AzureADAccessToken azureADAccessToken = new AzureADAccessToken(appConfiguration.Value.IdaTokenClientId, appConfiguration.Value.IdaTokenAppKey, resourceId, appConfiguration);
            //    BearerToken = await azureADAccessToken.AcquireToken();
            //    Token = BearerToken.AccessToken.ToString();
            //}

            using (var client = new System.Net.Http.HttpClient())
            {
                HttpRequestMessage request = null;
                HttpResponseMessage response = null;
                //int HttpClientTimeOut = appConfiguration.Value.HttpClientTimeout;
                //client.Timeout = System.TimeSpan.FromSeconds(HttpClientTimeOut);
                request = new HttpRequestMessage(httpVerb, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                if (obj != null && obj.GetType() != typeof(int) && obj.GetType() != typeof(string) && obj.GetType() != typeof(decimal))
                {
                    var json = JsonConvert.SerializeObject(obj, Formatting.None);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = content;
                }
                response = await client.SendAsync(request);
                return response;
            }

        }

    }
}
