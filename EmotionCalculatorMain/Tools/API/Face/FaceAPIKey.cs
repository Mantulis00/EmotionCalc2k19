
namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    public struct FaceAPIKey
    {
        public string SubscriptionKey { private set; get; }
        public string APIEndpoint { private set; get; }

        public FaceAPIKey(string subscriptionKey, string apiEndpoint)
        {
            SubscriptionKey = subscriptionKey;
            APIEndpoint = apiEndpoint;
        }
    }
}
