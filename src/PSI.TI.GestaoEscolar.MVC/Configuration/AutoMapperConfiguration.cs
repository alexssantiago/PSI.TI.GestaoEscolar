using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PSI.TI.GestaoEscolar.Application.AutoMapper;

namespace PSI.TI.GestaoEscolar.MVC.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            return services;
        }
    }
}