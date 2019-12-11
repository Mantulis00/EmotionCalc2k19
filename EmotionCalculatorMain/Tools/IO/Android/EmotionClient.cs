using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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

        public async Task<T> PutAsync<T, S>(string uri, S s)
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json"))
            using (var httpResponse = client.PutAsync(uri, httpContent).Result)
            {
                string answer = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(answer);
            }
        }

        public void Put<T>(string uri, T t)
        {
            using (var httpContent = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json"))
            using (var httpResponse = client.PutAsync(uri, httpContent).Result)
            {

            }
        }

        internal async Task DeleteAsync(string uri)
        {
            using (var httpResponse = await client.DeleteAsync(uri))
            {

            }
        }
    }
}
