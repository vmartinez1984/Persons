using Microsoft.AspNetCore.Mvc;
using Persons.Angular.Helpers;
using Persons.Core.Dto;
using Persons.Core.Interfaces;

namespace Persons.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenService _tokenService;

        public LoginController(
            IUnitOfWork unitOfWork,
            TokenService tokenService
        )
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Login(UserLoginDtoIn userLogin)
        {
            UserLoginDto userLoginDto;

            userLoginDto = await _unitOfWork.Login.LoginAsync(userLogin);
            if (userLoginDto is null)
            {
                return StatusCode(404, new { Message = "Email and/or password incorrect" });
            }
            else
            {
                userLoginDto.Token = _tokenService.GenerateJwt(userLoginDto);

                return Ok(userLoginDto);
            }
        }
    }
}
