using Microsoft.Extensions.DependencyInjection;
using Persons.Core.Interfaces;

namespace Persons.Repositories
{
    public static class RepositorioExtensor
    {
        public static void AddRepository(this IServiceCollection services)
        {            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            
            services.AddScoped<IRepository, Repository>();
        }
    }
}