using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmoCalc.Tools
{
    class TempAPI
    {
        public static async Task<string> RequestImageData(byte[] imageByteArray, string endpointURL, string subscriptionKey)
        {
            using (HttpClient client = new HttpClient())
            {
                //API reference:
                //https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters = "&returnFaceAttributes=emotion";
                string requestURL = endpointURL + "/detect?" + requestParameters;

                using (ByteArrayContent content = new ByteArrayContent(imageByteArray))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    HttpResponseMessage response = await client.PostAsync(requestURL, content);

                    string responseString = await response.Content.ReadAsStringAsync();

                    //JSON file
                    return responseString;
                }
            }
        }
    }
}