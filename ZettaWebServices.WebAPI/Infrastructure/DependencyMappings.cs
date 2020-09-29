using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZettaWebServices.Repository.Repositories;
using ZettaWebServices.Repository.Repositories.Interfaces;
using ZettaWebServices.Services.Services;
using ZettaWebServices.Services.Services.Interfaces;

namespace ZettaWebServices.WebAPI.Infrastructure
{
    public static class DependencyMappings
    {
        public static void DependencySetting(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //  Repositories dependency injections
            services.AddTransient<IZettaRepository, ZettaRepository>();

            //  Services dependency injections
            services.AddTransient<IZettaService, ZettaService>();
        }
    }
}
