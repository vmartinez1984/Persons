using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persons.Core.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PersonEntity Person { get; set; }

        public string Role { get; set; }
    }
}