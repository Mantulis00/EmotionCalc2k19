using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System.Collections.Generic;
using System.Linq;
using WebService;

namespace EntityFrameworkClasses.EF
{
    public static class UsersTableManager
    {
        public static IEnumerable<Users> SelectUsers()
        {
            using (var db = new EmotionDBContext())
            {
                return db.Users;
            }
        }

        public static void Update(int id, string url, string key)
        {
            using (var db = new EmotionDBContext())
            {
                var users = from user in db.Users
                            where user.Id == id
                            select user;

                foreach (var user in users)
                {
                    user.ApiUrl = url;
                    user.ApiKey = key;
                }

                db.SaveChanges();
            }
        }

        public static void Insert(string url, string key)
        {
            using (var db = new EmotionDBContext())
            {
                db.Users.Add(new Users()
                {
                    ApiUrl = url,
                    ApiKey = key,
                });

                db.SaveChanges();
            }
        }

        public static int SelectId(FaceAPIKey key)
        {
            using (var db = new EmotionDBContext())
            {
                var users = from user in db.Users
                            where user.ApiKey == key.SubscriptionKey
                            && user.ApiUrl == key.APIEndpoint
                            select user;

                if (users.Count() == 0)
                {
                    Insert(key.SubscriptionKey, key.APIEndpoint);
                }

                return users.First().Id;
            }
        }

        internal static void Delete(int id)
        {
            using (var db = new EmotionDBContext())
            {
                var users = from user in db.Users
                            where user.Id == id
                            select user;

                db.Users.RemoveRange(users);

                db.SaveChanges();
            }
        }

        public static FaceAPIKey SelectKey(int id)
        {
            using (var db = new EmotionDBContext())
            {
                var users = from user in db.Users
                            where user.Id == id
                            select user;

                if (users.Count() == 0)
                {
                    Insert(string.Empty, string.Empty);
                }

                var first = users.First();

                return new FaceAPIKey(first.ApiKey, first.ApiUrl);
            }
        }
    }
}
