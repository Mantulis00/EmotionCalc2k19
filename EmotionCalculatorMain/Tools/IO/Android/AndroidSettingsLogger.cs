using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidSettingsLogger : ISettingsLogger
    {
        readonly string settingsUri = "http://10.0.2.2:5001/api/Settings";
        readonly string themeUri = "http://10.0.2.2:5001/api/Theme";

        public Dictionary<SettingType, SettingStatus> LoadSettings()
        {
            return new Dictionary<SettingType, SettingStatus>();
            //return EmotionClient.Instance.GetAsync<Dictionary<SettingType, SettingStatus>>(settingsUri).Result;
        }

        public ThemePack LoadTheme()
        {
            return ThemePackManager.ThemePacks.First();
            //return EmotionClient.Instance.GetAsync<ThemePack>(themeUri).Result;
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