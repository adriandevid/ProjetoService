
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoService.Application.Pipe;

namespace ProjetoService.Infrastructure.IOC
{
    public static class MediatrServices
    {
        public static void AddMediatr(this IServiceCollection services) 
        {
            const string applicationAssemblyName = "ProjetoService.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}
