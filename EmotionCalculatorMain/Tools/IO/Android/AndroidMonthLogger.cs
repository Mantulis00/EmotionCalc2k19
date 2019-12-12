using EmotionCalculator.EmotionCalculator.Logic.Data;

namespace EmotionCalculator.Tools.IO.Android
{
    public class AndroidMonthLogger : IMonthLogger
    {
        readonly string uri = "http://10.0.2.2:5001/api/month";

        public MonthEmotions LoadMonth(int year, Month month)
        {
            return new MonthEmotions(year, month);
            //return EmotionClient.Instance.GetAsync<MonthEmotions>(
            //    $"{uri}?year={year}&month={month}").Result;
        }

        public void SaveMonth(MonthEmotions monthEmotions)
        {
            return;
        }
    }
}