using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EmotionCalculator.EmotionCalculator.API
{
    class CallApi
    {
        public int BasicLootBoxPrice { get; private set;}
        public int PremiumLootBoxPrice { get; private set; }

        public CallApi()
        {
            FirstAPI.Init();
            LoadShopPrices();
        }

        public  async Task<string> LoadShop()
        {
            string info = await ShopApiProcessor.LoadShopInfo();
           // Console.WriteLine("u" + info); // codeAPi

            return info;

        }

        private async void LoadShopPrices()
        {
            API.CallApi ob = new API.CallApi();
            string text = await ob.LoadShop();

            XmlDocument xml = new XmlDocument();

            ///////////////////////////////////////////////////////
            string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (text.StartsWith(_byteOrderMarkUtf8))
            {
                text = text.Remove(0, _byteOrderMarkUtf8.Length);
            }
            text = text.Replace("\\r", "");
            text = text.Replace("\\t", "");
            text = text.Replace("\"", "");
            text = text.Replace("\\n", "");
            /////////////////////////////////////////////////////////


            xml.LoadXml(text);

            XmlNodeList nodes = xml.SelectNodes("/LootBoxes");


            foreach (XmlNode x in nodes[0].ChildNodes)
            {
                if (x.Name == "Basic")
                    BasicLootBoxPrice = Int32.Parse(x.InnerText);
                else if (x.Name == "Premium")
                    PremiumLootBoxPrice = Int32.Parse(x.InnerText);
            }


        }



    }
}
