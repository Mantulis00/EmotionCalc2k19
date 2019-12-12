using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    public class OwnedItems
    {
        private readonly Dictionary<Item, int> itemCollection;

        public int this[Item item]
        {
            get
            {
                if (itemCollection.ContainsKey(item))
                {
                    return itemCollection[item];
                }
                else
                {
                    return 0;
                }
            }
        }

        public IEnumerable<(Item Item, int Count)> Items
        {
            get
            {
                return itemCollection.Select(item => (item.Key, item.Value));
            }
        }

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

        public OwnedItems()
        {
            itemCollection = new Dictionary<Item, int>();
        }

        public void AddItem(Item item)
        {
            AddItems(item, 1);
        }

        public void AddItems(Item item, int amount)
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
                Debug.WriteLine("purchased ok");
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
            return Items.Count(item => item.Item.ItemType == itemType && item.Count > 0);
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
