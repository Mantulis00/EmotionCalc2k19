namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    abstract class PurchasableItem
    {
        internal string Name { get; }
        internal string Description { get; }
        internal CurrencyType CurrencyType { get; }
        internal int Price { get; }

        public PurchasableItem(string name, string description, CurrencyType currencyType, int price)
        {
            Name = name;
            Description = description;
            CurrencyType = CurrencyType;
            Price = price;
        }

        internal abstract void Purchase();
    }
}
