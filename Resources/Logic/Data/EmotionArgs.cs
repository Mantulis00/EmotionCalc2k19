using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    public class EmotionArgs : EventArgs
    {
        public ReadOnlyMonthEmotions MonthEmotions { get; }
        public DateTime SelectedTime { get; }

        internal EmotionArgs(ReadOnlyMonthEmotions monthEmotions, DateTime selectedTime)
        {
            MonthEmotions = monthEmotions;
            SelectedTime = selectedTime;
        }
    }
}
