namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    public interface IMonthLogger
    {
        void SaveMonth(MonthEmotions monthEmotions);
        MonthEmotions LoadMonth(int year, Month month);
    }
}
