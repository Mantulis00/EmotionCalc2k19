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

        internal IEnumerable<PurchasableItem> GetInexhaustibleItems()
        {
            yield return new PurchasableItem("Simple lootbox", "Contains basic stuff", CurrencyType.JoyGem, 1, () => { }, repurchasable: true);
            yield return new PurchasableItem("Advanced lootbox", "Contains great loot", CurrencyType.JoyGem, 5, () => { }, repurchasable: true);
        }

        internal IEnumerable<PurchasableItem> GetThemePacks()
        {
            var ownedPacks = userData.OwnedItems.Packs;

            foreach (Tuple<ThemePack, CurrencyType, int> storePack in GetPackPrices())
            {
                var pack = storePack.Item1;
                var type = storePack.Item2;
                var amount = storePack.Item3;

                if (!ownedPacks.Contains(pack))
                    yield return new PurchasableItem(pack.Name, pack.Description,
                        type, amount, () => { userData.OwnedItems.Packs.Add(pack); });
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
