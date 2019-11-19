using EmotionCalculator.EmotionCalculator.FormsUI.Threadings;
using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Events;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic
{
    public class MainManager
    {
        private readonly IUserLoader userLoader;
        private readonly UserData userData;

        public CurrencyManager CurrencyManager { get; }
        public ReadOnlyUserData ReadOnlyUserData { get; }
        public SettingsManager SettingsManager { get; }
        public MonthManager MonthManager { get; }
        public EventManager EventManager { get; }
        public Lazy<GameManager> GameManager { get; }

        public MainManager(IMonthLogger monthLogger, IUserLoader userLoader,
            ISettingsLogger settingsLogger, Lazy<GameManager> GameManager)
        {
            //Private fields
            this.userLoader = userLoader;
            userData = userLoader.Load();
            ReadOnlyUserData = userData.AsReadOnly();

            //Currency
            CurrencyManager = new CurrencyManager(userData);

            //Settings
            SettingsManager = new SettingsManager(settingsLogger);
            if (SettingsManager.SelectedTheme == null)
                SettingsManager.SelectedTheme = ThemePackManager.ThemePacks.ToList()[0];
            SettingsManager.ValidateSelections(userData);

            //Month management
            MonthManager = new MonthManager(userData, monthLogger);

            //Event management
            EventManager = new EventManager(userData);

            // Game managment (w/ lazy init)
            this.GameManager = GameManager;
        }

        public void Save()
        {
            MonthManager.Save();

            if (userData != null)
                userLoader.Save(userData);
        }

        public void Refresh()
        {
            MonthManager.Refresh();
            userData.Refresh();
        }
    }
}
