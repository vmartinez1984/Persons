using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.Core.Dto;
using Persons.Core.Dtos;
using Persons.Core.Interfaces;

namespace Persons.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PersonsController(ILogger<PersonsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[AuthorizeRoles(Rol.User, Rol.Admin)]
        public async Task<IActionResult> GetAsync([FromQuery] DataTableDto dataTablesIn)
        {
            PagerDto pager = new PagerDto
            {
                RecordsPerPage = dataTablesIn.RecordsPerPage,
                PageCurrent = dataTablesIn.PageCurrent,
                Search = dataTablesIn.SearchValue,
                SortColumn = dataTablesIn.SortColumn,
                SortColumnDir = dataTablesIn.SortColumnDir
            };
            pager = await _unitOfWork.Person.GetAsync(pager);
            this.HttpContext.Response.Headers.Add("total-records", pager.TotalRecords.ToString());
            this.HttpContext.Response.Headers.Add("total-records-filtered", pager.TotalRecordsFiltered.ToString());
            this.HttpContext.Response.Headers.Add("author", "Victor Martinez");

            //return Ok(pager.List);
            return Ok(new
            {
                draw = dataTablesIn.Draw,
                recordsFiltered = pager.TotalRecordsFiltered,
                recordsTotal = pager.TotalRecords,
                data = pager.List
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonDtoIn person)
        {
            string id;

            id = await _unitOfWork.Person.AddAsync(person);

            return Created("api/persons/" + id, new { id = id });
        }
    }
}
