using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    public static class DailyLoginData
    {
        public static Tuple<CurrencyType, int> GetDailyReward(int dayInARow)
        {
            switch (dayInARow)
            {
                case 1:
                    return Tuple.Create(CurrencyType.JoyCoin, 10);
                case 2:
                    return Tuple.Create(CurrencyType.JoyCoin, 25);
                case 3:
                    return Tuple.Create(CurrencyType.JoyCoin, 75);
                case 4:
                    return Tuple.Create(CurrencyType.JoyGem, 1);
                case 5:
                    return Tuple.Create(CurrencyType.JoyCoin, 150);
                case 6:
                    return Tuple.Create(CurrencyType.JoyCoin, 250);
                case 7:
                    return Tuple.Create(CurrencyType.JoyGem, 3);
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
