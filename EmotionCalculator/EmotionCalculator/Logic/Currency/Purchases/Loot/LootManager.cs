using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot
{
    class LootManager
    {
        private static Random Random = new Random();

        private static Dictionary<LootType, int> LootBoxPowers = new Dictionary<LootType, int>
        {
            { LootType.Coins, 70},
            { LootType.Gems, 4},
            { LootType.ThemePack, 6},
            { LootType.Song, 8},
            { LootType.Emotion, 20},
        };

        private static Dictionary<LootType, int> PremiumLootBoxPowers = new Dictionary<LootType, int>
        {
            { LootType.Coins, 30},
            { LootType.Gems, 5},
            { LootType.ThemePack, 10},
            { LootType.Song, 15},
            { LootType.Emotion, 10},
        };

        public static void OpenLootBox(ConsumableType consumableType, UserData userData, out string rewardString)
        {
            bool premium = consumableType == ConsumableType.PremiumLootBox;

            LootType lootType = GetLootType(userData, premium ? PremiumLootBoxPowers : LootBoxPowers);

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
                    AddRandomUnownedThemePack(userData, out rewardString);
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

        private static void AddRandomUnownedThemePack(UserData userData, out string rewardString)
        {
            var unownedPacks = DesktopPack.DesktopPacks.Where(
                pack => !userData.OwnedItems.ThemePacks.Contains(pack));

            if (unownedPacks.Count() != 0)
            {
                var pack = unownedPacks.ElementAt(Random.Next(0, unownedPacks.Count() - 1));
                userData.OwnedItems.ThemePacks.Add(pack);

                rewardString = $"{pack.Name} Theme Pack.";
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

        private static LootType GetLootType(UserData userData, Dictionary<LootType, int> lootPowers)
        {
            RemoveUnavailableValues(userData, lootPowers);

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

        private static void RemoveUnavailableValues(UserData userData, Dictionary<LootType, int> lootPowers)
        {
            if (lootPowers.ContainsKey(LootType.Song))
            {
                lootPowers.Remove(LootType.Song);
            }

            if (lootPowers.ContainsKey(LootType.ThemePack))
            {
                if (DesktopPack.DesktopPacks.Count() == userData.OwnedItems.ThemePacks.Count)
                    lootPowers.Remove(LootType.ThemePack);

            }
        }
    }
}
