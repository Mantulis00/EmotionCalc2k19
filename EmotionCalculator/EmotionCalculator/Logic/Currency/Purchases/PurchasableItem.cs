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

        internal bool Available { get; private set; }

        private Action PurchaseHandler;
        private bool repurchasable;

        public PurchasableItem(string name, string description, CurrencyType currencyType, int price,
            Action purchaseHandler, bool available = true, bool repurchasable = false)
        {
            Name = name;
            Description = description;
            CurrencyType = currencyType;
            Price = price;
            PurchaseHandler = purchaseHandler;
            Available = available;
            this.repurchasable = repurchasable;
        }

        internal void TryPurchase(UserData userData)
        {
            if (Available)
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

            if (!repurchasable)
            {
                Available = false;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Price} {(CurrencyType == CurrencyType.JoyCoin ? "Joy Coins" : "Joy Gems")}";
        }
    }
}
