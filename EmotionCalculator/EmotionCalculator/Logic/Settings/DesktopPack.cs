using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class DesktopPack
    {
        internal static SettingsManager GetSettings()
        {
            SettingsManager manager = new SettingsManager();

            manager.SelectedTheme = DesktopPacks.ToList()[0];

            manager.SetSettingStatus(SettingType.Emoji, SettingStatus.Disabled);

            return manager;
        }

        internal static IEnumerable<ThemePack> DesktopPacks
        {
            get
            {
                yield return new ThemePack("Default", Properties.Resources.backgroundMountains);
                yield return new ThemePack("Halloween", Properties.Resources.backgroundHalloween);
            }
        }
    }
}
