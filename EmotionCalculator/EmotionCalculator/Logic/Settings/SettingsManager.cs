using EmotionCalculator.EmotionCalculator.Logic.User;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class SettingsManager
    {
        private Dictionary<SettingType, SettingStatus> settings;

        private ThemePack _selectedTheme;
        internal ThemePack SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (value != null)
                    _selectedTheme = value;
            }
        }

        private ISettingsLogger settingsLogger;

        internal SettingsManager(ISettingsLogger settingsLogger)
        {
            this.settingsLogger = settingsLogger;

            SelectedTheme = settingsLogger.LoadTheme();
            settings = settingsLogger.LoadSettings();
        }

        public void ValidateSelections(UserData userData)
        {
            if (!userData.OwnedItems.Packs.Contains(SelectedTheme))
            {
                SelectedTheme = userData.OwnedItems.Packs.First();
            }

            Save();
        }

        internal SettingStatus this[SettingType settingType]
        {
            get
            {
                if (settings.ContainsKey(settingType))
                {
                    return settings[settingType];
                }
                else
                {
                    return SettingStatus.NotSet;
                }
            }
            set
            {
                if (settings.ContainsKey(settingType))
                {
                    settings[settingType] = value;
                }
                else
                {
                    settings.Add(settingType, value);
                }
            }
        }

        internal void Save()
        {
            settingsLogger.SaveSettings(settings);

            if (SelectedTheme != null)
                settingsLogger.SaveTheme(SelectedTheme);
        }
    }
}
