using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    //Visible for UI classes
    //UserData wrapper
    class CurrencyManager
    {
        private UserData userData;
        private PersonalStore availablePurchases;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal OwnedItems OwnedItems { get { return userData.OwnedItems; } }

        internal event EventHandler CurrencyChanged
        { add { userData.CurrencyChanged += value; } remove { userData.CurrencyChanged -= value; } }

        internal IEnumerable<InexhaustibleItem> InexhaustibleItems { get { return availablePurchases.GetInexhaustibleItems(); } }
        internal IEnumerable<UnlockableItem<ThemePack>> UnlockableItems { get { return availablePurchases.GetThemePacks(); } }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            availablePurchases = new PersonalStore(userData);
        }
    }
}
