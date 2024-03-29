﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.API
{
    public static class ShopApiProcessor
    {
        public static async Task<string> LoadShopInfo()
        {
            string url = "";

            url = "https://localhost:44372/api/values";// 2b added


            try
            {
                using (HttpResponseMessage response = await ShopApiClient.ApiClient.GetAsync(url))
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
            catch
            {
                return string.Empty;
            }
        }
    }
}
