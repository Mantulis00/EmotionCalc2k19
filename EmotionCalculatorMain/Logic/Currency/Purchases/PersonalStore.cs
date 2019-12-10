using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    public class PersonalStore
    {
        private readonly UserData userData;

        internal PersonalStore(UserData userData)
        {
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
            return ConsumableManager.GetInexhaustibleItems();
        }

        public Item GetItemByType(ConsumableType consumableType)
        {
            return ConsumableManager.GetItemByType(consumableType);
        }

        public IEnumerable<PersonalPurchase> GetAllPurchases()
        {
            return GetThemePacks().Concat(GetConsumables()).Concat(GetSongPacks())
                .Select(tuple => new PersonalPurchase(userData, tuple.Item1, tuple.Item2));
        }

        public IEnumerable<PersonalPurchase> GetPersonalPurchases()
        {
            return GetAllPurchases().Where(pp => pp.Available);
        }
    }
}
