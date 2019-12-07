using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    public static class ThemePackManager
    {

        private static readonly List<(ThemePack ThemePack, ItemPrice ItemPrice)> _themePacks = new List<(ThemePack, ItemPrice)>()
        {
            (new ThemePack("Default", "It's ok",
                Properties.Resources.backgroundMountains,
                Color.FromArgb(180, 255, 255, 255),
                Color.FromArgb(60, 255, 255, 255),
                Color.FromArgb(220, 255, 110, 110),
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 0, 0, 0)),
            ItemPrice.Unavailable),

            (new ThemePack("Halloween", "Spooky",
                Properties.Resources.backgroundHalloween,
                Color.FromArgb(160, 255, 100, 100),
                Color.FromArgb(100, 200, 150, 150),
                Color.FromArgb(255, 255, 55, 55),
                Color.FromArgb(255, 255, 255, 255),
                Color.FromArgb(255, 0, 0, 0)),
            new ItemPrice(CurrencyType.JoyCoin, 150, PriceType.Unlockable)),

            (new ThemePack("Brexit", "Breee",
                Properties.Resources.britreeee,
                Color.FromArgb(220, 255, 255, 255),
                Color.FromArgb(60, 255, 255, 255),
                Color.FromArgb(255, 100, 40, 255),
                Color.FromArgb(255, 255, 255, 255),
                Color.FromArgb(255, 0, 0, 0)),
            new ItemPrice(CurrencyType.JoyCoin, 150, PriceType.Unlockable)),

            (new ThemePack("Yin Yang", "Harmony",
                Properties.Resources.yinYang,
                Color.FromArgb(220, 255, 255, 255),
                Color.FromArgb(0, 0, 0, 0),
                Color.FromArgb(220, 100, 50, 50),
                Color.FromArgb(255, 190, 190, 190),
                Color.FromArgb(255, 0, 0, 0)),
            new ItemPrice(CurrencyType.JoyCoin, 250, PriceType.Unlockable)),

            (new ThemePack("VU", "Universitas Vilnensis",
                Properties.Resources.vu,
                Color.FromArgb(200, 255, 255, 255),
                Color.FromArgb(0, 0, 0, 0),
                Color.FromArgb(255, 122, 0, 63),
                Color.FromArgb(255, 255, 255, 255),
                Color.FromArgb(255, 122, 0, 63)),
            new ItemPrice(CurrencyType.JoyCoin, 250, PriceType.Unlockable)),

            (new ThemePack("Minecraft", "Insane fan art!",
                Properties.Resources.backgroundMc,
                Color.FromArgb(180, 255, 255, 255),
                Color.FromArgb(60, 255, 255, 255),
                Color.FromArgb(220, 50, 255, 50),
                Color.FromArgb(255, 255, 255, 255),
                Color.FromArgb(255, 0, 0, 0)),
            new ItemPrice(CurrencyType.JoyCoin, 500, PriceType.Unlockable,
                lootDropType: LootDropType.Never)),
        };

        public static IEnumerable<ThemePack> ThemePacks
        {
            get
            {
                return _themePacks.Select(pack => pack.ThemePack);
            }
        }

        internal static IEnumerable<(ThemePack, ItemPrice)> PricedThemePacks
        {
            get
            {
                return _themePacks;
            }
        }

        internal static ThemePack GetPackByItem(Item item)
        {
            return _themePacks.Where(ti => ti.ThemePack.ToItem() == item).Select(ti => ti.ThemePack).FirstOrDefault();
        }

        internal static Item GetItemByPack(ThemePack themePack)
        {
            return _themePacks.Where(ti => ti.ThemePack == themePack).Select(ti => ti.ThemePack.ToItem()).FirstOrDefault();
        }

        internal static ThemePack GetPackByName(string name)
        {
            return ThemePacks.FirstOrDefault(pack => pack.Name == name);
        }
    }
}
