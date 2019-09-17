using System.Net;

namespace EmoCalc.Tools
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