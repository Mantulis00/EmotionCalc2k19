using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class PersonalStore
    {
        private readonly ConsumableManager consumableManager;
        private readonly UserData userData;

        internal PersonalStore(UserData userData)
        {
            //load ints
            this.consumableManager = new ConsumableManager(1, 3);
            this.userData = userData;
        }

        private IEnumerable<(Item, ItemPrice)> GetThemePacks()
        {
            return ThemePackManager.PricedThemePacks.Select(pack => (pack.Item1.ToItem(), pack.Item2));
        }

        private IEnumerable<(Item, ItemPrice)> GetSongPacks()
        {
            return SongPackManager.PricedSongPacks.Select(pack => (pack.Item1.ToItem(), pack.Item2));
        }

        private IEnumerable<(Item, ItemPrice)> GetConsumables()
        {
            return consumableManager.GetInexhaustibleItems();
        }

        internal Item GetItemByType(ConsumableType consumableType)
        {
            return consumableManager.GetItemByType(consumableType);
        }

        internal IEnumerable<PersonalPurchase> GetAllPurchases()
        {
            return GetThemePacks().Concat(GetConsumables()).Concat(GetSongPacks())
                .Select(tuple => new PersonalPurchase(userData, tuple.Item1, tuple.Item2));
        }

        internal IEnumerable<PersonalPurchase> GetPersonalPurchases()
        {
            return GetAllPurchases().Where(pp => pp.Available);
        }
    }
}
