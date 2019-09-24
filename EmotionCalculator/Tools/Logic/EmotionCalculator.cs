using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Tools.Logic
{
    class EmotionCalculator
    {
        private static readonly float dominationPoint = 0.5f;

        internal static Emotion GetEmotion(EmotionData emotionData)
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
