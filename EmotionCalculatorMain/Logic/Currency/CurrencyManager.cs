using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    public class CurrencyManager
    {
        private readonly UserData userData;
        public PersonalStore PersonalStore { get; }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            PersonalStore = new PersonalStore(userData);
        }

        public OperationStatus Purchase(CustomPurchase customPurchase)
        {
            var price = customPurchase.GetCustomPurchasePrice();

            return userData.Transact(price.Item1, price.Item2);
        }

        public OperationStatus Consume(ConsumableType consumableType, out string rewardString)
        {
            OperationStatus status = userData.OwnedItems.Transact(PersonalStore, consumableType, 1);

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

        public void TemporaryCurrencyEntryPoint(CurrencyType currencyType, int amount)
        {
            userData.AddCurrency(currencyType, amount);
        }
    }
}
