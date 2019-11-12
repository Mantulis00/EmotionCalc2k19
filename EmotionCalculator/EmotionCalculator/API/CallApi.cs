using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.API
{
    class CallApi
    {
        public CallApi()
        {
            FirstAPI.Init();
        }

        public async Task LoadShop()
        {
            string text = await ShopApiProcessor.LoadShopInfo();
            Console.WriteLine(text);
        }

    }
}
