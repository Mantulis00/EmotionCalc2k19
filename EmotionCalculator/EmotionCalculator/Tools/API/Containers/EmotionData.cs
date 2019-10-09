using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Containers
{
    class EmotionData
    {
        internal ReadOnlyDictionary<Emotion, float> EmotionValues { get; }

        internal EmotionData(
            float anger = 0, float contempt = 0, float disgust = 0, float fear = 0,
            float happiness = 0, float neutral = 0, float sadness = 0, float surprise = 0)
        {
            EmotionValues = new ReadOnlyDictionary<Emotion, float>(
                new Dictionary<Emotion, float>()
                {
                    [Emotion.Anger] = anger,
                    [Emotion.Contempt] = contempt,
                    [Emotion.Disgust] = disgust,
                    [Emotion.Fear] = fear,
                    [Emotion.Happiness] = happiness,
                    [Emotion.Neutral] = neutral,
                    [Emotion.Sadness] = sadness,
                    [Emotion.Surprise] = surprise,
                });
        }
    }
}
