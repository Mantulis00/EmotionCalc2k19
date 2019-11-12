using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.API
{
    public static class ShopApiProcessor
    {
        public static async Task<string> LoadShopInfo()
        {
            string url = "";

            url = "https://localhost:44372/api/values";// 2b added

            using (HttpResponseMessage response = await FirstAPI.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string shop = await response.Content.ReadAsStringAsync();
                    return shop;
                }
                else
                {
                    throw new Exception("gg");
                }

            }

        }

    }
}
