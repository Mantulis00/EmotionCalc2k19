using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.User;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestField
{
    class Program
    {
        private static readonly string uri = "https://localhost:5001/api/UserData";
        private static readonly HttpClient client = new HttpClient();

        static void Main()
        {
            var receivedObject = GetAsync<UserData>(uri).Result;

            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            receivedObject.AddCurrency(CurrencyType.JoyCoin, 20);
            Post(uri, receivedObject);

            receivedObject = GetAsync<UserData>(uri).Result;

            System.Console.WriteLine(receivedObject.JoyCoins);
            System.Console.WriteLine(receivedObject.JoyGems);

            System.Console.WriteLine();

            client.Dispose();
            System.Console.ReadLine();
        }

        private static async Task<T> GetAsync<T>(string uri)
        {
            using (HttpResponseMessage response = await client.GetAsync(uri))
            {
                string answer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(answer);
            }
        }

        private static void Post<T>(string uri, T t)
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json"))
            using (var httpResponse = client.PostAsync(uri, httpContent).Result)
            {

            }
        }
    }
}
