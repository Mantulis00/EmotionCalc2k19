using System.Net.Http;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.Web
{
    static class ImageDownloader
    {
        public static async Task<byte[]> GetByteArrayFromUrlAsync(string imageURL)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetByteArrayAsync(imageURL);
            }
        }
    }
}