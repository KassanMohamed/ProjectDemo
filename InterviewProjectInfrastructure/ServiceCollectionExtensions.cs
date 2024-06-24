using InterviewProjectApplication.Abstractions.Repositories;
using InterviewProjectInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectInfrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetConnectionString("AnSServerType") == "MSSQL")
            {
                services.AddDbContext<InterviewProjectContext>(option => option.UseSqlServer(configuration.GetConnectionString("AnS")), ServiceLifetime.Transient);
            }

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
