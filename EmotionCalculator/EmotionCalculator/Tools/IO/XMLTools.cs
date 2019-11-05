using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EmotionCalculator.EmotionCalculator.Tools.IO
{
    static class XMLTools
    {
        public static string GetValueFromNode(this IEnumerable<XElement> nodes, string nodeName)
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

        public static int GetNumberFromNode(this IEnumerable<XElement> nodes, string nodeName)
        {
            var value = nodes.GetValueFromNode(nodeName);

            if (int.TryParse(value, out int integer))
            {
                return integer;
            }
            else
            {
                return 0;
            }
        }

        public static void SaveValueToNode(this XDocument document, string nodeName, string value)
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

        public static XDocument GetXmlDocument(string fileName)
        {
            if (File.Exists(fileName))
            {
                return XDocument.Load(fileName);
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
