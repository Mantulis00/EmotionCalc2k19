using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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
            var doc = GetXmlDocument();
            var nodes = doc.Descendants();

            int joyCoins = GetNumberFromNode(nodes, CoinValueName);
            int joyGems = GetNumberFromNode(nodes, GemValueName);
            int dailyStreak = GetNumberFromNode(nodes, LoginStreakLengthName);

            int lastDay = GetNumberFromNode(nodes, LastLogOnDayName);
            int lastMonth = GetNumberFromNode(nodes, LastLogOnMonthName);
            int lastYear = GetNumberFromNode(nodes, LastLogOnYearName);

            DateTime lastLogin;

            if (!DateTime.TryParse($"{lastYear}-{lastMonth}-{lastDay}", out lastLogin))
                lastLogin = DateTime.Today;

            var pairs = new List<KeyValuePair<Emotion, int>>();

            foreach (Emotion emotion in Enum.GetValues(typeof(Emotion)))
            {
                pairs.Add(new KeyValuePair<Emotion, int>(emotion, GetNumberFromNode(nodes, EmotionCountPrefix + "_" + emotion.ToString())));
            }

            return new UserData(joyCoins, joyGems, dailyStreak, lastLogin, pairs, LoadItems(nodes));
        }

        private string GetValueFromNode(IEnumerable<XElement> nodes, string nodeName)
        {
            var node = nodes.FirstOrDefault(sNode => sNode.Name == nodeName);

            if (node != null)
            {
                return node.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        private int GetNumberFromNode(IEnumerable<XElement> nodes, string nodeName)
        {
            var value = GetValueFromNode(nodes, nodeName);
            int integer;

            if (int.TryParse(value, out integer))
            {
                return integer;
            }
            else
            {
                return 0;
            }
        }

        private OwnedItems LoadItems(IEnumerable<XElement> nodes)
        {
            int lootBoxAmount = GetNumberFromNode(nodes, LootBoxAmountName);
            int premiumLootBoxAmount = GetNumberFromNode(nodes, PremiumLootBoxAmountName);

            OwnedItems ownedItems = new OwnedItems(lootBoxAmount, premiumLootBoxAmount);

            var ownedPacks = GetValueFromNode(nodes, OwnedPackName);
            ownedItems.Packs.AddRange(DesktopPack.GetPackByName(ownedPacks.Split(',')));

            return ownedItems;
        }

        public void Save(UserData userData)
        {
            var doc = GetXmlDocument();

            SaveValueToNode(doc, CoinValueName, userData.JoyCoins.ToString());
            SaveValueToNode(doc, GemValueName, userData.JoyGems.ToString());
            SaveValueToNode(doc, LoginStreakLengthName, userData.DailyStreak.ToString());
            SaveValueToNode(doc, LastLogOnDayName, userData.LastLogin.Day.ToString());
            SaveValueToNode(doc, LastLogOnMonthName, userData.LastLogin.Month.ToString());
            SaveValueToNode(doc, LastLogOnYearName, userData.LastLogin.Year.ToString());

            userData.EmotionCount.ToList().ForEach(pair => SaveValueToNode(doc, EmotionCountPrefix + "_" + pair.Key.ToString(), pair.Value.ToString()));

            SaveItems(doc, userData.OwnedItems);

            doc.Save(FileName);
        }

        private void SaveValueToNode(XDocument document, string nodeName, string value)
        {
            var nodes = document.Descendants();
            var node = nodes.FirstOrDefault(sNode => sNode.Name == nodeName);

            if (node == null)
            {
                node = new XElement(nodeName);
                document.Root.Add(node);
            }

            node.Value = value;
        }

        private void SaveItems(XDocument document, OwnedItems ownedItems)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> strings = new List<string>();
            ownedItems.Packs.ForEach(pack => strings.Add(pack.Name));

            string joinedString = string.Join(",", strings);

            SaveValueToNode(document, OwnedPackName, joinedString);
            SaveValueToNode(document, LootBoxAmountName, ownedItems.LootBoxAmount.ToString());
            SaveValueToNode(document, PremiumLootBoxAmountName, ownedItems.PremiumLootBoxAmount.ToString());
        }

        private XDocument GetXmlDocument()
        {
            if (File.Exists(FileName))
            {
                return XDocument.Load(FileName);
            }
            else
            {
                XDocument xmlDocument = new XDocument();
                XElement root = new XElement("root");
                xmlDocument.Add(root);
                return xmlDocument;
            }
        }
    }
}
