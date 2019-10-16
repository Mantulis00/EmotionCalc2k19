using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class SettingsManager
    {
        private Dictionary<SettingType, SettingStatus> settings = new Dictionary<SettingType, SettingStatus>();

        internal ThemePack SelectedTheme { get; set; }

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
    }
}
