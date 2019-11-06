using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class ReadOnlyOwnedItems
    {
        private readonly OwnedItems ownedItems;

        internal IEnumerable<(Item Item, int Count)> Items
        {
            get => ownedItems.Items;
        }

        internal int this[Item item]
        {
            get => ownedItems[item];
        }

        internal IEnumerable<ThemePack> ThemePacks
        {
            get => ownedItems.ThemePacks;
        }

        internal IEnumerable<SongPack> SongPacks
        {
            get => ownedItems.SongPacks;
        }

        internal event EventHandler ConsumablesChanged
        {
            add { ownedItems.ItemsChanged += value; }
            remove { ownedItems.ItemsChanged -= value; }
        }

        public ReadOnlyOwnedItems(OwnedItems ownedItems)
        {
            this.ownedItems = ownedItems;
        }
    }
}
