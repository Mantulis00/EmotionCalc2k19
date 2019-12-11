using EmotionCalculator.EmotionCalculator.Tools.API.Face;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidAPILoader
    {
        static readonly string uri = "https://localhost:5001/api/User";

        public static FaceAPIKey Load(int id)
        {
            return EmotionClient.Instance.GetAsync<FaceAPIKey>($"{uri}/Key?id={id}").Result;
        }

        public static int Load(FaceAPIKey key)
        {
            return EmotionClient.Instance.PutAsync<int, FaceAPIKey>(uri + "/Id", key).Result;
        }

        public static void Save(FaceAPIKey key, int id)
        {
            EmotionClient.Instance.Put($"{uri}?id={id}", key);
        }

        public static void ClearAsync(int id)
        {
            EmotionClient.Instance.DeleteAsync($"{uri}?id={id}");
        }
    }
}
