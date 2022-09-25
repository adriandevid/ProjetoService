using Microsoft.Extensions.DependencyInjection;
using ProjetoService.Domain.Interfaces;
using ProjetoService.Infrastructure.Data.Context;
using ProjetoService.Infrastructure.Data.Repositories;
using ProjetoService.Infrastructure.Data.UnitOfWork;

namespace ProjetoService.Infrastructure.IOC
{
    public static class Repositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext, ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
        }
    }
}
