using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class DesktopPack
    {
        internal static SettingsManager GetSettings()
        {
            SettingsManager manager = new SettingsManager();

            manager.SelectedTheme = DesktopPacks.ToList()[0];

            manager[SettingType.Emoji] = SettingStatus.Disabled;

            return manager;
        }

        internal static IEnumerable<ThemePack> DesktopPacks
        {
            get
            {
                yield return new ThemePack("Default", Properties.Resources.backgroundMountains,
                    Color.FromArgb(180, 255, 255, 255),
                    Color.FromArgb(60, 255, 255, 255),
                    Color.FromArgb(220, 255, 110, 110));

                yield return new ThemePack("Halloween", Properties.Resources.backgroundHalloween,
                    Color.FromArgb(180, 255, 200, 200),
                    Color.FromArgb(60, 255, 230, 230),
                    Color.FromArgb(220, 255, 255, 255));
            }
        }
    }
}
