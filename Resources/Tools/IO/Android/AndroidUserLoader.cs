using EmotionCalculator.EmotionCalculator.Logic.User;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidUserLoader : IUserLoader
    {
        readonly string uri = "https://localhost:5001/api/UserData";

        public UserData Load()
        {
            return EmotionClient.Instance.GetAsync<UserData>(uri).Result;
        }

        public void Save(UserData userData)
        {
            return;
        }
    }
}