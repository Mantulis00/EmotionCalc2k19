using EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI;
using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.User;
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

        private IUserUpdatable userUpdatable;
        private IUserLoader userLoader;
        internal UserData UserData { get; private set; }

        internal MonthManager(IMonthLogger monthLogger, IMonthUpdatable monthUpdatable,
            DateTime startingDate, IUserLoader userLoader, IUserUpdatable userUpdatable)
        {
            this.monthLogger = monthLogger;
            this.monthUpdatable = monthUpdatable;

            monthEmotions = monthLogger.LoadMonth(startingDate.Year, (Month)startingDate.Month);

            this.userLoader = userLoader;
            this.userUpdatable = userUpdatable;
            UserData = userLoader.Load();

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
                if (monthEmotions[selectedTime.Day] == Emotion.NotSet)
                {
                    monthEmotions.SetEmotion(selectedTime.Day, emotion);
                    monthUpdatable.Update(monthEmotions, selectedTime);
                    UserData.JoyCoins += EmotionValue.GetEmotionValueInCoins(emotion);
                    userUpdatable.Update(UserData);
                }
            }
        }

        internal void Save()
        {
            if (monthEmotions != null)
                monthLogger.SaveMonth(monthEmotions);

            if (UserData != null)
                userLoader.Save(UserData);
        }

        internal void Refresh()
        {
            monthUpdatable.Update(monthEmotions, selectedTime);
            userUpdatable.Update(UserData);
        }
    }
}
