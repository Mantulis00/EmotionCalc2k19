using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidUserLoader : IUserLoader
    {
        public UserData Load()
        {
            return new UserData(0, 0, 0, DateTime.Today, Enumerable.Empty<KeyValuePair<Emotion, int>>(), new OwnedItems());
        }

        public void Save(UserData userData)
        {
            return;
        }
    }
}