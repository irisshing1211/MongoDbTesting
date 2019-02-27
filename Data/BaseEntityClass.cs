using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace MongoDbTesting.Data
{
    public class BaseEntityClass
    {
        DateTime _createdAt = DateTime.Now, _updatedAt = DateTime.Now;
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public DateTime UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
    }

    public class BaseIdClass
    {
        [BsonId(IdGenerator = typeof(CounterIdGenerator))]
        public int Id { get; set; }
    }
    public class CounterIdGenerator : IIdGenerator
    {
        private static int _counter = 0;
        public object GenerateId(object container, object document)
        {
            return _counter++;
        }

        public bool IsEmpty(object id)
        {
            return id.Equals(default(int));
        }
    }
}
