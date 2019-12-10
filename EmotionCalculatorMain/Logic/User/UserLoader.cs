using EmotionCalculator.EmotionCalculator.Logic.Currency.Purchases;
using EmotionCalculator.EmotionCalculator.Logic.User.Items;
using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using EmotionCalculator.EmotionCalculator.Tools.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static EmotionCalculator.EmotionCalculator.Tools.IO.XMLTools;

namespace EmotionCalculator.EmotionCalculator.Logic.User
{
    public class UserLoader : IUserLoader
    {
        private static readonly string FileName = "userData.xml";
        private static readonly string CoinValueName = "coins";
        private static readonly string GemValueName = "gems";
        private static readonly string LoginStreakLengthName = "streakLength";
        private static readonly string LastLogOnDayName = "llday";
        private static readonly string LastLogOnMonthName = "llmonth";
        private static readonly string LastLogOnYearName = "llyear";
        private static readonly string EmotionCountPrefix = "EmC_";

        private static string GetItemName(ItemType itemType)
        {
            return "Owned_" + itemType + "s";
        }

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

            if (!DateTime.TryParse($"{lastYear}-{lastMonth}-{lastDay}", out DateTime lastLogin))
                lastLogin = DateTime.Today;

            var pairs = new List<KeyValuePair<Emotion, int>>();

            foreach (Emotion emotion in Enum.GetValues(typeof(Emotion)))
            {
                pairs.Add(new KeyValuePair<Emotion, int>(emotion, nodes.GetNumberFromNode(EmotionCountPrefix + emotion.ToString())));
            }

            return new UserData(joyCoins, joyGems, dailyStreak, lastLogin, pairs, LoadItems(nodes));
        }

        private OwnedItems LoadItems(IEnumerable<XElement> nodes)
        {
            OwnedItems ownedItems = new OwnedItems();

            foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
            {
                var allValues = nodes.GetValueFromNode(GetItemName(itemType));

                var splitStrings = allValues.Split(',');

                foreach (var splitString in splitStrings)
                {
                    var twoStrings = splitString.Split(':');

                    string name = twoStrings.ElementAtOrDefault(0);
                    int.TryParse(twoStrings.ElementAtOrDefault(1), out int amount);

                    Item item = GetItemByNameAndType(itemType, name);

                    ownedItems.AddItems(item, amount);
                }
            }

            return ownedItems;
        }

        private Item GetItemByNameAndType(ItemType itemType, string name)
        {
            switch (itemType)
            {
                case ItemType.Theme:
                    return ThemePackManager.GetItemByPack(ThemePackManager.GetPackByName(name));
                case ItemType.Song:
                    return SongPackManager.GetItemByPack(SongPackManager.GetPackByName(name));
                case ItemType.Hat:
                    break;
                case ItemType.Item:
                    break;
                case ItemType.Skin:
                    break;
                case ItemType.LootBox:
                    return ConsumableManager.GetItemByName(name);
            }

            return null;
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
                doc.SaveValueToNode(EmotionCountPrefix + pair.Key.ToString(), pair.Value.ToString()));

            SaveItems(doc, userData.OwnedItems);

            doc.Save(FileName);
        }

        private void SaveItems(XDocument document, OwnedItems ownedItems)
        {
            List<string> strings = new List<string>();

            foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
            {
                var pairs = ownedItems.Items.Where(pair => pair.Item.ItemType == itemType);

                foreach (var pair in pairs)
                {
                    strings.Add(string.Join(":", pair.Item.Name.ToString(), pair.Count.ToString()));
                }

                document.SaveValueToNode(GetItemName(itemType), string.Join(",", strings));
                strings.Clear();
            }
        }
    }
}
