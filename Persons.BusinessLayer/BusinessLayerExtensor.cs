using Microsoft.Extensions.DependencyInjection;
using Persons.Core.Interfaces;

namespace Persons.BusinessLayer
{
    public static class BusinessLayerExtensor
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ILoginBl, LoginBl>();
            services.AddScoped<IPersonBl, PersonBl>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}