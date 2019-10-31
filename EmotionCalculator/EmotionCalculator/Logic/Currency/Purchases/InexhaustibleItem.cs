namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class InexhaustibleItem : PurchasableItem
    {
        internal int NumberPurchased { get; private set; }
        internal bool Available { get; }

        public InexhaustibleItem(string name, string description, CurrencyType currencyType, int price, int numberPurchased, bool available)
            : base(name, description, currencyType, price)
        {
            NumberPurchased = numberPurchased;
            Available = available;
        }

        internal override void Purchase()
        {
            if (Available)
            {
                NumberPurchased++;
            }
        }
    }
}
