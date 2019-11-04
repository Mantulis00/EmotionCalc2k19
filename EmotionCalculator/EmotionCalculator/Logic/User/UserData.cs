using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    //Visible for inner logic
    class UserData
    {
        internal int JoyCoins { get; private set; }
        internal int JoyGems { get; private set; }
        internal int DailyStreak { get; private set; }

        private DateTime _lastLogin;

        internal DateTime LastLogin
        {
            get
            {
                return new DateTime(_lastLogin.Year, _lastLogin.Month, _lastLogin.Day);
            }
            private set
            {
                _lastLogin = value;
            }
        }

        private readonly Dictionary<Emotion, int> emotionCount;
        internal ReadOnlyDictionary<Emotion, int> EmotionCount
        {
            get
            {
                return new ReadOnlyDictionary<Emotion, int>(emotionCount);
            }
        }

        internal OwnedItems OwnedItems { get; }

        public event EventHandler CurrencyChanged;

        internal UserData(int joyCoins, int joyGems, int dailyStreak, DateTime lastLogin,
            IEnumerable<KeyValuePair<Emotion, int>> emotionPairs, OwnedItems ownedItems)
        {
            JoyCoins = joyCoins;
            JoyGems = joyGems;
            DailyStreak = dailyStreak;
            LastLogin = new DateTime(lastLogin.Year, lastLogin.Month, lastLogin.Day);

            emotionCount = new Dictionary<Emotion, int>();

            emotionPairs.ToList().ForEach(pair => emotionCount.Add(pair.Key, pair.Value));

            OwnedItems = ownedItems;

            CurrencyChanged?.Invoke(this, EventArgs.Empty);

            GetFreeItems();
        }

        private void GetFreeItems()
        {
            if (!OwnedItems.ThemePacks.Contains(DesktopPack.DefaultPack))
            {
                OwnedItems.ThemePacks.Add(DesktopPack.DefaultPack);
            }
        }

        public void Login()
        {
            if (LastLogin < DateTime.Today.AddDays(-1))
            {
                DailyStreak = 0;
            }

            LastLogin = DateTime.Today;
        }

        public void ClaimDaily()
        {
            var dailyReward = DailyLoginData.GetDailyReward(DailyStreak + 1);
            AddCurrency(dailyReward.Item1, dailyReward.Item2);

            DailyStreak++;
            DailyStreak %= 7;
        }

        public void AddCurrency(CurrencyType currencyType, int amount)
        {
            switch (currencyType)
            {
                case CurrencyType.JoyCoin:
                    JoyCoins += amount;
                    JoyCoins = Math.Max(JoyCoins, 0);
                    break;
                case CurrencyType.JoyGem:
                    JoyGems += amount;
                    JoyGems = Math.Max(JoyGems, 0);
                    break;
            }

            CurrencyChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AddCurrency(Emotion emotionType, int amount)
        {
            if (emotionCount.ContainsKey(emotionType))
            {
                emotionCount[emotionType] += amount;
            }
            else
            {
                emotionCount.Add(emotionType, amount);
            }

            emotionCount[emotionType] = Math.Max(0, emotionCount[emotionType]);

            CurrencyChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Refresh()
        {
            CurrencyChanged?.Invoke(this, EventArgs.Empty);
            OwnedItems.Refresh();
        }

        internal ReadOnlyUserData AsReadOnly()
        {
            return new ReadOnlyUserData(this);
        }
    }
}