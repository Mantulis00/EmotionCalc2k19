using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebService.EF
{
    public class OwnedItemsTableManager
    {

        public static EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems SelectItems(int userId)
        {
            using (var db = new EmotionDBContext())
            {
                Debug.WriteLine("Was here.");

                var items = from item in db.OwnedItems
                            where item.UserId == userId
                            join itemType in db.Items on item.ItemId equals itemType.Id
                            select
                            new
                            {
                                item.ItemCount,
                                itemType.ItemType,
                                itemType.ItemName
                            };

                Debug.WriteLine(db.Items.Count());

                var ownedItems = new EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems();

                foreach (var item in items)
                {
                    if (Enum.TryParse(typeof(ItemType), item.ItemType, out object type))
                    {
                        var itemType = (ItemType)type;

                        ownedItems.AddItems(
                            EmotionCalculator.EmotionCalculator.Logic.User.UserLoader
                            .GetItemByNameAndType(itemType, item.ItemName),
                            item.ItemCount);

                        Debug.WriteLine("Added something");
                    }
                }

                return ownedItems;
            }
        }

        internal static void Update(int userId, EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems ownedItems)
        {
            AddMissingTypes(ownedItems);
            AddMissingItems(userId, ownedItems);
            RemoveUnneeded(userId, ownedItems);
        }

        private static void AddMissingTypes(EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems ownedItems)
        {
            using (var db = new EmotionDBContext())
            {
                Debug.WriteLine("Was here.");

                //Add missing item types

                foreach (var ownedItem in ownedItems.Items)
                {
                    var itemTypes = from item in db.Items
                                    where item.ItemName == ownedItem.Item.Name
                                    && item.ItemType == ownedItem.Item.ItemType.ToString()
                                    select item;

                    if (itemTypes.Count() == 0)
                    {
                        db.Items.Add(new Items()
                        {
                            ItemName = ownedItem.Item.Name,
                            ItemType = ownedItem.Item.ItemType.ToString(),
                        });

                        Debug.WriteLine("Added new type.");
                    }
                    else
                    {
                        foreach (var item in itemTypes)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private static void AddMissingItems(int userId, EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems ownedItems)
        {
            using (var db = new EmotionDBContext())
            {
                Debug.WriteLine("About to add some missing items.");

                //Add missing
                foreach (var ownedItem in ownedItems.Items)
                {
                    var query = from itemType in db.Items
                                join OwnedItem in db.OwnedItems on itemType.Id equals OwnedItem.ItemId
                                into ownedPairs
                                from pair in ownedPairs.DefaultIfEmpty()
                                select new
                                {
                                    itemType.ItemType,
                                    itemType.ItemName,
                                    ItemId = itemType.Id,
                                    ItemCount = pair == null ? 0 : pair.ItemCount,
                                    UserId = pair == null ? 0 : pair.UserId
                                };

                    query = query.Where(item =>
                        item.ItemName == ownedItem.Item.Name
                        && item.ItemType == ownedItem.Item.ItemType.ToString());

                    if (query.Count() > 0)
                    {
                        var userOwned = query.AsEnumerable().Where(item => item.UserId == userId).ToList();
                        if (userOwned.Count() > 0)
                        {
                            var userOwnedItem = userOwned.First();

                            var theItem = db.OwnedItems.Where(item => item.ItemId == userOwnedItem.ItemId).First();

                            theItem.ItemCount = ownedItems[ownedItem.Item];

                            Debug.WriteLine("Changed an item.");
                        }
                        else
                        {
                            db.OwnedItems.Add(new OwnedItems()
                            {
                                ItemCount = ownedItems[ownedItem.Item],
                                ItemId = query.First().ItemId,
                                UserId = userId,
                            });

                            Debug.WriteLine("Added an item.");
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private static void RemoveUnneeded(int userId, EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.OwnedItems ownedItems)
        {
            using (var db = new EmotionDBContext())
            {
                var userOwnedItems = from itemType in db.Items
                                     join ownedItem in db.OwnedItems on itemType.Id equals ownedItem.ItemId
                                     into ownedPairs
                                     from pair in ownedPairs.DefaultIfEmpty()
                                     where pair.UserId == userId
                                     select new
                                     {
                                         itemType.ItemType,
                                         itemType.ItemName,
                                         ItemId = itemType.Id,
                                         pair.ItemCount,
                                     };

                //Remove unneeded
                foreach (var userOwnedItem in userOwnedItems)
                {
                    if (!ownedItems.Items.Any(item =>
                    userOwnedItem.ItemName == item.Item.Name
                    && userOwnedItem.ItemType == item.Item.ItemType.ToString()))
                    {
                        db.OwnedItems.Remove(new OwnedItems() { ItemId = userOwnedItem.ItemId });
                        Debug.WriteLine("Removed an item.");
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
