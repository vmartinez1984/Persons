using System.Security.Claims;

namespace Persons.Core.Dto
{
    public class UserDto : UserDtoIn
    {
        public string Id { get; set; }
    }

    public class UserDtoIn : UserLoginDto
    {
        public PersonDto Person { get; set; }

        public DateTime DateRegistration { get; set; }
    }

    public class UserLoginDtoIn
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }


    public class UserLoginDto
    {
        public string Email { get; set; }

        public string NameFull { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }

        public string Id { get; set; }

        public DateTime DateExpiration { get; set; }
    }


}