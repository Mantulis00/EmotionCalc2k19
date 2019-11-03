using EmotionCalculator.EmotionCalculator.Logic.Data.Songs;
using EmotionCalculator.EmotionCalculator.Logic.Settings.Themes;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    //UserData wrapper
    class ReadOnlyUserData
    {
        private readonly UserData userData;

        internal int JoyCoins { get { return userData.JoyCoins; } }
        internal int JoyGems { get { return userData.JoyGems; } }
        internal int DailyStreak { get { return userData.DailyStreak; } }
        internal DateTime LastLogin { get { return userData.LastLogin; } }
        internal ReadOnlyDictionary<Emotion, int> EmotionCount { get { return userData.EmotionCount; } }
        internal IReadOnlyList<ThemePack> OwnedThemePacks { get { return userData.OwnedItems.ThemePacks.AsReadOnly(); } }
        internal IReadOnlyList<SongPack> OwnedSongPacks { get { return userData.OwnedItems.SongPacks.AsReadOnly(); } }
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

        internal ReadOnlyUserData(UserData userData)
        {
            this.userData = userData;
        }
    }
}
