using EmotionCalculator.EmotionCalculator.Tools.API.Containers;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    class EmotionValue
    {
        public static int GetEmotionValueInCoins(Emotion emotion)
        {
            switch (emotion)
            {
                default:
                case Emotion.NotSet:
                    return 0;
                case Emotion.Emotionless:
                    return 5;
                case Emotion.Anger:
                    return 10;
                case Emotion.Contempt:
                    return 10;
                case Emotion.Disgust:
                    return 10;
                case Emotion.Fear:
                    return 10;
                case Emotion.Happiness:
                    return 50;
                case Emotion.Neutral:
                    return 20;
                case Emotion.Sadness:
                    return 15;
                case Emotion.Surprise:
                    return 35;
            }
        }
    }
}
