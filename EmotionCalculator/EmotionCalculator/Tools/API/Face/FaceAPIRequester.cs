using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    class FaceAPIRequester
    {
        private FaceAPIKey apiKey;

        internal FaceAPIRequester(FaceAPIKey faceAPIKey)
        {
            apiKey = faceAPIKey;
        }

        public async Task<string> RequestImageDataAsync(string imageURL)
        {
            var image = (await Web.ImageDownloader.GetByteArrayFromUrlAsync(imageURL));

            return await RequestImageDataAsync(image);
        }

        public async Task<string> RequestImageDataAsync(byte[] imageByteArray)
        {
            using (HttpClient client = new HttpClient())
            {
                //API reference:
                //https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey.SubscriptionKey);

                string requestParameters = "&returnFaceAttributes=emotion";
                string requestURL = apiKey.APIEndpoint + "/detect?" + requestParameters;

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
