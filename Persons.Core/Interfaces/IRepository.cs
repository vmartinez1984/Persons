using Persons.Core.Entities;

namespace Persons.Core.Interfaces
{
    public interface IRepository
    {
        public IUserRepository User { get; }

        public IPersonRepository Person { get; }
    }

    public interface IUserRepository
    {
        Task<UserEntity> GetAsync(string email);
    }

    public interface IPersonRepository
    {
        Task<string> AddAsync(PersonEntity personEntity);
        Task<List<PersonEntity>> GetAsync(PagerEntity pagerEntity);
    }
}