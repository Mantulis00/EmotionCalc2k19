using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmotionCalculator.EmotionCalculator.Logic.Data
{
    static class MonthEmotionsIO
    {
        private static readonly string folderName = @"data";

        internal static MonthEmotions LoadMonth(int year, Month month)
        {
            if (MonthSavedExists(year, month))
            {
                string directory = GetFullDirectory(year, month);

                using (FileStream fs = new FileStream(directory, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (MonthEmotions)bf.Deserialize(fs);
                }
            }
            else
            {
                return new MonthEmotions(year, month);
            }
        }

        internal static void SaveMonth(MonthEmotions monthEmotions)
        {
            string directory = GetFullDirectory(monthEmotions.Year, monthEmotions.Month);

            using (FileStream fs = new FileStream(directory, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, monthEmotions);
            }
        }

        internal static bool MonthSavedExists(int year, Month month)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            return File.Exists(GetFullDirectory(year, month));
        }

        private static string GetFullDirectory(int year, Month month)
        {
            return folderName + "\\" + month.ToString() + "_" + year + ".txt";
        }
    }
}
