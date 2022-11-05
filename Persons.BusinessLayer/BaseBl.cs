using AutoMapper;
using Persons.Core.Interfaces;

namespace Persons.BusinessLayer
{
    public class BaseBl
    {
        protected readonly IRepository _repository;
        protected readonly IMapper _mapper;

        public BaseBl(
            IRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}