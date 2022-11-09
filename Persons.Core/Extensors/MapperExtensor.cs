using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Persons.Mappers;

namespace Persons.Core.Extensors
{
    public static class MapperExtensor
    {
        public static void AddMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<PersonMapper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
