using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class ReadOnlyOwnedItems
    {
        private readonly OwnedItems ownedItems;

        internal ReadOnlyDictionary<Item, int> ItemCollection { get => ownedItems.ItemCollection; }

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
