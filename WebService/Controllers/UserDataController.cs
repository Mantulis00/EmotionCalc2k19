using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using EntityFrameworkClasses.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            try
            {
                var data = UserDataTableManager.SelectUserData(id);

                return data;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine(e.StackTrace);

                return new EmotionUserData(0, 0, 0, DateTime.Now,
                            Enumerable.Empty<KeyValuePair<Emotion, int>>(), new EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems());
            }
        }

        [HttpPut]
        public void Put(EmotionUserData userData, int id)
        {
            try
            {
                Console.WriteLine("LISTEN UP:");
                Console.WriteLine(userData.OwnedItems.Items.Count());
                UserDataTableManager.UpdateUserData(id, userData);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine(e.StackTrace);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                UserDataTableManager.DeleteUserData(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine(e.StackTrace);
            }
        }
    }
}