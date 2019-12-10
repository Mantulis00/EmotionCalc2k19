using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    public class ThemePack : IItemable
    {
        public byte[] Image { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public Color PrimaryColor { get; private set; }
        public Color SecondaryColor { get; private set; }
        public Color FocusColor { get; private set; }
        public Color FocusTextColor { get; private set; }
        public Color PrimaryTextColor { get; private set; }

        internal ThemePack(string name, string description, byte[] image,
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

        public Item ToItem()
        {
            return new Item(Name, Description, ItemType.Theme);
        }
    }
}
