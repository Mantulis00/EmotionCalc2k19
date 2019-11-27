using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
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
                    if (userData.JoyCoins - amount >= 0)
                    {
                        userData.AddCurrency(CurrencyType.JoyCoin, -amount);
                        return OperationStatus.Successful;
                    }
                    else
                    {
                        return OperationStatus.Unsuccessful;
                    }
                case CurrencyType.JoyGem:
                    if (userData.JoyGems - amount >= 0)
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

        public static OperationStatus Transact(this OwnedItems ownedItems, PersonalStore personalStore, ConsumableType consumableType, int amount)
        {
            var item = personalStore.GetItemByType(consumableType);

            if (ownedItems[item] - amount >= 0)
            {
                ownedItems.AddItems(item, -amount);
                return OperationStatus.Successful;
            }
            else
            {
                return OperationStatus.Unsuccessful;
            }
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
