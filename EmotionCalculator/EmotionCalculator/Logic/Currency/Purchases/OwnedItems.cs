using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class OwnedItems
    {
        private readonly Dictionary<Item, int> itemCollection;
        internal ReadOnlyDictionary<Item, int> ItemCollection { get => new ReadOnlyDictionary<Item, int>(itemCollection); }

        internal event EventHandler ItemsChanged;

        internal IEnumerable<ThemePack> ThemePacks
        {
            get =>
                ThemePackManager.ThemePacks.Where(tuple => Owns(tuple.ToItem()));
        }

        internal IEnumerable<SongPack> SongPacks
        {
            get =>
                SongPackManager.SongPacks.Where(tuple => Owns(tuple.ToItem()));
        }

        internal OwnedItems()
        {
            itemCollection = new Dictionary<Item, int>();
        }

        internal void AddItem(Item item)
        {
            AddItems(item, 1);
        }

        internal void AddItems(Item item, int amount)
        {
            if (item == null)
                return;

            if (itemCollection.ContainsKey(item))
            {
                itemCollection[item] += amount;
            }
            else
            {
                itemCollection.Add(item, amount);
            }

            itemCollection[item] = Math.Max(itemCollection[item], 0);

            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        internal bool Owns(Item item)
        {
            return itemCollection.ContainsKey(item) && itemCollection[item] > 0;
        }

        internal int OwnsNumberOfType(ItemType itemType)
        {
            return ItemCollection.Count(pair => pair.Key.ItemType == itemType && pair.Value > 0);
        }

        internal void Refresh()
        {
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        internal ReadOnlyOwnedItems AsReadOnly()
        {
            return new ReadOnlyOwnedItems(this);
        }
    }
}
