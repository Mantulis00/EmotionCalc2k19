using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string GetShopInfo()
        {
            Models.ConsumablePrices prices = new Models.ConsumablePrices();

            prices.BasicLootBox = 2;
            prices.PremiumLootBox = 4;

            XElement xml = new XElement("LootBoxes",
                new XElement("Basic", 2),
                new XElement("Premium", 4));


            return xml.ToString();
        }

       
    }
}
