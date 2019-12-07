using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private static UserData data = new UserData(0, 0, 0, DateTime.Now,
                Enumerable.Empty<KeyValuePair<Emotion, int>>(), new OwnedItems());

        [HttpGet]
        public ActionResult<UserData> Get()
        {
            return data;
        }

        [HttpPost]
        public void Post(UserData userData)
        {
            data = userData;
        }
    }
}