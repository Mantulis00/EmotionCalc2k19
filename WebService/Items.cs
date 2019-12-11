using System;
using System.Collections.Generic;

namespace WebService
{
    public partial class Items
    {
        public Items()
        {
            OwnedItems = new HashSet<OwnedItems>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }

        public ICollection<OwnedItems> OwnedItems { get; set; }
    }
}
