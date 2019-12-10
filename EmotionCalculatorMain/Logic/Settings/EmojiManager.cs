using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using EmotionCalculator.Properties;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    public class EmojiManager
    {
        private static readonly Dictionary<Emotion, byte[]> emojis =
               new Dictionary<Emotion, byte[]>()
               {
                   [Emotion.Anger] = Resources.emojiAnger,
                   [Emotion.Contempt] = Resources.emojiContempt,
                   [Emotion.Disgust] = Resources.emojiDisguist,
                   [Emotion.Fear] = Resources.emojiFear,
                   [Emotion.Happiness] = Resources.EmojiHappiness1,
                   [Emotion.Neutral] = Resources.emojiNeutral,
                   [Emotion.Sadness] = Resources.emojiSadness,
                   [Emotion.Surprise] = Resources.emojiSurprise,
               };

        public static bool TryGetEmojiImage(Emotion emotion, out byte[] image)
        {
            if (emojis.ContainsKey(emotion))
            {
                image = emojis[emotion];
                return true;
            }
            else
            {
                image = default;
                return false;
            }
        }
    }

}
