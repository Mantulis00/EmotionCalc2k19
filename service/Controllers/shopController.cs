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
           // return $"<BasicLootBox>{prices.BasicLootBox}<BasicLootBox>\n<PremiumLootBox>{prices.PremiumLootBox}</PremiumLootBox>";
        }

        /*
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
