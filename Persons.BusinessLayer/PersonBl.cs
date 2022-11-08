using AutoMapper;
using Persons.Core.Dto;
using Persons.Core.Dtos;
using Persons.Core.Entities;
using Persons.Core.Interfaces;

namespace Persons.BusinessLayer
{
    public class PersonBl : BaseBl, IPersonBl
    {
        public PersonBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<string> AddAsync(PersonDtoIn personDtoIn)
        {
            PersonEntity entity;

            entity = _mapper.Map<PersonEntity>(personDtoIn);
            await _repository.Person.AddAsync(entity);
            entity.ListAddresses.ForEach(item => {
                item.UserId = personDtoIn.UserId;
            });

            return entity.Id;
        }

        public async Task<PagerDto> GetAsync(PagerDto pager)
        {
            PagerEntity pagerEntity;
            List<PersonDto> list;
            List<PersonEntity> entities;

            pagerEntity = _mapper.Map<PagerEntity>(pager);
            entities = await _repository.Person.GetAsync(pagerEntity);
            list = _mapper.Map<List<PersonDto>>(entities);
            pager = _mapper.Map<PagerDto>(pagerEntity);
            pager.List = list;

            return pager;
        }
    }
}