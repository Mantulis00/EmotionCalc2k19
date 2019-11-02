﻿using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Logic.User;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Currency
{
    //Visible for UI classes
    //UserData wrapper
    class CurrencyManager
    {
        private UserData userData;
        private PersonalStore personalStore;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal IReadOnlyList<ThemePack> OwnedPacks { get { return userData.OwnedItems.Packs.AsReadOnly(); } }
        internal int LootboxAmount { get { return userData.OwnedItems.LootBoxAmount; } }
        internal int PremiumLootboxAmount { get { return userData.OwnedItems.PremiumLootBoxAmount; } }

        internal event EventHandler CurrencyChanged
        {
            add { userData.CurrencyChanged += value; }
            remove { userData.CurrencyChanged -= value; }
        }

        internal event EventHandler ConsumablesChanged
        {
            add { userData.OwnedItems.ConsumablesChanged += value; }
            remove { userData.OwnedItems.ConsumablesChanged -= value; }
        }

        internal IEnumerable<PurchasableItem> InexhaustibleItems { get { return personalStore.GetInexhaustibleItems(); } }
        internal IEnumerable<PurchasableItem> UnlockableThemes { get { return personalStore.GetThemePacks(); } }

        internal IEnumerable<PurchasableItem> PurchasableItems
        {
            get
            {
                return InexhaustibleItems.Concat(UnlockableThemes);
            }
        }

        internal CurrencyManager(UserData userData)
        {
            this.userData = userData;
            personalStore = new PersonalStore(userData);
        }

        internal OperationStatus Purchase(PurchasableItem item)
        {
            return item.TryPurchase(userData);
        }

        internal OperationStatus Consume(ConsumableType consumableType)
        {
            switch (consumableType)
            {
                case ConsumableType.LootBox:
                    if (userData.OwnedItems.LootBoxAmount > 0)
                    {
                        userData.OwnedItems.AddConsumables(ConsumableType.LootBox, -1);
                        //consume lootbox
                        return OperationStatus.Successful;
                    }
                    break;
                case ConsumableType.PremiumLootBox:
                    if (userData.OwnedItems.PremiumLootBoxAmount > 0)
                    {
                        userData.OwnedItems.AddConsumables(ConsumableType.PremiumLootBox, -1);
                        //consume premium lootbox
                        return OperationStatus.Successful;
                    }
                    break;
            }

            return OperationStatus.Unavailable;
        }
    }
}
