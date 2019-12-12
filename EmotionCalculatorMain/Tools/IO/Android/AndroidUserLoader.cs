using EmotionCalculator.EmotionCalculator.Logic.User;
using System.Linq;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidUserLoader : IUserLoader
    {
        static readonly string uri = "http://10.0.2.2:5001/api/UserData";

        public UserData Load(int id)
        {
            return EmotionClient.Instance.GetAsync<UserData>($"{uri}?id={id}").Result;
        }

        public void Save(UserData userData, int id)
        {
            System.Console.WriteLine(userData);
            System.Console.WriteLine(id);
            System.Console.WriteLine(userData.OwnedItems.Items.Count());
            System.Console.WriteLine("Saving UserData.");
            EmotionClient.Instance.Put($"{uri}?id={id}", userData);
        }
    }
}