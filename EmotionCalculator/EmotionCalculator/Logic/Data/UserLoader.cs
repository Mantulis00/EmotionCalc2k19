using EmotionCalculator.EmotionCalculator.Logic.User;
using System;
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

            var node = nodes.FirstOrDefault(sNode => sNode.Name == CoinValueName);
            if (node != null)
            {
                userData.JoyCoins = int.Parse(node.Value);
            }

            node = nodes.FirstOrDefault(sNode => sNode.Name == GemValueName);
            if (node != null)
            {
                userData.JoyGems = int.Parse(node.Value);
            }

            node = nodes.FirstOrDefault(sNode => sNode.Name == LoginStreakLengthName);
            if (node != null)
            {
                userData.DailyLoginStreak = int.Parse(node.Value);
            }

            var dayNode = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnDayName);
            var monthNode = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnMonthName);
            var yearNode = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnYearName);

            if (dayNode != null && monthNode != null && yearNode != null)
            {
                userData.LastLogOn = new DateTime(
                    int.Parse(yearNode.Value),
                    int.Parse(monthNode.Value),
                    int.Parse(dayNode.Value));
            }

            return userData;
        }

        public void Save(UserData userData)
        {
            var doc = GetXmlDocument();

            var nodes = doc.Descendants();

            var node = nodes.FirstOrDefault(sNode => sNode.Name == CoinValueName);
            if (node == null)
            {
                node = new XElement(CoinValueName);
                doc.Root.Add(node);
            }
            node.Value = userData.JoyCoins.ToString();

            node = nodes.FirstOrDefault(sNode => sNode.Name == GemValueName);
            if (node == null)
            {
                node = new XElement(GemValueName);
                doc.Root.Add(node);
            }
            node.Value = userData.JoyGems.ToString();

            node = nodes.FirstOrDefault(sNode => sNode.Name == LoginStreakLengthName);
            if (node == null)
            {
                node = new XElement(LoginStreakLengthName);
                doc.Root.Add(node);
            }
            node.Value = userData.DailyLoginStreak.ToString();

            node = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnDayName);
            if (node == null)
            {
                node = new XElement(LastLogOnDayName);
                doc.Root.Add(node);
            }
            node.Value = userData.LastLogOn.Day.ToString();

            node = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnMonthName);
            if (node == null)
            {
                node = new XElement(LastLogOnMonthName);
                doc.Root.Add(node);
            }
            node.Value = userData.LastLogOn.Month.ToString();

            node = nodes.FirstOrDefault(sNode => sNode.Name == LastLogOnYearName);
            if (node == null)
            {
                node = new XElement(LastLogOnYearName);
                doc.Root.Add(node);
            }
            node.Value = userData.LastLogOn.Year.ToString();


            doc.Save(FileName);
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
