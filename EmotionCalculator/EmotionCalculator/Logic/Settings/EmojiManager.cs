﻿using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using EmotionCalculator.EmotionCalculator.Tools.FileHandler;
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
                   [Emotion.Anger] = Properties.Resources.emojiAnger,
                   [Emotion.Contempt] = Properties.Resources.emojiContempt,
                   [Emotion.Disgust] = Properties.Resources.emojiDisguist,
                   [Emotion.Fear] = Properties.Resources.emojiFear,
                   [Emotion.Happiness] = Properties.Resources.emojiHappiness,
                   [Emotion.Neutral] = Properties.Resources.emojiNeutral,
                   [Emotion.Sadness] = Properties.Resources.emojiSadness,
                   [Emotion.Surprise] = Properties.Resources.emojiSurprise,
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