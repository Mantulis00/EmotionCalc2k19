using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    class EmotionArgs : EventArgs
    {
        internal ReadOnlyMonthEmotions MonthEmotions { get; }
        internal DateTime SelectedTime { get; }

        internal EmotionArgs(ReadOnlyMonthEmotions monthEmotions, DateTime selectedTime)
        {
            MonthEmotions = monthEmotions;
            SelectedTime = selectedTime;
        }
    }
}
