using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using EntityFrameworkClasses.EF;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPut]
        public void Put(FaceAPIKey key, int id)
        {
            try
            {
                UsersTableManager.Update(id, key.APIEndpoint, key.SubscriptionKey);
            }
            catch
            {
                //Insert failed (shared id?)
            }
        }

        [HttpPut]
        [Route("Id")]
        public ActionResult<int> Put(FaceAPIKey key)
        {
            try
            {
                return UsersTableManager.SelectId(key);
            }
            catch
            {
                //Select failed (doesn't exist)
                return -1;
            }
        }

        [HttpGet]
        [Route("Key")]
        public ActionResult<FaceAPIKey> Get(int id)
        {
            try
            {
                return UsersTableManager.SelectKey(id);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.InnerException);
                System.Console.WriteLine(e.Data);
                return null;
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                UsersTableManager.Delete(id);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.InnerException);
                System.Console.WriteLine(e.Data);
                //
            }
        }
    }
}