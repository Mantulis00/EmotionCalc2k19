using EmotionCalculator.EmotionCalculator.Logic.Currency;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    class ConsumableManager
    {
        private static List<(Item, ItemPrice, ConsumableType)> _consumables =
            new List<(Item, ItemPrice, ConsumableType)>()
        {
            (new Item("Basic LootBox", "Contains basic stuff", ItemType.LootBox),
            null,
            ConsumableType.BasicLootBox),

            (new Item("Premium LootBox", "Contains premium loot", ItemType.LootBox),
            null,
            ConsumableType.PremiumLootBox),
        };

        private int basicBoxPrice;
        private int premiumBoxPrice;

        internal ConsumableManager(int basicBoxPrice, int premiumBoxPrice)
        {
            this.basicBoxPrice = basicBoxPrice;
            this.premiumBoxPrice = premiumBoxPrice;

            _consumables[0] = (
                _consumables[0].Item1,
                new ItemPrice(CurrencyType.JoyGem, basicBoxPrice, PriceType.Collectible),
                _consumables[0].Item3);

            _consumables[1] = (
                _consumables[1].Item1,
                new ItemPrice(CurrencyType.JoyGem, premiumBoxPrice, PriceType.Collectible),
                _consumables[1].Item3);
        }

        internal IEnumerable<(Item, ItemPrice)> GetInexhaustibleItems()
        {
            return _consumables.Select(c => (c.Item1, c.Item2));
        }

        internal Item GetItemByType(ConsumableType consumableType)
        {
            return _consumables.Where(c => c.Item3 == consumableType).Select(c => c.Item1).FirstOrDefault();
        }

        internal static Item GetItemByName(string name)
        {
            return _consumables.Where(trio => trio.Item1.Name == name).Select(trio => trio.Item1).FirstOrDefault();
        }
    }
}
