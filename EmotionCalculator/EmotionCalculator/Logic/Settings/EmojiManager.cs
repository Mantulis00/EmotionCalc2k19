using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class EmojiManager
    {
        private Dictionary<Emotion, Image> emojis;
        public  EmojiManager()
        {
            emojis = new Dictionary<Emotion, Image>(
               new Dictionary<Emotion, Image>()
               {
                   [Emotion.Anger] = Properties.Resources.backgroundHalloween,
                   [Emotion.Contempt] = Properties.Resources.backgroundHalloween,
                   [Emotion.Disgust] = Properties.Resources.backgroundHalloween,
                   [Emotion.Fear] = Properties.Resources.backgroundHalloween,
                   [Emotion.Happiness] = Properties.Resources.EmojiHappiness,
                   [Emotion.Neutral] = Properties.Resources.backgroundHalloween,
                   [Emotion.Sadness] = Properties.Resources.backgroundHalloween,
                   [Emotion.Surprise] = Properties.Resources.backgroundHalloween,
               });
        }

        public void GetEmoji(PictureBox box, Emotion emotion)
        {
            if (emojis.ContainsKey(emotion))
                box.Image = emojis[emotion];

           // return box;
        }
    }

}
