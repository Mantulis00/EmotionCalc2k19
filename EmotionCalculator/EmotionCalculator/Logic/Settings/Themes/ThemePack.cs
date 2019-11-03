using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings.Themes
{
    class ThemePack
    {
        internal Image Image { get; private set; }

        internal string Name { get; private set; }
        internal string Description { get; private set; }

        internal Color PrimaryColor { get; private set; }
        internal Color SecondaryColor { get; private set; }
        internal Color FocusColor { get; private set; }
        internal Color FocusTextColor { get; private set; }
        internal Color PrimaryTextColor { get; private set; }

        internal ThemePack(string name, string description, Image image,
            Color primaryColor, Color secondaryColor, Color focusColor, Color focusTextColor, Color primaryTextColor)
        {
            Name = name;
            Description = description;

            Image = image;

            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
            FocusColor = focusColor;
            FocusTextColor = focusTextColor;
            PrimaryTextColor = primaryTextColor;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var themePack = (ThemePack)obj;

                return Image == themePack.Image
                    && Name == themePack.Name
                    && Description == themePack.Description
                    && PrimaryColor == themePack.PrimaryColor
                    && SecondaryColor == themePack.SecondaryColor
                    && FocusColor == themePack.FocusColor
                    && FocusTextColor == themePack.FocusTextColor
                    && PrimaryTextColor == themePack.PrimaryTextColor;
            }
        }
    }
}
