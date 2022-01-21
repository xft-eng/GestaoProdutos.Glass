using AutoMapper;
using Desafio.Glass.Application.AutoMapperConfigs;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Glass.API.Settings
{
    public static class AutoMapperOptions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp =>
                new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddAutoMapper(x => x.AddProfile(new ViewModelToDomainMappingProfile()), typeof(ViewModelToDomainMappingProfile));
            services.AddAutoMapper(x => x.AddProfile(new DomainToViewModelMappingProfile()), typeof(DomainToViewModelMappingProfile));
        }
    }
}
