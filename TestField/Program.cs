using System.Net.Http;

namespace TestField
{
    class Program
    {
        private static readonly string url = "https://localhost:5001/api/values";

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                System.Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            System.Console.ReadLine();
        }
    }
}
