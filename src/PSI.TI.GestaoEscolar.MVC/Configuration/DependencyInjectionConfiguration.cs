using Microsoft.Extensions.DependencyInjection;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.Services;
using PSI.TI.GestaoEscolar.Data;
using PSI.TI.GestaoEscolar.Data.Repository;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;

namespace PSI.TI.GestaoEscolar.MVC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Context>();

            services.AddScoped<INotificador, Notificador>();
            
            services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            services.AddScoped<IResponsavelService, ResponsavelService>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();

            return services;
        }
    }
}