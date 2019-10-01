using EmotionCalculator.EmotionCalculator.Logic.Data;
using System;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    interface IMonthUpdatable
    {
        void Update(MonthEmotions newMonthEmotions, DateTime newTime);
    }
}
