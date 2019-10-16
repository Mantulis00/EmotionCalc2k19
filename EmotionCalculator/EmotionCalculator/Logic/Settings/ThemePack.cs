using System.Drawing;

namespace EmotionCalculator.EmotionCalculator.Logic.Settings
{
    class ThemePack
    {
        internal Image Image { get; private set; }

        internal string Name { get; private set; }

        internal ThemePack(string name, Image image)
        {
            Name = name;
            Image = image;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
