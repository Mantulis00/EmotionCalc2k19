using EntityFrameworkClasses.DB;
using Microsoft.AspNetCore.Mvc;
using EmotionUserData = EmotionCalculator.EmotionCalculator.Logic.User.UserData;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<EmotionUserData> Get(int id)
        {
            return UserDataTableManager.SelectUserData(id);
        }

        [HttpPut]
        public void Put(EmotionUserData userData, int id)
        {
            try
            {
                UserDataTableManager.UpdateUserData(id, userData);
            }
            catch
            {
                //Update failed (no user?)
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                UserDataTableManager.DeleteUserData(id);
            }
            catch
            {
                //Update failed (no user?)
            }
        }
    }
}