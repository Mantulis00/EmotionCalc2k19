using EmotionCalculator.EmotionCalculator.Logic.User;
using Microsoft.AspNetCore.Mvc;
using WebService.DB;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<UserData> Get(int id)
        {
            System.Console.WriteLine("GET:" + id);
            return UserDataTableManager.SelectUserData(id);
        }

        [HttpPost]
        public void Post(UserData userData, int id)
        {
            System.Console.WriteLine("POST:" + id);
            UserDataTableManager.UpdateUserData(id, userData);
        }
    }
}