using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestField
{
    class Program
    {
        private static readonly string url = "https://localhost:5001/api/values";
        private static readonly string url1 = "https://localhost:5001/api/currency";

        static void Main()
        {
            var receivedObject = GetAsync<TestModel>(url).Result;
            var receivedObject1 = GetAsync<CurrencyModel>(url1).Result;

            System.Console.WriteLine(receivedObject.Age);
            System.Console.WriteLine(receivedObject.Name);

            System.Console.WriteLine();

            System.Console.WriteLine(receivedObject1.JoyCoins);
            System.Console.WriteLine(receivedObject1.JoyGems);

            System.Console.ReadLine();
        }

        private static async Task<T> GetAsync<T>(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    string answer = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(answer);
                }
            }
        }
    }
}
