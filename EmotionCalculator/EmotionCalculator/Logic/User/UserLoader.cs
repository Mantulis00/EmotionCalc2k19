using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using EmotionCalculator.EmotionCalculator.Tools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static EmotionCalculator.EmotionCalculator.Tools.IO.XMLTools;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    class UserLoader : IUserLoader
    {
        private static readonly string FileName = "userData.xml";
        private static readonly string CoinValueName = "coins";
        private static readonly string GemValueName = "gems";
        private static readonly string LoginStreakLengthName = "streakLength";
        private static readonly string LastLogOnDayName = "llday";
        private static readonly string LastLogOnMonthName = "llmonth";
        private static readonly string LastLogOnYearName = "llyear";
        private static readonly string EmotionCountPrefix = "EmC";
        private static readonly string OwnedPackName = "OwnedTPs";
        private static readonly string LootBoxAmountName = "LBAmount";
        private static readonly string PremiumLootBoxAmountName = "PLBAmount";

        public UserData Load()
        {
            var doc = GetXmlDocument(FileName);
            var nodes = doc.Descendants();

            int joyCoins = nodes.GetNumberFromNode(CoinValueName);
            int joyGems = nodes.GetNumberFromNode(GemValueName);
            int dailyStreak = nodes.GetNumberFromNode(LoginStreakLengthName);

            int lastDay = nodes.GetNumberFromNode(LastLogOnDayName);
            int lastMonth = nodes.GetNumberFromNode(LastLogOnMonthName);
            int lastYear = nodes.GetNumberFromNode(LastLogOnYearName);

            DateTime lastLogin;

            if (!DateTime.TryParse($"{lastYear}-{lastMonth}-{lastDay}", out lastLogin))
                lastLogin = DateTime.Today;

            var pairs = new List<KeyValuePair<Emotion, int>>();

            foreach (Emotion emotion in Enum.GetValues(typeof(Emotion)))
            {
                pairs.Add(new KeyValuePair<Emotion, int>(emotion, nodes.GetNumberFromNode(EmotionCountPrefix + "_" + emotion.ToString())));
            }

            return new UserData(joyCoins, joyGems, dailyStreak, lastLogin, pairs, LoadItems(nodes));
        }

        private OwnedItems LoadItems(IEnumerable<XElement> nodes)
        {
            int lootBoxAmount = nodes.GetNumberFromNode(LootBoxAmountName);
            int premiumLootBoxAmount = nodes.GetNumberFromNode(PremiumLootBoxAmountName);

            OwnedItems ownedItems = new OwnedItems(lootBoxAmount, premiumLootBoxAmount);

            var ownedPacks = nodes.GetValueFromNode(OwnedPackName);
            ownedItems.Packs.AddRange(DesktopPack.GetPackByName(ownedPacks.Split(',')));

            return ownedItems;
        }

        public void Save(UserData userData)
        {
            var doc = GetXmlDocument(FileName);

            doc.SaveValueToNode(CoinValueName, userData.JoyCoins.ToString());
            doc.SaveValueToNode(GemValueName, userData.JoyGems.ToString());
            doc.SaveValueToNode(LoginStreakLengthName, userData.DailyStreak.ToString());
            doc.SaveValueToNode(LastLogOnDayName, userData.LastLogin.Day.ToString());
            doc.SaveValueToNode(LastLogOnMonthName, userData.LastLogin.Month.ToString());
            doc.SaveValueToNode(LastLogOnYearName, userData.LastLogin.Year.ToString());

            userData.EmotionCount.ToList().ForEach(pair =>
                doc.SaveValueToNode(EmotionCountPrefix + "_" + pair.Key.ToString(), pair.Value.ToString()));

            SaveItems(doc, userData.OwnedItems);

            doc.Save(FileName);
        }

        private void SaveItems(XDocument document, OwnedItems ownedItems)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> strings = new List<string>();
            ownedItems.Packs.ForEach(pack => strings.Add(pack.Name));

            string joinedString = string.Join(",", strings);

            document.SaveValueToNode(OwnedPackName, joinedString);
            document.SaveValueToNode(LootBoxAmountName, ownedItems.LootBoxAmount.ToString());
            document.SaveValueToNode(PremiumLootBoxAmountName, ownedItems.PremiumLootBoxAmount.ToString());
        }
    }
}
