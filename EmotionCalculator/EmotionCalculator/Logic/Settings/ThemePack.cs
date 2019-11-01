using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class ThemePack
    {
        internal Image Image { get; private set; }

        internal string Name { get; private set; }
        internal string Description { get; private set; }

        internal Color PrimaryColor { get; private set; }
        internal Color SecondaryColor { get; private set; }
        internal Color FocusColor { get; private set; }
        internal Color TextColor { get; private set; }

        internal ThemePack(string name, string description, Image image,
            Color primaryColor, Color secondaryColor, Color focusColor, Color textColor)
        {
            Name = name;
            Description = description;

            Image = image;

            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            FocusColor = focusColor;
            TextColor = textColor;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
