using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            Console.WriteLine("\n\n\n/////////////////////");

            try
            {
                string connectionString = $"Server={"(localdb)\\MSSQLLocalDB"};Database={"EmotionDB"}";

                using (SqlConnection connection = new SqlConnection(
                    connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT COUNT(*) as number FROM UserData", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["number"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Big error:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("/////////////////////\n\n\n");

            return data;
        }

        [HttpPost]
        public void Post(UserData userData)
        {
            data = userData;
        }
    }
}