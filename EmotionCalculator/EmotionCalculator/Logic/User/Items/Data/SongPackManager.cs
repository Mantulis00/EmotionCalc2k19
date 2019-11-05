using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using System.Collections.Generic;
using System.Linq;
using static EmotionCalculator.Properties.Resources;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    static class SongPackManager
    {
        private static readonly List<(SongPack, ItemPrice)> minecraftSongs = new List<(SongPack, ItemPrice)>()
        {
            (new SongPack("Minecraft Song 01", "Beautiful", MCBG01, _01MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 20, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 02", "Very soothing", MCBG02, _02MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 40, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 03", "Nostalgic", MCBG03, _03MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 60, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 04", "Alluring", MCBG04, _04MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 80, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 05", "Charming", MCBG05, _05MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 100, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 06", "Delightful", MCBG06, _06MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 120, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 07", "Elegant", MCBG07, _07MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 140, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 08", "Very pleasing", MCBG08, _08MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 160, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 09", "Ideal", MCBG09, _09MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 180, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 10", "The pinnacle of music", MCBG10, _10MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 200, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 11", "Legendary", MCBG11, _11MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 220, PriceType.Unlockable)),

            (new SongPack("Minecraft Song 12", "Must buy!", MCBG12, _12MCSong),
            new ItemPrice(CurrencyType.JoyCoin, 240, PriceType.Unlockable)),
        };

        private static readonly List<(SongPack, ItemPrice)> classicalSongs = new List<(SongPack, ItemPrice)>()
        {
            //Mozart
            //Beethoven
            //Vivaldi
        };

        internal static IEnumerable<(SongPack, ItemPrice)> PricedSongPacks
        {
            get =>
                minecraftSongs.Concat(classicalSongs);
        }


        internal static IEnumerable<SongPack> SongPacks
        {
            get =>
                PricedSongPacks.Select(priced => priced.Item1);
        }

        internal static SongPack GetPackByItem(Item item)
        {
            return PricedSongPacks.Where(si => si.Item1.ToItem() == item).Select(ti => ti.Item1).FirstOrDefault();
        }

        internal static Item GetItemByPack(SongPack songPack)
        {
            return PricedSongPacks.Where(ti => ti.Item1 == songPack).Select(ti => ti.Item1.ToItem()).FirstOrDefault();
        }

        internal static SongPack GetPackByName(string name)
        {
            return SongPacks.FirstOrDefault(pack => pack.Name == name);
        }
    }
}
