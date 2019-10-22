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
                yield return DefaultPack;
                yield return HalloweenPack;
            }
        }

        internal static readonly ThemePack DefaultPack =
            new ThemePack("Default",
            Properties.Resources.backgroundMountains,
            Color.FromArgb(180, 255, 255, 255),
            Color.FromArgb(60, 255, 255, 255),
            Color.FromArgb(220, 255, 110, 110),
            Color.FromArgb(255, 0, 0, 0));

        internal static readonly ThemePack HalloweenPack =
            new ThemePack("Halloween",
            Properties.Resources.backgroundHalloween,
            Color.FromArgb(160, 255, 100, 100),
            Color.FromArgb(60, 255, 100, 100),
            Color.FromArgb(255, 220, 230, 255),
            Color.FromArgb(255, 0, 0, 0));
    }
}
