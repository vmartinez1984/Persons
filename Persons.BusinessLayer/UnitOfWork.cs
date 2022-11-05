using Persons.Core.Interfaces;

namespace Persons.BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {        
        public UnitOfWork(
            ILoginBl loginBl,
            IPersonBl personBl
        )
        {
            Login = loginBl;
            Person = personBl;
        }

        public ILoginBl Login { get; }

        public IPersonBl Person { get; }
    }
}