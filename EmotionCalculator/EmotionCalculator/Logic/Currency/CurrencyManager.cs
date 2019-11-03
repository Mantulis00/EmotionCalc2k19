using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot;
using EmotionCalculator.EmotionCalculator.Logic.Data.Songs;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    //Visible for UI classes
    //UserData wrapper
    class CurrencyManager
    {
        private UserData userData;
        private PersonalStore personalStore;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal IReadOnlyList<ThemePack> OwnedThemePacks { get { return userData.OwnedItems.ThemePacks.AsReadOnly(); } }
        internal IReadOnlyList<SongPack> OwnedSongPacks { get { return userData.OwnedItems.SongPacks.AsReadOnly(); } }
        internal int LootboxAmount { get { return userData.OwnedItems.LootBoxAmount; } }
        internal int PremiumLootboxAmount { get { return userData.OwnedItems.PremiumLootBoxAmount; } }

        internal event EventHandler CurrencyChanged
        {
            add { userData.CurrencyChanged += value; }
            remove { userData.CurrencyChanged -= value; }
        }

        internal event EventHandler ConsumablesChanged
        {
            add { userData.OwnedItems.ConsumablesChanged += value; }
            remove { userData.OwnedItems.ConsumablesChanged -= value; }
        }

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
