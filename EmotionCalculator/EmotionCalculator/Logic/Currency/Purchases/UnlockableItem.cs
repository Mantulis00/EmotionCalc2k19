namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class UnlockableItem<T> : PurchasableItem
    {
        internal PurchaseStatus PurchaseStatus { get; private set; }

        private T _item;
        internal T Item
        {
            get
            {
                if (PurchaseStatus == PurchaseStatus.Purchased)
                    return _item;
                else
                    return default(T);
            }
        }

        public UnlockableItem(string name, string description, CurrencyType currencyType, int price, PurchaseStatus purchaseStatus, T item)
            : base(name, description, currencyType, price)
        {
            _item = item;
            PurchaseStatus = purchaseStatus;
        }

        internal override void Purchase()
        {
            if (PurchaseStatus == PurchaseStatus.Available)
                PurchaseStatus = PurchaseStatus.Purchased;
        }
    }
}
