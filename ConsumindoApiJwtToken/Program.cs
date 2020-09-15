using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace ConsumindoApiJwtToken
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            using (var http = new HttpClient())
            {
                var response = await http.PostAsync("https://localhost:44356/api/auth/token",null);
                var bearerToken = response.Content.ReadAsStringAsync().Result;


                var requestData = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:44356/api/values")
                };

                requestData.Headers.TryAddWithoutValidation("Authorization", String.Format("Bearer {0}", bearerToken));

                var respo = await http.SendAsync(requestData);
                var resultado = await  respo.Content.ReadAsStringAsync();
            }


            Console.WriteLine("Hello World!");
        }
    }
}
