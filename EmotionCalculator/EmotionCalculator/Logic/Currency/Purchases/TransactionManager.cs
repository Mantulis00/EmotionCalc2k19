using EmotionCalculator.EmotionCalculator.Logic.User;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    static class TransactionManager
    {
        public static OperationStatus Transact(this UserData userData, CurrencyType currencyType, int amount)
        {
            switch (currencyType)
            {
                case CurrencyType.JoyCoin:
                    if (userData.JoyCoins + amount >= 0)
                    {
                        userData.AddCurrency(CurrencyType.JoyCoin, -amount);
                        return OperationStatus.Successful;
                    }
                    else
                    {
                        return OperationStatus.Unsuccessful;
                    }
                case CurrencyType.JoyGem:
                    if (userData.JoyGems + amount >= 0)
                    {
                        userData.AddCurrency(CurrencyType.JoyGem, -amount);
                        return OperationStatus.Successful;
                    }
                    else
                    {
                        return OperationStatus.Unsuccessful;
                    }
            }

            return OperationStatus.Unavailable;
        }

        public static OperationStatus Transact(this OwnedItems ownedItems, ConsumableType consumableType, int amount)
        {
            switch (consumableType)
            {
                case ConsumableType.LootBox:
                    {
                        if (ownedItems.LootBoxAmount + amount >= 0)
                        {
                            ownedItems.AddConsumables(ConsumableType.LootBox, -amount);
                            return OperationStatus.Successful;
                        }
                        else
                        {
                            return OperationStatus.Unsuccessful;
                        }
                    }
                case ConsumableType.PremiumLootBox:
                    {
                        if (ownedItems.PremiumLootBoxAmount + amount >= 0)
                        {
                            ownedItems.AddConsumables(ConsumableType.PremiumLootBox, -amount);
                            return OperationStatus.Successful;
                        }
                        else
                        {
                            return OperationStatus.Unsuccessful;
                        }
                    }
            }

            return OperationStatus.Unavailable;
        }

        public static Tuple<CurrencyType, int> GetCustomPurchasePrice(this CustomPurchase customPurchase)
        {
            switch (customPurchase)
            {
                case CustomPurchase.LightsOff:
                    return new Tuple<CurrencyType, int>(CurrencyType.JoyCoin, 1);
                case CustomPurchase.LightsOn:
                    return new Tuple<CurrencyType, int>(CurrencyType.JoyCoin, 1);
                case CustomPurchase.GameRun:
                    return new Tuple<CurrencyType, int>(CurrencyType.JoyCoin, 10);
                default:
                    return new Tuple<CurrencyType, int>(CurrencyType.JoyCoin, 0);
            }
        }
    }
}
