using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    //Visible for UI classes
    class CurrencyManager
    {
        private UserData userData;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal event EventHandler CurrencyChanged { add { userData.CurrencyChanged += value; } remove { userData.CurrencyChanged -= value; } }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
        }
    }
}
