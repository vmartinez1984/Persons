using Persons.Core.Dto;
using Persons.Core.Dtos;

namespace Persons.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ILoginBl Login { get; }

        public IPersonBl Person { get; }
    }

    public interface ILoginBl
    {
        Task<UserLoginDto> LoginAsync(UserLoginDtoIn userLoginIn);
    }

    public interface IPersonBl
    {
        Task<string> AddAsync(PersonDtoIn personDtoIn);

        Task<List<PersonDto>> GetAsync(PagerDto search);
    }
}