using EmotionCalculator.EmotionCalculator.Logic.User.Items.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static EmotionCalculator.EmotionCalculator.Tools.IO.XMLTools;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    public class SettingsLogger : ISettingsLogger
    {
        private static readonly string FileName = "settings.xml";
        private static readonly string SelectedThemeNodeName = "selectedTheme";

        public Dictionary<SettingType, SettingStatus> LoadSettings()
        {
            var settings = new Dictionary<SettingType, SettingStatus>();
            var nodes = GetXmlDocument(FileName).Descendants();

            foreach (var settingType in Enum.GetNames(typeof(SettingType)))
            {
                var viableNode = nodes.FirstOrDefault(node => node.Name == settingType.ToString());

                if (viableNode != null)
                {
                    settings.Add((SettingType)Enum.Parse(typeof(SettingType), settingType),
                        (SettingStatus)Enum.Parse(typeof(SettingStatus), viableNode.Value));
                }
            }

            return settings;
        }

        public ThemePack LoadTheme()
        {
            var themeNode = GetXmlDocument(FileName).Descendants().FirstOrDefault(node => node.Name == SelectedThemeNodeName);

            if (themeNode != null)
            {
                var pack = ThemePackManager.ThemePacks.FirstOrDefault(sPack => sPack.Name == themeNode.Value);

                if (pack != null)
                {
                    return pack;
                }
            }

            return ThemePackManager.ThemePacks.First();
        }

        public void SaveSettings(Dictionary<SettingType, SettingStatus> settings)
        {
            XDocument xmlDocument = GetXmlDocument(FileName);
            var nodes = xmlDocument.Descendants();

            foreach (var setting in settings.Keys)
            {
                var settingNode = nodes.FirstOrDefault(node => node.Name == setting.ToString());

                if (settingNode == null)
                {
                    settingNode = new XElement(setting.ToString());
                    xmlDocument.Root.Add(settingNode);
                }

                settingNode.Value = settings[setting].ToString();
            }

            xmlDocument.Save(FileName);
        }

        public void SaveTheme(ThemePack themePack)
        {
            XDocument xmlDocument = GetXmlDocument(FileName);

            var themeNode = xmlDocument.Descendants().FirstOrDefault(node => node.Name == SelectedThemeNodeName);

            if (themeNode == null)
            {
                themeNode = new XElement(SelectedThemeNodeName);
                xmlDocument.Root.Add(themeNode);
            }

            themeNode.Value = themePack.Name;

            xmlDocument.Save(FileName);
        }
    }
}
