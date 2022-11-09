﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.Core.Dtos;
using Persons.Core.Interfaces;

namespace Persons.Angular.Controllers
{
    [Route("[controller]")]
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
        public async Task<IActionResult> GetAsync([FromQuery] PagerDto pager)
        {
            pager = await _unitOfWork.Person.GetAsync(pager);
            this.HttpContext.Response.Headers.Add("total-records", pager.TotalRecords.ToString());
            this.HttpContext.Response.Headers.Add("total-records-filtered", pager.TotalRecordsFiltered.ToString());
            this.HttpContext.Response.Headers.Add("author", "Victor Martinez");

            return Ok(pager);
        }
    }
}
