using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbTesting.Data
{
   public class AccountRole :BaseIdClass
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
    }
}
