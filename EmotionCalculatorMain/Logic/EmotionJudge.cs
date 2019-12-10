using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic
{
    public static class EmotionJudge
    {
        private static readonly float dominationPoint = 0.3f;

        public static Emotion GetEmotion(this EmotionData emotionData)
        {
            //Emotion calculations

            KeyValuePair<Emotion, float> emotionPair =
                emotionData.EmotionValues.OrderByDescending(number => number.Value).First();

            if (emotionPair.Value >= dominationPoint)
                return emotionPair.Key;
            else
                return Emotion.Emotionless;
        }
    }
}
