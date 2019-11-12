using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.API
{
    class ShopApiProcessor
    {
        public async Task LoadShopInfo()
        {
            string url = "";

            url = "";// 2b added

            using (HttpResponseMessage response = await FirstAPI.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                }

            }

        }

    }
}
