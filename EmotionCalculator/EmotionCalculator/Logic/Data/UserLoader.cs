using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
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

        public UserData Load()
        {
            var doc = GetXmlDocument();
            var nodes = doc.Descendants();

            int joyCoins = GetValueFromNode(nodes, CoinValueName);
            int joyGems = GetValueFromNode(nodes, GemValueName);
            int dailyStreak = GetValueFromNode(nodes, LoginStreakLengthName);

            int lastDay = GetValueFromNode(nodes, LastLogOnDayName);
            int lastMonth = GetValueFromNode(nodes, LastLogOnMonthName);
            int lastYear = GetValueFromNode(nodes, LastLogOnYearName);

            DateTime lastLogin;

            if (!DateTime.TryParse($"{lastYear}-{lastMonth}-{lastDay}", out lastLogin))
                lastLogin = DateTime.Today;

            return new UserData(joyCoins, joyGems, dailyStreak, lastLogin);
        }

        private int GetValueFromNode(IEnumerable<XElement> nodes, string nodeName)
        {
            var node = nodes.FirstOrDefault(sNode => sNode.Name == nodeName);

            if (node != null)
            {
                int value;

                if (int.TryParse(node.Value, out value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
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
