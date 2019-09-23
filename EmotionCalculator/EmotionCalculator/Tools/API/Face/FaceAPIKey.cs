
namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    struct FaceAPIKey
    {
        internal string SubscriptionKey { private set; get; }
        internal string APIEndpoint { private set; get; }

        internal FaceAPIKey(string subscriptionKey, string apiEndpoint)
        {
            SubscriptionKey = subscriptionKey;
            APIEndpoint = apiEndpoint;
        }
    }
}
