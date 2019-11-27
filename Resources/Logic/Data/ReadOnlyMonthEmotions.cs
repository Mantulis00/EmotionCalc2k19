using EmotionCalculator.EmotionCalculator.Tools.API.Containers;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    public class ReadOnlyMonthEmotions
    {
        private readonly MonthEmotions monthEmotions;

        internal ReadOnlyMonthEmotions(MonthEmotions monthEmotions)
        {
            this.monthEmotions = monthEmotions;
        }
        public Emotion this[int dayOfTheMonth]
        {
            get
            {
                return monthEmotions[dayOfTheMonth];
            }
        }

        public int Year { get { return monthEmotions.Year; } }
        public Month Month { get { return monthEmotions.Month; } }
    }
}
