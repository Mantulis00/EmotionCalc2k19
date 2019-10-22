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

            UserData userData = new UserData();

            var nodes = doc.Descendants();

            try
            {
                userData.JoyCoins = int.Parse(GetValueFromNode(nodes, CoinValueName));
                userData.JoyGems = int.Parse(GetValueFromNode(nodes, GemValueName));
                userData.DailyLoginStreak = int.Parse(GetValueFromNode(nodes, LoginStreakLengthName));

                int lastDay = int.Parse(GetValueFromNode(nodes, LastLogOnDayName));
                int lastMonth = int.Parse(GetValueFromNode(nodes, LastLogOnMonthName));
                int lastYear = int.Parse(GetValueFromNode(nodes, LastLogOnYearName));

                userData.LastLogOn = new DateTime(lastYear, lastMonth, lastDay);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.StackTrace);
            }

            return userData;
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

        public void Save(UserData userData)
        {
            var doc = GetXmlDocument();

            SaveValueToNode(doc, CoinValueName, userData.JoyCoins.ToString());
            SaveValueToNode(doc, GemValueName, userData.JoyGems.ToString());
            SaveValueToNode(doc, LoginStreakLengthName, userData.DailyLoginStreak.ToString());
            SaveValueToNode(doc, LastLogOnDayName, userData.LastLogOn.Day.ToString());
            SaveValueToNode(doc, LastLogOnMonthName, userData.LastLogOn.Month.ToString());
            SaveValueToNode(doc, LastLogOnYearName, userData.LastLogOn.Year.ToString());

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
