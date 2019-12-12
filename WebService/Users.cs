using System;
using System.Collections.Generic;

namespace WebService
{
    public partial class Users
    {
        public Users()
        {
            OwnedItems = new HashSet<OwnedItems>();
        }

        public int Id { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }

        public UserData UserData { get; set; }
        public ICollection<OwnedItems> OwnedItems { get; set; }
    }
}
