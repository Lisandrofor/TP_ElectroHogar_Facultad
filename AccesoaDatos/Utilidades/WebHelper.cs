using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;


namespace AccesoaDatos.Utilidades
{
    internal static class WebHelper
    {
        static HttpClient cliente = new HttpClient();
        static string rutaBase = "https://cai-tp.azurewebsites.net";

        public static HttpResponseMessage Get(string url)
        {
            var uri = rutaBase + url;

            HttpResponseMessage response = cliente.GetAsync(uri).Result;  // Blocking call!

            return response;
        }

        public static HttpResponseMessage Post(string url, string jsonRequest)
        {
            var uri = rutaBase + url;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = cliente.PostAsync(uri, data).Result;

            return response;

        }

        public static HttpResponseMessage Put(string url, string jsonRequest)
        {
            var uri = rutaBase + url;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = cliente.PutAsync(uri, data).Result;

            return response;

        }

        public static HttpResponseMessage Patch(string path, string jsonRequest)
        {
            var uri = rutaBase + path;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var request =
                new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = data
                };

            HttpResponseMessage response = cliente.SendAsync(request).Result;

            return response;
        }

        public static HttpResponseMessage DeleteConBody(string url, string jsonRequest)
        {
            var uri = rutaBase + url;

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = cliente.SendAsync(request).Result;

            return response;
        }

        internal static HttpResponseMessage DeleteConBody(string path)
        {
            throw new NotImplementedException();
        }
    }
}
