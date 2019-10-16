using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class ThemePack
    {
        internal Image Image { get; private set; }

        internal string Name { get; private set; }

        internal Color PrimaryColor { get; private set; }
        internal Color SecondaryColor { get; private set; }
        internal Color FocusColor { get; private set; }

        internal ThemePack(string name, Image image,
            Color primaryColor, Color secondaryColor, Color focusColor)
        {
            Name = name;
            Image = image;

            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            FocusColor = focusColor;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
