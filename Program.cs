using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace lecture1
{
    public class RandomDog
    {
        public string Messange { get; set; }
        public string Status { get; set; }
    }
    public class Response
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SendAsync().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task SendAsync()
        {

            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    first_name = "morpheus",
                    last_name = "leader"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(@"https://reqres.in/api/users", httpContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Response>(content);
                }

            }

            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    first_name = "morpheus",
                    last_name = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var result = await httpClient.PutAsync(@"https://reqres.in/api/users", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var respose = JsonConvert.DeserializeObject<Response>(content);
                }

            }

        }
    }
}
