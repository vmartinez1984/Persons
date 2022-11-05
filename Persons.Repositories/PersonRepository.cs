using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Persons.Core.Entities;
using Persons.Core.Interfaces;

namespace Persons.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<PersonEntity> _collection;

        public PersonRepository(IOptions<DbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName
            );

            _collection = mongoDatabase.GetCollection<PersonEntity>(
                databaseSettings.Value.PersonCollection
            );
        }

        public async Task<string> AddAsync(PersonEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task<List<PersonEntity>> GetAsync(PagerEntity pagerEntity)
        {
            List<PersonEntity> entities;
            FilterDefinition<PersonEntity> filter;


            if (string.IsNullOrEmpty(pagerEntity.Search))
                filter = Builders<PersonEntity>.Filter.Where(_ => true);
            else
                filter = Builders<PersonEntity>.Filter
                .Where(x => x.Name.ToLower().Contains(pagerEntity.Search.ToLower()));

            entities = await _collection.Find(filter)
                .Sort("{_id:1}")
                .Skip((pagerEntity.PageCurrent - 1) * pagerEntity.RecordsPerPage)
                .Limit(pagerEntity.RecordsPerPage)
                .ToListAsync();
            pagerEntity.TotalRecordsFiltered = entities.Count();
            pagerEntity.TotalRecords = (int)await _collection.CountDocumentsAsync(new BsonDocument());

            return entities;
        }
    }
}