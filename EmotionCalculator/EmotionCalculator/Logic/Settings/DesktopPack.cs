using System;
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
                yield return YinYangPack;
                yield return UniversityPack;
            }
        }

        internal static IEnumerable<ThemePack> GetPackByName(string[] name)
        {
            return DesktopPacks.Where(pack => name.Contains(pack.Name));
        }

        internal static Func<bool> GetAvailabilityCondition(ThemePack themePack)
        {
            if (themePack.Name == BrexitPack.Name)
            {
                return () => false;
            }
            else
            {
                return () => true;
            }
        }

        internal static readonly ThemePack DefaultPack =
            new ThemePack("Default", "It's ok",
            Properties.Resources.backgroundMountains,
            Color.FromArgb(180, 255, 255, 255),
            Color.FromArgb(60, 255, 255, 255),
            Color.FromArgb(220, 255, 110, 110),
            Color.FromArgb(255, 0, 0, 0));

        internal static readonly ThemePack HalloweenPack =
            new ThemePack("Halloween", "Spooky",
            Properties.Resources.backgroundHalloween,
            Color.FromArgb(160, 255, 100, 100),
            Color.FromArgb(100, 200, 150, 150),
            Color.FromArgb(255, 255, 55, 55),
            Color.FromArgb(255, 0, 0, 0));

        internal static readonly ThemePack BrexitPack =
        new ThemePack("Brexit", "Breee",
            Properties.Resources.backgroundBrexit,
            Color.FromArgb(160, 255, 255, 50),
            Color.FromArgb(100, 200, 200, 50),
            Color.FromArgb(255, 255, 255, 200),
            Color.FromArgb(255, 0, 0, 0));

        internal static readonly ThemePack YinYangPack =
        new ThemePack("Yin Yang", "Harmony",
            Properties.Resources.yinYang,
            Color.FromArgb(220, 255, 255, 255),
            Color.FromArgb(0, 0, 0, 0),
            Color.FromArgb(220, 100, 0, 0),
            Color.FromArgb(255, 0, 0, 0));

        internal static readonly ThemePack UniversityPack =
        new ThemePack("VU", "Universitas Vilnensis",
            Properties.Resources.vu,
            Color.FromArgb(200, 255, 255, 255),
            Color.FromArgb(0, 0, 0, 0),
            Color.FromArgb(150, 122, 0, 63),
            Color.FromArgb(255, 122, 0, 63));
    }
}
