using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class DesktopPack
    {
        internal static SettingsManager GetSettings()
        {
            SettingsManager manager = new SettingsManager(new SettingsLogger());

            if (manager.SelectedTheme == null)
                manager.SelectedTheme = DesktopPacks.ToList()[0];

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

        private static readonly ThemePack DefaultPack =
            new ThemePack("Default",
            Properties.Resources.backgroundMountains,
            Color.FromArgb(180, 255, 255, 255),
            Color.FromArgb(60, 255, 255, 255),
            Color.FromArgb(220, 255, 110, 110),
            Color.FromArgb(255, 0, 0, 0));

        private static readonly ThemePack HalloweenPack =
            new ThemePack("Halloween",
            Properties.Resources.backgroundHalloween,
            Color.FromArgb(160, 210, 220, 255),
            Color.FromArgb(60, 210, 220, 255),
            Color.FromArgb(255, 220, 230, 255),
            Color.FromArgb(255, 0, 0, 0));
    }
}
