using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Persons.Core.Entities
{
    public class PersonEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<string> ListEmails { get; set; }

        public List<PhoneEntity> ListPhones { get; set; }

        public List<AddressEntity> ListAddresses { get; set; }

        public string UserId { get; set; }
    }
}