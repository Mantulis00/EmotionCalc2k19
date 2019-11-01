using EmotionCalculator.EmotionCalculator.Logic.Settings;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class OwnedItems
    {
        internal List<ThemePack> Packs { get; }

        internal OwnedItems()
        {
            Packs = new List<ThemePack>();
        }
    }
}
