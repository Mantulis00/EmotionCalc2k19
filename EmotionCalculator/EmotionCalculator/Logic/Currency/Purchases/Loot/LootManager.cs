using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Shop;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot
{
    class LootManager
    {
        private static readonly Random Random = new Random();

        private static readonly Dictionary<LootType, int> LootBoxPowers = new Dictionary<LootType, int>
        {
            { LootType.Coins, 70},
            { LootType.Gems, 4},
            { LootType.ThemePack, 6},
            { LootType.Song, 8},
            { LootType.Emotion, 20},
        };

        private static readonly Dictionary<LootType, int> PremiumLootBoxPowers = new Dictionary<LootType, int>
        {
            { LootType.Coins, 30},
            { LootType.Gems, 5},
            { LootType.ThemePack, 10},
            { LootType.Song, 15},
            { LootType.Emotion, 10},
        };

        public static void OpenLootBox(ConsumableType consumableType, UserData userData,
            PersonalStore personalStore, out string rewardString)
        {
            bool premium = consumableType == ConsumableType.PremiumLootBox;

            LootType lootType = GetLootType(personalStore, premium ? PremiumLootBoxPowers : LootBoxPowers);

            switch (lootType)
            {
                default:
                case LootType.Coins:
                    AddCoins(userData, premium ? GetRandomValue(100, 300) : GetRandomValue(20, 100), out rewardString);
                    break;
                case LootType.Gems:
                    AddGems(userData, premium ? GetRandomValue(1, 3) : 1 + GetRandomBonus(0.3, 1), out rewardString);
                    break;
                case LootType.Emotion:
                    AddRandomEmotion(userData, premium ? GetRandomValue(7, 13) : GetRandomValue(1, 5), out rewardString);
                    break;
                case LootType.ThemePack:
                    AddRandomUnownedThemePack(userData, personalStore, out rewardString);
                    break;
            }
        }

        private static void AddCoins(UserData userData, int amount, out string rewardString)
        {
            userData.AddCurrency(CurrencyType.JoyCoin, amount);
            rewardString = $"{amount} Joy Coin{(amount > 1 ? "s" : string.Empty)}";
        }

        private static void AddGems(UserData userData, int amount, out string rewardString)
        {
            userData.AddCurrency(CurrencyType.JoyGem, amount);
            rewardString = $"{amount} Joy Gem{(amount > 1 ? "s" : string.Empty)}";
        }

        private static int GetRandomValue(int baseAmount, int randomBonus)
        {
            return baseAmount + (int)(randomBonus * Random.NextDouble());
        }

        private static int GetRandomBonus(double probability, int bonus)
        {
            if (Random.NextDouble() <= probability)
                return bonus;
            else
                return 0;
        }

        private static void AddRandomUnownedThemePack(UserData userData, PersonalStore personalStore, out string rewardString)
        {
            var unownedPacks = personalStore.GetPersonalPurchases()
                .Where(purchase => purchase.Item.ItemType == ItemType.Theme
                    && (purchase.ItemPrice.LootDropType == LootDropType.Always
                    || (purchase.ItemPrice.LootDropType == LootDropType.WhenAvailable && purchase.Available)))
                .Select(purchase => purchase.Item);

            if (unownedPacks.Count() != 0)
            {
                var selectedPack = unownedPacks.ElementAt(Random.Next(0, unownedPacks.Count() - 1));
                userData.OwnedItems.AddItem(selectedPack);

                rewardString = $"{selectedPack.Name} Theme Pack.";
            }
            else
            {
                rewardString = string.Empty;
            }
        }

        private static void AddRandomEmotion(UserData userData, int amount, out string rewardString)
        {
            List<Emotion> emotions = new List<Emotion>()
            {
                Emotion.Anger,
                Emotion.Contempt,
                Emotion.Disgust,
                Emotion.Fear,
                Emotion.Happiness,
                Emotion.Sadness,
                Emotion.Surprise,
                Emotion.Neutral,
            };

            var emotion = emotions[Random.Next(emotions.Count)];

            userData.AddCurrency(emotion, amount);

            rewardString = $"{amount} of emotion '{emotion.ToString()}'";
        }

        private static LootType GetLootType(PersonalStore personalStore, Dictionary<LootType, int> lootPowers)
        {
            RemoveUnavailableValues(personalStore, lootPowers);

            int totalPower = 0;
            lootPowers.ToList().ForEach(pair => totalPower += pair.Value);
            totalPower = (int)(totalPower * Random.NextDouble());

            foreach (var pair in lootPowers)
            {
                totalPower -= pair.Value;

                if (totalPower <= 0)
                {
                    return pair.Key;
                }
            }

            return LootType.Coins;
        }

        private static void RemoveUnavailableValues(PersonalStore personalStore, Dictionary<LootType, int> lootPowers)
        {
            var droppableItems = personalStore.GetPersonalPurchases().Where(purchase => purchase.ItemPrice.LootDropType == LootDropType.Always
                || purchase.ItemPrice.LootDropType == LootDropType.WhenAvailable && purchase.Available);

            var filteredItems = droppableItems.Where(item => new ItemType[] { ItemType.Theme, ItemType.Song }.Contains(item.Item.ItemType))
                .Select(item => item.Item);

            if (!filteredItems.Any(item => item.ItemType == ItemType.Theme))
                lootPowers.Remove(LootType.ThemePack);

            if (!filteredItems.Any(item => item.ItemType == ItemType.Song))
                lootPowers.Remove(LootType.Song);
        }
    }
}
