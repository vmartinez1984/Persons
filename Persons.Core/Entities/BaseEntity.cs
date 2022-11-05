using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persons.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DateRegistration { get; set; } = DateTime.Now;

        public string UserId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}