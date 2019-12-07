using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmotionCalculator.Tools.IO.Android
{
    class EmotionClient
    {
        private static EmotionClient _instance;
        public static EmotionClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmotionClient();

                return _instance;
            }
        }

        private readonly HttpClient client;

        private EmotionClient()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            using (HttpResponseMessage response = await client.GetAsync(uri))
            {
                string answer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(answer);
            }
        }
    }
}
