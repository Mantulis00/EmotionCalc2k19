using System.Net;

namespace EmotionCalculator.EmotionCalculator.Tools.Web
{
    class ImageDownloader
    {
        public static byte[] GetByteArrayFromUrl(string imageURL)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(imageURL);
            }
        }
    }
}