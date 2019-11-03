using System.Drawing;
using System.IO;

namespace EmotionCalculator.EmotionCalculator.Logic.Data.Songs
{
    class SongPack
    {
        internal string Name { get; private set; }
        internal string Description { get; private set; }
        internal Image Image { get; private set; }
        internal UnmanagedMemoryStream Song { get; private set; }

        internal SongPack(string name, string description, Image image, UnmanagedMemoryStream song)
        {
            Name = name;
            Description = description;
            Image = image;
            Song = song;
        }

        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(GetType()))
            {
                return false;
            }
            else
            {
                var pack = (SongPack)obj;

                return Name == pack.Name
                    && Description == pack.Description
                    && Image == pack.Image
                    && Song == pack.Song;
            }
        }
    }
}
