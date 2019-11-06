using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    interface ISettingsLogger
    {
        ThemePack LoadTheme();
        void SaveTheme(ThemePack themePack);
        Dictionary<SettingType, SettingStatus> LoadSettings();
        void SaveSettings(Dictionary<SettingType, SettingStatus> settings);
    }
}
