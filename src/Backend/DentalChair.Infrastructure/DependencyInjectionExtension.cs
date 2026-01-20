using DentalChair.Domain.IRepository;
using DentalChair.Domain.IRepository.DentalChair;
using DentalChair.Infrastructure.DataAccess;
using DentalChair.Infrastructure.DataAccess.Repositories.DentalChair;
using DentalChair.Infrastructure.Extensions;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure (this IServiceCollection services,IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepository(services);
            AddFluentMigrator(services, configuration);
        }

        public static void AddDbContext(IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IDentalChairWriteOnlyRepository, DentalChairRepository>();
            services.AddScoped<IDentalChairReadOnlyRepository, DentalChairRepository>();
            services.AddScoped<IDentalChairUpdateOnlyRepository, DentalChairRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
        }

        public static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options.AddMySql5().WithGlobalConnectionString(connectionString).ScanIn(Assembly.Load("DentalChair.Infrastructure")).For.All();
            });
        }
    }
}
