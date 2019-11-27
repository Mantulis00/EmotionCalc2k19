using EmotionCalculator.EmotionCalculator.Tools.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    public class FaceAPIRequester : IAPIRequester
    {
        public FaceAPIKey APIKey { get; set; }

        internal FaceAPIRequester(FaceAPIKey faceAPIKey)
        {
            APIKey = faceAPIKey;
        }

        public async Task<APIParseResult> RequestParseResultAsync(string imageURL)
        {
            byte[] image = await ImageDownloader
                .GetByteArrayFromUrlAsync(imageURL);

            return await RequestParseResultAsync(image);
        }

        public async Task<APIParseResult> RequestParseResultAsync(byte[] imageByteArray)
        {
            using (HttpClient client = new HttpClient())
            {
                //API reference:
                //https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIKey.SubscriptionKey);

                string requestParameters = "&returnFaceAttributes=emotion";
                string requestURL = APIKey.APIEndpoint + "/detect?" + requestParameters;

                using (ByteArrayContent content = new ByteArrayContent(imageByteArray))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    HttpResponseMessage response = await client.PostAsync(requestURL, content);

                    //JSON file
                    string responseString = await response.Content.ReadAsStringAsync();

                    APIParseResult parseResult = FaceAPIParser.ParseJSON(responseString);

                    return parseResult;
                }
            }
        }
    }
}
