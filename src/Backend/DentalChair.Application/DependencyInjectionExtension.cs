using DentalChair.Application.Services.AutoMapper;
using DentalChair.Application.UseCases.DentalChairs.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddUseCase(services);
            AddAutoMapper(services);
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterDentalChairUseCase, RegisterDentalChairUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping).Assembly);
        }
    }
}
