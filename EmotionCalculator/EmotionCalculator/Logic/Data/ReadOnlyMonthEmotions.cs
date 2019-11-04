using EmotionCalculator.EmotionCalculator.Tools.API.Containers;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    class ReadOnlyMonthEmotions
    {
        private MonthEmotions monthEmotions;

        internal ReadOnlyMonthEmotions(MonthEmotions monthEmotions)
        {
            this.monthEmotions = monthEmotions;
        }
        internal Emotion this[int dayOfTheMonth]
        {
            get
            {
                return monthEmotions[dayOfTheMonth];
            }
        }

        internal int Year { get { return monthEmotions.Year; } }
        internal Month Month { get { return monthEmotions.Month; } }
    }
}
