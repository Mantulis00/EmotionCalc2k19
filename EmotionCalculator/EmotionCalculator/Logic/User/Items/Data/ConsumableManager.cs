using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    static class ConsumableManager
    {
        private static List<(Item, ItemPrice, ConsumableType)> _consumables =
            new List<(Item, ItemPrice, ConsumableType)>()
        {
            (new Item("Basic LootBox", "Contains basic stuff", ItemType.LootBox),
            new ItemPrice(CurrencyType.JoyGem, 1, PriceType.Collectible),
            ConsumableType.BasicLootBox),

            (new Item("Premium LootBox", "Contains premium loot", ItemType.LootBox),
            new ItemPrice(CurrencyType.JoyGem, 3, PriceType.Collectible),
            ConsumableType.PremiumLootBox),
        };

        internal static IEnumerable<(Item, ItemPrice)> GetInexhaustibleItems()
        {
            return _consumables.Select(c => (c.Item1, c.Item2));
        }

        internal static Item GetItemByType(ConsumableType consumableType)
        {
            return _consumables.Where(c => c.Item3 == consumableType).Select(c => c.Item1).FirstOrDefault();
        }

        internal static Item GetItemByName(string name)
        {
            return _consumables.Where(trio => trio.Item1.Name == name).Select(trio => trio.Item1).FirstOrDefault();
        }
    }
}
