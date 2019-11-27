using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.IO;
using System.Xml.Linq;
using static EmotionCalculator.EmotionCalculator.Tools.IO.XMLTools;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    public class MonthEmotionsIO : IMonthLogger
    {
        private static readonly string folderName = @"data";

        public MonthEmotions LoadMonth(int year, Month month)
        {
            XDocument doc = GetXmlDocument(GetFullDirectory(year, month));
            var nodes = doc.Descendants();

            var monthEmotions = new MonthEmotions(year, month);

            for (int i = 1; i <= DateTime.DaysInMonth(year, (int)month); i++)
            {
                var emotionString = nodes.GetValueFromNode($"D{i.ToString()}");

                if (!Enum.TryParse(emotionString, out Emotion emotion))
                {
                    emotion = Emotion.NotSet;
                }

                monthEmotions.SetEmotion(i, emotion);
            }

            return monthEmotions;
        }

        public void SaveMonth(MonthEmotions monthEmotions)
        {
            XDocument doc = GetXmlDocument(GetFullDirectory(monthEmotions.Year, monthEmotions.Month));

            for (int i = 1; i <= DateTime.DaysInMonth(monthEmotions.Year, (int)monthEmotions.Month); i++)
            {
                doc.SaveValueToNode($"D{i.ToString()}", monthEmotions[i].ToString());
            }

            doc.Save(GetFullDirectory(monthEmotions.Year, monthEmotions.Month));
        }

        private static string GetFullDirectory(int year, Month month)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            return Path.Combine(folderName, month.ToString() + "_" + year + ".xml");
        }
    }
}
