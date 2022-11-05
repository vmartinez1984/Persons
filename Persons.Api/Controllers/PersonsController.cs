using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Api.Helpers;
using Persons.Core.Dto;
using Persons.Core.Dtos;
using Persons.Core.Interfaces;

namespace Persons.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public PersonsController(ILogger<LoginController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [AuthorizeRoles(Rol.User, Rol.Admin)]
    public async Task<List<PersonDto>> GetAsync([FromQuery]PagerDto search)
    {
        List<PersonDto> list;

        list = await _unitOfWork.Person.GetAsync(search);
        this.HttpContext.Response.Headers.Add("totalRecords", search.TotalRecords.ToString());
        this.HttpContext.Response.Headers.Add("totalRecordsFiltered", search.TotalRecordsFiltered.ToString());

        return list;
    }

    /// <summary>
    /// Agregar persona
    /// </summary>
    /// <param name="personDtoIn"></param>
    /// <returns></returns>
    [HttpPost]
    [AuthorizeRoles(Rol.Admin)]
    public async Task<IActionResult> PostAsync(PersonDtoIn personDtoIn)
    {
        string id;

        personDtoIn.UserId = User.Identity.GetUserId();
        id = await _unitOfWork.Person.AddAsync(personDtoIn);

        return Accepted($"/Api/Persons/{id}", new { id = id });
    }
}