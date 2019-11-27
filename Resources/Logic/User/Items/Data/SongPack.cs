using System.IO;

namespace EmotionCalculator.EmotionCalculator.Logic.User.Items.Data
{
    public class SongPack : IItemable
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }
        public UnmanagedMemoryStream Song { get; private set; }

        internal SongPack(string name, string description, byte[] image, UnmanagedMemoryStream song)
        {
            Name = name;
            Description = description;
            Image = image;
            Song = song;
        }

        internal SongPack(string name, string description, byte[] image, object song)
        {
            Name = name;
            Description = description;
            Image = image;
            Song = (UnmanagedMemoryStream)song;
        }

        public override string ToString()
        {
            return Name;
        }

        public Item ToItem()
        {
            return new Item(Name, Description, ItemType.Song);
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
