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
            Color.FromArgb(120, 50, 50, 140),
            Color.FromArgb(60, 50, 50, 140),
            Color.FromArgb(200, 10, 20, 180),
            Color.FromArgb(255, 255, 255, 255));
    }
}
