using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjetoService.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Infrastructure.IOC
{
    public static class Mapper
    {
        public static void AddMapper(this IServiceCollection services) {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfigurations());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
