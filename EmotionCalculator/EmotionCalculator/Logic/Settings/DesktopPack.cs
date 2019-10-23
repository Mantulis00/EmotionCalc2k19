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
                yield return BrexitPack;
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
            Color.FromArgb(160, 255, 100, 100),
            Color.FromArgb(100, 200, 150, 150),
            Color.FromArgb(255, 255, 55, 55),
            Color.FromArgb(255, 0, 0, 0));

        private static readonly ThemePack BrexitPack =
        new ThemePack("Brexit",
             Properties.Resources.backgroundBrexit,
            Color.FromArgb(160, 255, 255, 50),
            Color.FromArgb(100, 200, 200, 50),
            Color.FromArgb(255, 255, 55, 120),
            Color.FromArgb(255, 0, 0, 0));
            


    }
}
