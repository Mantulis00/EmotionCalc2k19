using EmotionCalculator.EmotionCalculator.Logic.Data.Songs;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class ReadOnlyOwnedItems
    {
        private readonly OwnedItems ownedItems;
        internal int LootBoxAmount { get { return ownedItems.LootBoxAmount; } }
        internal int PremiumLootBoxAmount { get { return ownedItems.PremiumLootBoxAmount; } }
        internal IReadOnlyList<ThemePack> ThemePacks { get { return ownedItems.ThemePacks.AsReadOnly(); } }
        internal IReadOnlyList<SongPack> SongPacks { get { return ownedItems.SongPacks.AsReadOnly(); } }

        internal event EventHandler ConsumablesChanged
        {
            add { ownedItems.ConsumablesChanged += value; }
            remove { ownedItems.ConsumablesChanged -= value; }
        }

        public ReadOnlyOwnedItems(OwnedItems ownedItems)
        {
            this.ownedItems = ownedItems;
        }
    }
}
