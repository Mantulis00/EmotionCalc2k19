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

        private IUserLoader userLoader;

        private UserData userData;

        internal CurrencyManager CurrencyManager { get; set; }

        public MonthManager(IMonthLogger monthLogger, IMonthUpdatable monthUpdatable,
            DateTime startingDate, IUserLoader userLoader)
        {
            this.monthLogger = monthLogger;
            this.monthUpdatable = monthUpdatable;

            monthEmotions = monthLogger.LoadMonth(startingDate.Year, (Month)startingDate.Month);

            this.userLoader = userLoader;
            userData = userLoader.Load();

            CurrencyManager = new CurrencyManager(userData);

            ChangeTime(startingDate);
        }

        internal delegate void LaunchLoginPopup(int dailyStreak, Action claimReward);

        internal void RaiseLoginEvent(LaunchLoginPopup launchLoginPopup)
        {
            if (userData.LastLogin != DateTime.Today
                || userData.DailyStreak == 0)
            {
                userData.Login();

                bool claimed = false;

                launchLoginPopup.Invoke(
                    userData.DailyStreak,
                    () =>
                    {
                        if (!claimed)
                        {
                            userData.ClaimDaily();
                            claimed = true;
                        }
                    });
            }
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
                    userData.AddCurrency(CurrencyType.JoyCoin, EmotionValue.GetEmotionValueInCoins(emotion));
                    userData.AddCurrency(emotion, 1);
                }
            }
        }

        internal void Save()
        {
            if (monthEmotions != null)
                monthLogger.SaveMonth(monthEmotions);

            if (userData != null)
                userLoader.Save(userData);
        }

        internal void Refresh()
        {
            monthUpdatable.Update(monthEmotions, selectedTime);
            userData.Update();
        }
    }
}
