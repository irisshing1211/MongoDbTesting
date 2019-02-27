using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbTesting.Data
{
   public class Account : BaseEntityClass
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
