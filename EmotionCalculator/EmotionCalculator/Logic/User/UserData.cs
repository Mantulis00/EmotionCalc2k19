using EmotionCalculator.EmotionCalculator.Logic.Currency;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
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

        internal UserData(int joyCoins, int joyGems, int dailyStreak, DateTime lastLogin)
        {
            JoyCoins = joyCoins;
            JoyGems = joyGems;
            DailyStreak = dailyStreak;
            LastLogin = new DateTime(lastLogin.Year, lastLogin.Month, lastLogin.Day);
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
        }
    }
}