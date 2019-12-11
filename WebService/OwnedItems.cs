using System;
using System.Collections.Generic;

namespace WebService
{
    public partial class OwnedItems
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }

        public Items Item { get; set; }
        public Users User { get; set; }
    }
}
