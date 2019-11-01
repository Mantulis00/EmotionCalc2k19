using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class PersonalStore
    {
        private UserData userData;

        internal PersonalStore(UserData userData)
        {
            this.userData = userData;
        }

        internal IEnumerable<InexhaustibleItem> GetInexhaustibleItems()
        {
            yield return new InexhaustibleItem("Simple lootbox", "Contains basic stuff", CurrencyType.JoyGem, 1, 0, true);
            yield return new InexhaustibleItem("Advanced lootbox", "Contains great loot", CurrencyType.JoyGem, 5, 0, true);
            yield return new InexhaustibleItem("Snake game key", "Can play snake once", CurrencyType.JoyCoin, 10, 0, true);
        }

        internal IEnumerable<UnlockableItem<ThemePack>> GetThemePacks()
        {
            var ownedPacks = userData.OwnedItems.Packs;

            foreach (Tuple<ThemePack, CurrencyType, int> storePack in GetPackPrices())
            {
                var pack = storePack.Item1;
                var type = storePack.Item2;
                var amount = storePack.Item3;

                if (!ownedPacks.Contains(pack))
                    yield return new UnlockableItem<ThemePack>(pack.Name, pack.Description,
                        type, amount, PurchaseStatus.Purchased, pack);
            }
        }

        private IEnumerable<Tuple<ThemePack, CurrencyType, int>> GetPackPrices()
        {
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.DefaultPack, CurrencyType.JoyCoin, 0);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.HalloweenPack, CurrencyType.JoyCoin, 150);
            yield return new Tuple<ThemePack, CurrencyType, int>(DesktopPack.BrexitPack, CurrencyType.JoyCoin, 150);
        }
    }
}
