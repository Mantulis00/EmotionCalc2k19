using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CurrencyModel> Get()
        {
            return new CurrencyModel()
            {
                JoyCoins = 50,
                JoyGems = 5
            };
        }
    }
}