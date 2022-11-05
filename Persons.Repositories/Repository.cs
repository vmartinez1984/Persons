using Persons.Core.Interfaces;

namespace Persons.Repositories
{
    public class Repository : IRepository
    {
        public Repository(
            IUserRepository userRepository
            , IPersonRepository personRepository
        )
        {
            User = userRepository;
            Person = personRepository;
        }

        public IUserRepository User { get ; }

        public IPersonRepository Person {get;}
    }
}