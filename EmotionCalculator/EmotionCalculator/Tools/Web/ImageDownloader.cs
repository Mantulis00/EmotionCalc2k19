﻿using System.Net;
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
        public static bool CheckIfValidURL(string imageURL)
        {
            if (imageURL == null || imageURL == "")
            {
                return false;
            }
            HttpWebResponse response = null;
            WebRequest request = null;
            try
            {
                request = WebRequest.Create(imageURL);
            }
            catch (System.UriFormatException)
            {
                return false; 
            }
            request.Method = "HEAD";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return true;
        }
    }
}