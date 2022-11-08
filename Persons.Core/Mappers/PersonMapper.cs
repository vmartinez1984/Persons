using AutoMapper;
using Persons.Core.Dto;
using Persons.Core.Dtos;
using Persons.Core.Entities;

namespace Persons.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<AddressDtoIn, AddressEntity>().ReverseMap();

            CreateMap<PhoneDto, PhoneEntity>().ReverseMap();

            CreateMap<PersonDtoIn, PersonEntity>();
            CreateMap<PersonEntity, PersonDto>();

            CreateMap<PagerDto, PagerEntity>().ReverseMap();
        }
    }
}