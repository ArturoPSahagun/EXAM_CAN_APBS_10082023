using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace surtidora_api.Models
{
    public class Auth
    {
        public static readonly HttpClient client = new HttpClient();

        public static bool Check(string token)
        {
            string authCode;
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://sdcentro.surtidoradepartamental.com:8077/ServiciosKosmos/api/serv/Reporte"))
            {
                Auth.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = Auth.client.SendAsync(request);
                response.Wait();
                authCode = response.Result.StatusCode.ToString();
            }

            return (authCode == "OK");
        }

    }
}