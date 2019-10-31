using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class AvailablePurchases
    {
        internal static IEnumerable<InexhaustibleItem> GetInexhaustibleItems()
        {
            yield return new InexhaustibleItem("Simple lootbox", "Contains basic stuff", CurrencyType.JoyGem, 1, 0, true);
            yield return new InexhaustibleItem("Advanced lootbox", "Contains great loot", CurrencyType.JoyGem, 5, 0, true);
            yield return new InexhaustibleItem("Snake game key", "Can play snake once", CurrencyType.JoyCoin, 10, 0, true);
        }

        internal static IEnumerable<UnlockableItem> GetUnlockableItems()
        {
            yield return new UnlockableItem("Halloween Theme", "Spooky", CurrencyType.JoyCoin, 150, PurchaseStatus.Available);
            yield return new UnlockableItem("Brexit Theme", "Breee", CurrencyType.JoyCoin, 150, PurchaseStatus.Available);
        }
    }
}
