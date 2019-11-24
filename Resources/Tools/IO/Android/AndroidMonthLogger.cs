using EmotionCalculator.EmotionCalculator.Logic.Data;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidMonthLogger : IMonthLogger
    {
        public MonthEmotions LoadMonth(int year, Month month)
        {
            return new MonthEmotions(year, month);
        }

        public void SaveMonth(MonthEmotions monthEmotions)
        {
            return;
        }
    }
}