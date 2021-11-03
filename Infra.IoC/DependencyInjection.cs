using Application.Interface;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IoC
{
    public static class  DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IListIndexRepository, ListIndexRepository>();
            services.AddScoped<IChoreRepository, ChoreRepository>();

            services.AddScoped<IListIndexService, ListIndexService>();
            services.AddScoped<IChoreService, ChoreService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
