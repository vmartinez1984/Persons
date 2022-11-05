using AutoMapper;
using Persons.Core.Dto;
using Persons.Core.Entities;
using Persons.Core.Interfaces;

namespace Persons.BusinessLayer;
public class LoginBl : BaseBl, ILoginBl
{
    public LoginBl(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<UserLoginDto> LoginAsync(UserLoginDtoIn login)
    {
        UserLoginDto userLoginDto;

        userLoginDto = await GetUserAsync(login);

        return userLoginDto;
    }

    private async Task<UserLoginDto> GetUserAsync(UserLoginDtoIn login)
    {
        UserLoginDto user;
        UserEntity entity;

        entity = await _repository.User.GetAsync(login.Email);
        if (entity is null)
            user = null;
        else
        {
            if (entity.Password == login.Password)
            {
                user = new UserLoginDto
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    NameFull = $"{entity.Person.Name} {entity.Person.LastName}",
                    Role = entity.Role
                };
            }
            else
                user = null;
        }

        return user;
    }

}