using EmotionCalculator.EmotionCalculator.Logic.Data.Songs;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class PersonalStore
    {
        private readonly UserData userData;

        internal PersonalStore(UserData userData)
        {
            this.userData = userData;
        }

        internal IEnumerable<PurchasableItem> GetInexhaustibleItems()
        {
            yield return new PurchasableItem("Simple lootbox", "Contains basic stuff", CurrencyType.JoyGem, 1,
                () => userData.OwnedItems.AddConsumables(ConsumableType.LootBox, 1), () => true);
            yield return new PurchasableItem("Premium lootbox", "Contains great loot", CurrencyType.JoyGem, 3,
                () => userData.OwnedItems.AddConsumables(ConsumableType.PremiumLootBox, 1), () => true);
        }

        internal IEnumerable<PurchasableItem> GetThemePacks()
        {
            var ownedPacks = userData.OwnedItems.ThemePacks;

            foreach (Tuple<ThemePack, CurrencyType, int> storePack in GetThemePackPrices())
            {
                var pack = storePack.Item1;
                var type = storePack.Item2;
                var amount = storePack.Item3;

                if (!ownedPacks.Contains(pack))
                    yield return new PurchasableItem(
                        pack.Name, pack.Description, type, amount,
                        () => ownedPacks.Add(pack),
                        () => !ownedPacks.Contains(pack)
                            && DesktopPack.GetAvailabilityCondition(pack).Invoke());
            }
        }

        private IEnumerable<Tuple<ThemePack, CurrencyType, int>> GetThemePackPrices()
        {
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.DefaultPack, CurrencyType.JoyCoin, 0);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.HalloweenPack, CurrencyType.JoyCoin, 150);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.BrexitPack, CurrencyType.JoyCoin, 150);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.YinYangPack, CurrencyType.JoyCoin, 250);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.UniversityPack, CurrencyType.JoyCoin, 250);
        }

        internal IEnumerable<PurchasableItem> GetSongPacks()
        {
            var ownedPacks = userData.OwnedItems.SongPacks;

            foreach (Tuple<SongPack, CurrencyType, int> storePack in GetSongPackPrices())
            {
                var pack = storePack.Item1;
                var type = storePack.Item2;
                var amount = storePack.Item3;

                if (!ownedPacks.Contains(pack))
                    yield return new PurchasableItem(
                        pack.Name, pack.Description, type, amount,
                        () => ownedPacks.Add(pack),
                        () => !ownedPacks.Contains(pack));
            }
        }

        private IEnumerable<Tuple<SongPack, CurrencyType, int>> GetSongPackPrices()
        {
            foreach (var pack in RadioPack.SongPacks)
            {
                yield return new Tuple<SongPack, CurrencyType, int>(pack, CurrencyType.JoyCoin, 150);
            }
        }
    }
}
