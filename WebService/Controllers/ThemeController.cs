using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ThemePack> Get()
        {
            return ThemePackManager.ThemePacks.First();
        }
    }
}