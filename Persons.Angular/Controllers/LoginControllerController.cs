using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Angular.Helpers;
using Persons.Core.Dto;
using Persons.Core.Interfaces;

namespace Persons.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenService _tokenService;

    public LoginController(ILogger<LoginController> logger, IUnitOfWork unitOfWork, TokenService tokenService)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(UserLoginDtoIn userLogin)
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
