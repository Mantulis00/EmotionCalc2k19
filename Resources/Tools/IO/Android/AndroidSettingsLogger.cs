using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidSettingsLogger : ISettingsLogger
    {
        public Dictionary<SettingType, SettingStatus> LoadSettings()
        {
            return new Dictionary<SettingType, SettingStatus>();
        }

        public ThemePack LoadTheme()
        {
            return ThemePackManager.ThemePacks.First();
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