using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    public class ReadOnlyOwnedItems
    {
        private readonly OwnedItems ownedItems;

        public IEnumerable<(Item Item, int Count)> Items
        {
            get => ownedItems.Items;
        }

        public int this[Item item]
        {
            get => ownedItems[item];
        }

        public IEnumerable<ThemePack> ThemePacks
        {
            get => ownedItems.ThemePacks;
        }

        public IEnumerable<SongPack> SongPacks
        {
            get => ownedItems.SongPacks;
        }

        public event EventHandler ConsumablesChanged
        {
            add { ownedItems.ItemsChanged += value; }
            remove { ownedItems.ItemsChanged -= value; }
        }

        internal ReadOnlyOwnedItems(OwnedItems ownedItems)
        {
            this.ownedItems = ownedItems;
        }
    }
}
