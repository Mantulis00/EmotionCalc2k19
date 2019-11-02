﻿using EmotionCalculator.EmotionCalculator.Logic.Settings;
using System;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases
{
    class OwnedItems
    {
        internal List<ThemePack> Packs { get; }

        internal int LootBoxAmount { get; private set; }
        internal int PremiumLootBoxAmount { get; private set; }

        internal OwnedItems(int lootBoxAmount, int premiumLootBoxAmount)
        {
            Packs = new List<ThemePack>();

            LootBoxAmount = lootBoxAmount;
            PremiumLootBoxAmount = premiumLootBoxAmount;
        }

        internal event EventHandler ConsumablesChanged;

        internal void AddConsumables(ConsumableType consumableType, int amount)
        {
            switch (consumableType)
            {
                case ConsumableType.LootBox:
                    LootBoxAmount += amount;
                    LootBoxAmount = Math.Max(0, LootBoxAmount);
                    break;
                case ConsumableType.PremiumLootBox:
                    PremiumLootBoxAmount += amount;
                    PremiumLootBoxAmount = Math.Max(0, PremiumLootBoxAmount);
                    break;
            }

            ConsumablesChanged?.Invoke(this, EventArgs.Empty);
        }

        internal void Update()
        {
            ConsumablesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
