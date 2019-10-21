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
            }
        }
    }
}