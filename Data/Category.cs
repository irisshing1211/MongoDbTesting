using System;

namespace MongoDbTesting.Data
{
    public class Category : BaseEntityClass
    {        
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
    }
}
