using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic
{
    class MainManager
    {
        private readonly IUserLoader userLoader;
        private readonly UserData userData;

        internal CurrencyManager CurrencyManager { get; }

        internal ReadOnlyUserData ReadOnlyUserData { get; }

        internal SettingsManager SettingsManager { get; }

        internal MonthManager MonthManager { get; }

        public MainManager(IMonthLogger monthLogger, IUserLoader userLoader,
            ISettingsLogger settingsLogger)
        {
            //Private fields
            this.userLoader = userLoader;
            userData = userLoader.Load();
            ReadOnlyUserData = new ReadOnlyUserData(userData);

            //Currency
            CurrencyManager = new CurrencyManager(userData);

            //Settings
            SettingsManager = new SettingsManager(settingsLogger);
            if (SettingsManager.SelectedTheme == null)
                SettingsManager.SelectedTheme = DesktopPack.DesktopPacks.ToList()[0];
            SettingsManager.ValidateSelections(userData);

            //Month management
            MonthManager = new MonthManager(userData, monthLogger);
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

        internal void Save()
        {
            MonthManager.Save();

            if (userData != null)
                userLoader.Save(userData);
        }

        internal void Refresh()
        {
            MonthManager.Refresh();
            userData.Refresh();
        }
    }
}
