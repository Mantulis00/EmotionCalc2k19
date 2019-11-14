using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.API
{
    public static class ShopApiProcessor
    {
        public static async Task<string> LoadShopInfo()
        {
            string url = "";

            url = "http://localhost:59589/api/values";// 2b added

            using (HttpResponseMessage response = await FirstAPI.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string shop = await response.Content.ReadAsStringAsync();
                    return shop;
                }
                else
                {
                    throw new Exception("No response from API :(");
                }
            }
        }
    }
}
