using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestField
{
    class Program
    {
        private static readonly string url = "https://localhost:5001/values";

        static async Task Main()
        {
            string answer;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    answer = await response.Content.ReadAsStringAsync();
                }
            }

            var receivedObject = JsonConvert.DeserializeObject<TestModel>(answer);

            System.Console.WriteLine(receivedObject.Age);
            System.Console.WriteLine(receivedObject.Name);

            System.Console.ReadLine();
        }
    }
}
