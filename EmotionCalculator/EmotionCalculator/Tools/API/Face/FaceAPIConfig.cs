using System.IO;
using System.Xml;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    static class FaceAPIConfig
    {
        private static readonly string configName = "faceapi.config";

        private static readonly string endpointName = "endpoint";
        private static readonly string subKeyName = "subkey";

        internal static bool ConfigExists()
        {
            return File.Exists(configName);
        }

        internal static void SaveConfig(FaceAPIKey faceAPIKey)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.AppendChild(xmlDocument.CreateElement("root"));

            XmlElement endpointNode = xmlDocument.CreateElement(endpointName);
            endpointNode.InnerText = faceAPIKey.APIEndpoint;
            xmlDocument.DocumentElement.AppendChild(endpointNode);

            XmlElement subKeyNode = xmlDocument.CreateElement(subKeyName);
            subKeyNode.InnerText = faceAPIKey.SubscriptionKey;
            xmlDocument.DocumentElement.AppendChild(subKeyNode);

            File.WriteAllText(configName, xmlDocument.OuterXml);
        }

        internal static FaceAPIKey LoadConfig()
        {
            if (File.Exists(configName))
            {
                string fileData;

                using (FileStream fileStream = new FileStream(configName, FileMode.Open))
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    fileData = streamReader.ReadToEnd();
                }

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(fileData);

                XmlNode root = xmlDocument.DocumentElement;

                string apiEndpoint = string.Empty;
                string subscriptionKey = string.Empty;

                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Name.Equals(endpointName))
                        apiEndpoint = node.InnerText;
                    else if (node.Name.Equals(subKeyName))
                        subscriptionKey = node.InnerText;
                }

                return new FaceAPIKey(subscriptionKey, apiEndpoint);
            }
            else
            {
                return new FaceAPIKey();
            }
        }
    }
}
