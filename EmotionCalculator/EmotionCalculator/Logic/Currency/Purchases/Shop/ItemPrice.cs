using System;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop
{
    class ItemPrice
    {
        internal CurrencyType CurrencyType { get; }
        internal int Price { get; }
        internal bool Available { get => isAvailable.Invoke(); }
        internal LootDropType LootDropType { get; }
        internal PriceType PriceType { get; }

        private Func<bool> isAvailable;

        internal static ItemPrice Unavailable
        {
            get
            {
                return new ItemPrice(CurrencyType.JoyCoin, 0, PriceType.Unlockable,
                    Availability.Unavailable, LootDropType.Never);
            }
        }

        private ItemPrice(CurrencyType currencyType, int price,
            PriceType priceType, LootDropType lootDropType)
        {
            CurrencyType = currencyType;
            Price = price;
            PriceType = priceType;
            LootDropType = lootDropType;
        }

        internal ItemPrice(CurrencyType currencyType, int price, PriceType priceType,
            Func<bool> isAvailable, LootDropType lootDropType = LootDropType.Always)
            : this(currencyType, price, priceType, lootDropType)
        {
            this.isAvailable = isAvailable;
        }

        internal ItemPrice(CurrencyType currencyType, int price, PriceType priceType,
            Availability availability = Availability.Default,
            LootDropType lootDropType = LootDropType.Always)
            : this(currencyType, price, priceType, lootDropType)
        {
            SetIsAvailable(availability);
        }

        private void SetIsAvailable(Availability availability)
        {
            switch (availability)
            {
                case Availability.Default:
                    isAvailable = () => true;
                    break;
                case Availability.Unavailable:
                    isAvailable = () => false;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Price} {(CurrencyType == CurrencyType.JoyCoin ? "Joy Coins" : "Joy Gems")}";
        }
    }
}
