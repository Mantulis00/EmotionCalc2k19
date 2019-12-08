using EmotionCalculator.EmotionCalculator.Logic.User;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidUserLoader : IUserLoader
    {
        static readonly string uri = "https://localhost:5001/api/UserData";

        public UserData Load()
        {
            return EmotionClient.Instance.GetAsync<UserData>($"{uri}?id={1}").Result;
        }

        public void Save(UserData userData)
        {
            EmotionClient.Instance.Post($"{uri}?id={1}", userData);
        }
    }
}