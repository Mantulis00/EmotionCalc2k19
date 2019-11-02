using EmotionCalculator.EmotionCalculator.Logic.User;
using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class PurchasableItem
    {
        internal string Name { get; }
        internal string Description { get; }
        internal CurrencyType CurrencyType { get; }
        internal int Price { get; }

        internal Func<bool> IsAvailable { get; private set; }
        private Action PurchaseHandler;

        public PurchasableItem(string name, string description, CurrencyType currencyType, int price,
            Action purchaseHandler, Func<bool> isAvailable)
        {
            Name = name;
            Description = description;
            CurrencyType = currencyType;
            Price = price;
            PurchaseHandler = purchaseHandler;
            IsAvailable = isAvailable;
        }

        internal OperationStatus TryPurchase(UserData userData)
        {
            if (IsAvailable())
            {
                if (CurrencyType == CurrencyType.JoyCoin && userData.JoyCoins >= Price)
                {
                    userData.AddCurrency(CurrencyType.JoyCoin, -Price);
                    CompletePurchase();
                    return OperationStatus.Successful;
                }
                else if (CurrencyType == CurrencyType.JoyGem && userData.JoyGems >= Price)
                {
                    userData.AddCurrency(CurrencyType.JoyGem, -Price);
                    CompletePurchase();
                    return OperationStatus.Successful;
                }

                return OperationStatus.Unsucessful;
            }
            else
            {
                return OperationStatus.Unavailable;
            }
        }

        protected void CompletePurchase()
        {
            PurchaseHandler.Invoke();
        }

        public override string ToString()
        {
            return $"{Name} - {Price} {(CurrencyType == CurrencyType.JoyCoin ? "Joy Coins" : "Joy Gems")}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var purchasableItem = (PurchasableItem)obj;

                return Name == purchasableItem.Name
                    && Description == purchasableItem.Description
                    && CurrencyType == purchasableItem.CurrencyType
                    && Price == purchasableItem.Price;
            }
        }
    }
}
