﻿using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic
{
    public class MonthManager
    {
        private readonly UserData userData;

        private readonly IMonthLogger monthLogger;

        private MonthEmotions monthEmotions;
        private DateTime selectedTime;

        public event EventHandler<EmotionArgs> StatusChanged;

        internal MonthManager(UserData userData, IMonthLogger monthLogger)
        {
            this.userData = userData;
            this.monthLogger = monthLogger;
            selectedTime = DateTime.Now;

            monthEmotions = monthLogger.LoadMonth(selectedTime.Year, (Month)selectedTime.Month);

            ChangeTime(selectedTime);
        }

        public void ChangeTime(DateTime newDateTime)
        {
            if (selectedTime.Year != newDateTime.Year
                || selectedTime.Month != newDateTime.Month)
            {
                if (monthEmotions != null)
                    monthLogger.SaveMonth(monthEmotions);

                monthEmotions = monthLogger.LoadMonth(newDateTime.Year, (Month)newDateTime.Month);
            }

            selectedTime = newDateTime;
            StatusChanged?.Invoke(this, new EmotionArgs(monthEmotions.AsReadOnly(), newDateTime));
        }

        public void SetEmotion(Emotion emotion)
        {
            if (monthEmotions != null)
            {
                if (monthEmotions[selectedTime.Day] == Emotion.NotSet)
                {
                    monthEmotions.SetEmotion(selectedTime.Day, emotion);
                    StatusChanged?.Invoke(this, new EmotionArgs(monthEmotions.AsReadOnly(), selectedTime));
                    userData.AddCurrency(CurrencyType.JoyCoin, EmotionValue.GetEmotionValueInCoins(emotion));
                    userData.AddCurrency(emotion, 1);
                }
            }
        }

        internal void Save()
        {
            if (monthEmotions != null)
                monthLogger.SaveMonth(monthEmotions);

        }

        public void Refresh()
        {
            if (monthEmotions != null)
                StatusChanged?.Invoke(this, new EmotionArgs(monthEmotions.AsReadOnly(), selectedTime));
        }
    }
}
