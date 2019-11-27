namespace EmotionCalculator.EmotionCalculator.Logic.User.Items
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public ItemType ItemType { get; }

        internal Item(string name, string description, ItemType itemType)
        {
            Name = name;
            Description = description;
            ItemType = itemType;
        }

        public override string ToString()
        {
            return Name + " " + ItemType.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(GetType()))
            {
                return false;
            }
            else
            {
                var item = (Item)obj;

                return Name == item.Name
                    && Description == item.Description
                    && ItemType == item.ItemType;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Description.GetHashCode();
                hash = hash * 23 + ItemType.GetHashCode();
                return hash;
            }
        }
    }
}
