using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    //UserData wrapper
    public class ReadOnlyUserData
    {
        private readonly UserData userData;

        public int JoyCoins { get { return userData.JoyCoins; } }
        public int JoyGems { get { return userData.JoyGems; } }
        public int DailyStreak { get { return userData.DailyStreak; } }
        public DateTime LastLogin { get { return userData.LastLogin; } }
        public ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        public ReadOnlyOwnedItems OwnedItems { get; private set; }

        public event EventHandler CurrencyChanged
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
