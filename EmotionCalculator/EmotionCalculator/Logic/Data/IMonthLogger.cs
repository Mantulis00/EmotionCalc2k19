namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    interface IMonthLogger
    {
        void SaveMonth(MonthEmotions monthEmotions);
        MonthEmotions LoadMonth(int year, Month month);
    }
}
