using System;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    class UserData
    {
        private int joyCoins;
        public int JoyCoins
        {
            get
            {
                return joyCoins;
            }
            set
            {
                if (value <= 0)
                    joyCoins = 0;
                else
                    joyCoins = value;
            }
        }

        private int joyGems;
        public int JoyGems
        {
            get
            {
                return joyGems;
            }
            set
            {
                if (value <= 0)
                    joyGems = 0;
                else
                    joyGems = value;
            }
        }

        private int dailyLoginStreak;
        public int DailyLoginStreak
        {
            get
            {
                return dailyLoginStreak;
            }
            set
            {
                if (value <= 0)
                    dailyLoginStreak = 0;
                else
                    dailyLoginStreak = value;
            }
        }

        public DateTime LastLogOn { get; set; }

        public void Login()
        {
            if (LastLogOn != DateTime.Today.AddDays(-1))
            {
                dailyLoginStreak = 0;
            }

            LastLogOn = DateTime.Today;
        }

        public void ClaimDaily()
        {
            dailyLoginStreak++;
            dailyLoginStreak %= 7;
        }
    }
}