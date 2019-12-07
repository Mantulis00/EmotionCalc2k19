using EmotionCalculator.EmotionCalculator.Logic.Data;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidMonthLogger : IMonthLogger
    {
        readonly string uri = "https://localhost:5001/api/month";

        public MonthEmotions LoadMonth(int year, Month month)
        {
            return EmotionClient.Instance.GetAsync<MonthEmotions>(
                $"{uri}?year={year}&month={month}").Result;
        }

        public void SaveMonth(MonthEmotions monthEmotions)
        {
            return;
        }
    }
}