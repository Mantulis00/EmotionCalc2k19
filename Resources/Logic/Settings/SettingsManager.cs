﻿using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    public class SettingsManager
    {
        private readonly Dictionary<SettingType, SettingStatus> settings;

        private ThemePack _selectedTheme;
        public ThemePack SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (value != null)
                    _selectedTheme = value;
            }
        }

        private readonly ISettingsLogger settingsLogger;

        internal SettingsManager(ISettingsLogger settingsLogger)
        {
            this.settingsLogger = settingsLogger;

            SelectedTheme = settingsLogger.LoadTheme();
            settings = settingsLogger.LoadSettings();
        }

        public void ValidateSelections(UserData userData)
        {
            var item = ThemePackManager.GetItemByPack(SelectedTheme);

            if (!userData.OwnedItems.Owns(item))
            {
                SelectedTheme = userData.OwnedItems.ThemePacks.First();
            }

            Save();
        }

        public SettingStatus this[SettingType settingType]
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

        public void Save()
        {
            settingsLogger.SaveSettings(settings);

            if (SelectedTheme != null)
                settingsLogger.SaveTheme(SelectedTheme);
        }
    }
}
