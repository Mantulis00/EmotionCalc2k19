namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class UnlockableItem : PurchasableItem
    {
        internal PurchaseStatus PurchaseStatus { get; private set; }

        public UnlockableItem(string name, string description, CurrencyType currencyType, int price, PurchaseStatus purchaseStatus)
            : base(name, description, currencyType, price)
        {
            PurchaseStatus = purchaseStatus;
        }

        internal override void Purchase()
        {
            if (PurchaseStatus == PurchaseStatus.Available)
                PurchaseStatus = PurchaseStatus.Purchased;
        }
    }
}
