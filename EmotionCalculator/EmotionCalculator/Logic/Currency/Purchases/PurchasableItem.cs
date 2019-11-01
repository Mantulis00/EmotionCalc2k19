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
            CurrencyType = currencyType;
            Price = price;
        }

        internal abstract void Purchase();

        public override string ToString()
        {
            return $"{Name} - {Price} {(CurrencyType == CurrencyType.JoyCoin ? "Joy Coins" : "Joy Gems")}";
        }
    }
}
