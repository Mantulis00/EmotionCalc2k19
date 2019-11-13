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

        public  async Task<string> LoadShop()
        {
            string info = await ShopApiProcessor.LoadShopInfo();
            Console.WriteLine("u" + info); // codeAPI
            return info;

        }


    }
}
