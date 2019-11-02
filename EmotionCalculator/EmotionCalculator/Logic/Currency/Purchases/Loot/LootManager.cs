using EmotionCalculator.EmotionCalculator.Logic.User;
using System.Collections.Generic;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases.Loot
{
    class LootManager
    {
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

        public static void OpenLootBox(UserData userData)
        {
            LootType lootType = GetLootType(userData, LootBoxPowers);
        }

        public static void OpenPremiumLootBox(UserData userData)
        {
            LootType lootType = GetLootType(userData, PremiumLootBoxPowers);
        }

        private static LootType GetLootType(UserData userData, Dictionary<LootType, int> lootPowers)
        {
            RemoveUnavailableValues(userData, lootPowers);

            int totalPower = 0;
            lootPowers.ToList().ForEach(pair => totalPower += pair.Value);

            foreach (var pair in lootPowers)
            {
                totalPower -= pair.Value;

                if (totalPower == 0)
                {
                    return pair.Key;
                }
            }

            return LootType.Coins;
        }

        private static void RemoveUnavailableValues(UserData userData, Dictionary<LootType, int> lootPowers)
        {
            if (lootPowers.ContainsKey(LootType.Clothing))
            {
                lootPowers.Remove(LootType.Clothing);
            }

            if (lootPowers.ContainsKey(LootType.Skin))
            {
                lootPowers.Remove(LootType.Skin);
            }

            if (lootPowers.ContainsKey(LootType.Visual))
            {
                lootPowers.Remove(LootType.Visual);
            }

            if (lootPowers.ContainsKey(LootType.Song))
            {
                lootPowers.Remove(LootType.Song);
            }

            if (lootPowers.ContainsKey(LootType.ThemePack))
            {


                lootPowers.Remove(LootType.Song);
            }

            if (lootPowers.ContainsKey(LootType.Song))
            {
                lootPowers.Remove(LootType.Song);
            }
        }
    }
}
