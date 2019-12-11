using EmotionCalculator.EmotionCalculator.Logic.User;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidUserLoader : IUserLoader
    {
        static readonly string uri = "https://localhost:5001/api/UserData";

        public UserData Load(int id)
        {
            return EmotionClient.Instance.GetAsync<UserData>($"{uri}?id={id}").Result;
        }

        public void Save(UserData userData, int id)
        {
            EmotionClient.Instance.Put($"{uri}?id={id}", userData);
        }
    }
}