using DentalChair.Application.Services.AutoMapper;
using DentalChair.Application.UseCases.Allocations.Register;
using DentalChair.Application.UseCases.Allocations.Update.Status;
using DentalChair.Application.UseCases.DentalChairs.Delete;
using DentalChair.Application.UseCases.DentalChairs.GetAll;
using DentalChair.Application.UseCases.DentalChairs.GetById;
using DentalChair.Application.UseCases.DentalChairs.GetChairByChairNumber;
using DentalChair.Application.UseCases.DentalChairs.Register;
using DentalChair.Application.UseCases.DentalChairs.Update;
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
            services.AddScoped<IGetAllDentalChairUseCase, GetAllDentalChairUseCase>();
            services.AddScoped<IGetByIdDentalChairUseCase, GetByIdDentalChairUseCase>();
            services.AddScoped<IGetByChairNumberUseCase, GetByChairNumberUseCase>();
            services.AddScoped<IUpdateDentalChairUseCase, UpdateDentalChairUseCase>();
            services.AddScoped<IDeleteDentalChairUseCase, DeleteDentalChairUseCase>();
            services.AddScoped<IRegisterAllocationUseCase, RegisterAllocationUseCase>();
            services.AddScoped<IUpdateStatusAllocationUseCase, UpdateStatusAllocationUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping).Assembly);
        }
    }
}
