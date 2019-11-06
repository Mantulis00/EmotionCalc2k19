using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    //UserData wrapper
    class ReadOnlyUserData
    {
        private readonly UserData userData;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal ReadOnlyOwnedItems OwnedItems { get; private set; }

        internal event EventHandler CurrencyChanged
        {
            add { userData.CurrencyChanged += value; }
            remove { userData.CurrencyChanged -= value; }
        }

        internal ReadOnlyUserData(UserData userData)
        {
            this.userData = userData;
            OwnedItems = userData.OwnedItems.AsReadOnly();
        }
    }
}
