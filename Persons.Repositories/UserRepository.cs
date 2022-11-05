using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Persons.Core.Entities;
using Persons.Core.Interfaces;

namespace Persons.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _collection;

        public UserRepository(IOptions<DbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName
            );

            _collection = mongoDatabase.GetCollection<UserEntity>(
                databaseSettings.Value.UserCollection
            );
        }

        public async Task<UserEntity> GetAsync(string email)
        {
            UserEntity entity;
            
            entity = await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();

            return entity;
        }
    }
}