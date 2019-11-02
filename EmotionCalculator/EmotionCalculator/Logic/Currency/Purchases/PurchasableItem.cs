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

        private Func<bool> IsAvailable;
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

        internal void TryPurchase(UserData userData)
        {
            if (IsAvailable())
            {
                if (CurrencyType == CurrencyType.JoyCoin && userData.JoyCoins >= Price)
                {
                    userData.AddCurrency(CurrencyType.JoyCoin, -Price);
                    CompletePurchase();
                }
                else if (CurrencyType == CurrencyType.JoyGem && userData.JoyGems >= Price)
                {
                    userData.AddCurrency(CurrencyType.JoyGem, -Price);
                    CompletePurchase();
                }
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
    }
}
