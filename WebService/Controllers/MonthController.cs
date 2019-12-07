using EmotionCalculator.EmotionCalculator.Logic.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<MonthEmotions> Get(int year, int month)
        {
            return new MonthEmotions(year, (Month)month);
        }
    }
}