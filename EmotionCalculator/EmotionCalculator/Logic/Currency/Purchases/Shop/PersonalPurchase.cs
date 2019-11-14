﻿using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop
{
    class PersonalPurchase
    {
        private readonly UserData userData;
        internal Item Item { get; }
        internal ItemPrice ItemPrice { get; }
        public bool Available
        {
            get
                => ItemPrice.IsAvailable(userData, Item);
        }

        internal PersonalPurchase(UserData userData, Item item, ItemPrice itemPrice)
        {
            this.userData = userData;
            Item = item;
            ItemPrice = itemPrice;
        }

        internal OperationStatus Purchase()
        {
            if (Available)
            {
                var status = userData.Transact(ItemPrice.CurrencyType, ItemPrice.Price);

                if (status == OperationStatus.Successful)
                    CompletePurchase(userData);

                return status;
            }
            else
            {
                return OperationStatus.Unavailable;
            }
        }

        private void CompletePurchase(UserData userData)
        {
            userData.OwnedItems.AddItem(Item);
        }

        public override string ToString()
        {
            return Item.ToString() + " - " + ItemPrice.ToString();
        }
    }
}
