using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    class MonthEmotionsIO : IMonthLogger
    {
        private static readonly string folderName = @"data";

        public MonthEmotions LoadMonth(int year, Month month)
        {
            XDocument doc = GetXmlDocument(year, month);
            var nodes = doc.Descendants();

            var monthEmotions = new MonthEmotions(year, month);

            for (int i = 1; i <= DateTime.DaysInMonth(year, (int)month); i++)
            {
                var emotionString = GetValueFromNode(nodes, $"D{i.ToString()}");
                Emotion emotion;

                if (!Enum.TryParse(emotionString, out emotion))
                {
                    emotion = Emotion.NotSet;
                }

                monthEmotions.SetEmotion(i, emotion);
            }

            return monthEmotions;
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

        public void SaveMonth(MonthEmotions monthEmotions)
        {
            XDocument doc = GetXmlDocument(monthEmotions.Year, monthEmotions.Month);

            for (int i = 1; i <= DateTime.DaysInMonth(monthEmotions.Year, (int)monthEmotions.Month); i++)
            {
                SaveValueToNode(doc, $"D{i.ToString()}", monthEmotions[i].ToString());
            }

            doc.Save(GetFullDirectory(monthEmotions.Year, monthEmotions.Month));
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

        private static string GetFullDirectory(int year, Month month)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            return Path.Combine(folderName, month.ToString() + "_" + year + ".xml");
        }

        private XDocument GetXmlDocument(int year, Month month)
        {
            if (File.Exists(GetFullDirectory(year, month)))
            {
                return XDocument.Load(GetFullDirectory(year, month));
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
