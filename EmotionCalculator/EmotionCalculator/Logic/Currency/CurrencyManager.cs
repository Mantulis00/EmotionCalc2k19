using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
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
        internal IReadOnlyList<ThemePack> OwnedPacks { get { return userData.OwnedItems.Packs.AsReadOnly(); } }

        internal event EventHandler CurrencyChanged
        {
            add { userData.CurrencyChanged += value; }
            remove { userData.CurrencyChanged -= value; }
        }

        internal IEnumerable<PurchasableItem> InexhaustibleItems { get { return personalStore.GetInexhaustibleItems(); } }
        internal IEnumerable<PurchasableItem> UnlockableThemes { get { return personalStore.GetThemePacks(); } }

        internal IEnumerable<PurchasableItem> PurchasableItems
        {
            get
            {
                return InexhaustibleItems.Concat(UnlockableThemes);
            }
        }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            personalStore = new PersonalStore(userData);
        }

        internal void Purchase(PurchasableItem item)
        {
            item.TryPurchase(userData);
        }
    }
}
