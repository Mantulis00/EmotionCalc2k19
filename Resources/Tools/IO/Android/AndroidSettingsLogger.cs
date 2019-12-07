using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidSettingsLogger : ISettingsLogger
    {
        readonly string settingsUri = "https://localhost:5001/api/Settings";
        readonly string themeUri = "https://localhost:5001/api/Theme";

        public Dictionary<SettingType, SettingStatus> LoadSettings()
        {
            return EmotionClient.Instance.GetAsync<Dictionary<SettingType, SettingStatus>>(settingsUri).Result;
        }

        public ThemePack LoadTheme()
        {
            return EmotionClient.Instance.GetAsync<ThemePack>(themeUri).Result;
        }

        public void SaveSettings(Dictionary<SettingType, SettingStatus> settings)
        {
            return;
        }

        public void SaveTheme(ThemePack themePack)
        {
            return;
        }
    }
}