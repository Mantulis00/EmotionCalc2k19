using System;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    class UserManager
    {
        private IUserLoader userLoader;
        public UserData UserData { private set; get; }

        public UserManager(IUserLoader userLoader)
        {
            this.userLoader = userLoader;

            UserData = userLoader.Load();
        }

        //public void RecordEmotion(Emotion emotion)
        //{
        //    //check if emotion was already recorded on day
        //    //change currency otherwise??


        //    CurrencyChanged?.Invoke(this, );
        //}

        public event EventHandler CurrencyChanged;
    }
}
