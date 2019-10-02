﻿using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    [Serializable]
    class MonthEmotions
    {
        private Dictionary<int, Emotion> emotions = new Dictionary<int, Emotion>();

        internal Emotion this[int dayOfTheMonth]
        {
            get
            {
                if (emotions.ContainsKey(dayOfTheMonth))
                    return emotions[dayOfTheMonth];
                else
                    return Emotion.NotSet;
            }
        }

        internal int Year { get; private set; }
        internal Month Month { get; private set; }

        internal MonthEmotions(int year, Month month)
        {
            Year = year;
            Month = month;
        }

        internal void SetEmotion(int dayOfTheMonth, Emotion emotion)
        {
            if (emotions.ContainsKey(dayOfTheMonth))
                emotions.Remove(dayOfTheMonth);

            emotions.Add(dayOfTheMonth, emotion);
        }
    }
}