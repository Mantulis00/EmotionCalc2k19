using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    class CurrencyManager
    {
        private readonly UserData userData;
        internal PersonalStore PersonalStore { get; }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            PersonalStore = new PersonalStore(userData);
        }

        internal OperationStatus Purchase(CustomPurchase customPurchase)
        {
            var price = customPurchase.GetCustomPurchasePrice();

            return userData.Transact(price.Item1, price.Item2);
        }

        internal OperationStatus Consume(ConsumableType consumableType, out string rewardString)
        {
            OperationStatus status = userData.OwnedItems.Transact(consumableType, 1);

            if (status == OperationStatus.Successful)
            {
                LootManager.OpenLootBox(consumableType, userData, PersonalStore, out rewardString);
            }
            else
            {
                rewardString = string.Empty;
            }

            return status;
        }

        internal void TemporaryCurrencyEntryPoint(CurrencyType currencyType, int amount)
        {
            userData.AddCurrency(currencyType, amount);
        }
    }
}
