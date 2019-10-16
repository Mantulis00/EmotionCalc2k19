using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class SettingsManager
    {
        private Dictionary<SettingType, SettingStatus> settings = new Dictionary<SettingType, SettingStatus>();

        internal ThemePack SelectedTheme { get; set; }

        internal SettingStatus GetSettingStatus(SettingType settingType)
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

        internal void SetSettingStatus(SettingType settingType, SettingStatus settingStatus)
        {
            if (settings.ContainsKey(settingType))
            {
                settings[settingType] = settingStatus;
            }
            else
            {
                settings.Add(settingType, settingStatus);
            }
        }
    }
}
