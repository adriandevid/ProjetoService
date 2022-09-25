using Microsoft.Extensions.DependencyInjection;
using ProjetoService.Application.Interfaces;
using ProjetoService.Application.Queries;

namespace ProjetoService.Infrastructure.IOC
{
    public static class Queries
    {
        public static void AddQueries(this IServiceCollection services) {
            services.AddScoped<IProjetoQueries, ProjetoQueries>();
        }
    }
}
