using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic
{
    class MonthManager
    {
        private IMonthLogger monthLogger;
        private IMonthUpdatable monthUpdatable;

        private MonthEmotions monthEmotions;
        private DateTime selectedTime;

        internal MonthManager(IMonthLogger monthLogger, IMonthUpdatable monthUpdatable, DateTime startingDate)
        {
            this.monthLogger = monthLogger;
            this.monthUpdatable = monthUpdatable;

            monthEmotions = monthLogger.LoadMonth(startingDate.Year, (Month)startingDate.Month);

            ChangeTime(startingDate);
        }

        internal void ChangeTime(DateTime newDateTime)
        {
            if (selectedTime.Year != newDateTime.Year
                || selectedTime.Month != newDateTime.Month)
            {
                if (monthEmotions != null)
                    monthLogger.SaveMonth(monthEmotions);

                monthEmotions = monthLogger.LoadMonth(newDateTime.Year, (Month)newDateTime.Month);
            }

            selectedTime = newDateTime;
            monthUpdatable.Update(monthEmotions, newDateTime);
        }

        internal void SetEmotion(Emotion emotion)
        {
            if (monthEmotions != null)
            {
                monthEmotions.SetEmotion(selectedTime.Day, emotion);
                monthUpdatable.Update(monthEmotions, selectedTime);
            }
        }

        internal void Save()
        {
            if (monthEmotions != null)
                monthLogger.SaveMonth(monthEmotions);
        }
    }
}
