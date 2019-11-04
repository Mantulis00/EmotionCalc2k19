using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot;
using EmotionCalculator.EmotionCalculator.Logic.User;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    class CurrencyManager
    {
        private readonly UserData userData;
        private readonly PersonalStore personalStore;

        internal IEnumerable<PurchasableItem> InexhaustibleItems { get { return personalStore.GetInexhaustibleItems(); } }
        internal IEnumerable<PurchasableItem> UnlockableThemes { get { return personalStore.GetThemePacks(); } }
        internal IEnumerable<PurchasableItem> UnlockableSongs { get { return personalStore.GetSongPacks(); } }
        internal IEnumerable<PurchasableItem> PurchasableItems
        {
            get
            {
                return InexhaustibleItems.Concat(UnlockableThemes).Concat(UnlockableSongs);
            }
        }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            personalStore = new PersonalStore(userData);
        }

        internal OperationStatus Purchase(PurchasableItem item)
        {
            return item.TryPurchase(userData);
        }

        internal OperationStatus Purchase(CustomPurchase customPurchase)
        {
            var price = customPurchase.GetCustomPurchasePrice();

            return userData.Transact(price.Item1, price.Item2);
        }

        internal OperationStatus Consume(ConsumableType consumableType, out string rewardString)
        {
            OperationStatus status = userData.OwnedItems.Transact(consumableType, 1);

            if (status == OperationStatus.Successful)
            {
                LootManager.OpenLootBox(consumableType, userData, out rewardString);
            }
            else
            {
                rewardString = string.Empty;
            }

            return status;
        }
    }
}
