using System;
using System.Collections.Generic;

namespace WebService
{
    public partial class Users
    {
        public int Id { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }

        public OwnedItems OwnedItems { get; set; }
        public UserData UserData { get; set; }
    }
}
