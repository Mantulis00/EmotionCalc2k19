using EmotionCalculator.EmotionCalculator.Logic.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Dictionary<SettingType, SettingStatus>> Get()
        {
            return new Dictionary<SettingType, SettingStatus>();
        }
    }
}