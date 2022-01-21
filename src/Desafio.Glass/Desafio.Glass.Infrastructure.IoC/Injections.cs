using Desafio.Glass.Application.Interfaces;
using Desafio.Glass.Application.Services;
using Desafio.Glass.Domain.Interfaces.Repository;
using Desafio.Glass.Domain.Interfaces.Services;
using Desafio.Glass.Domain.Services;
using Desafio.Glass.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Glass.Infrastructure.IoC
{
    public static class Injections
    {
        public static void RegisterDependencyInjectionServices(this IServiceCollection services,
            IConfiguration configuration)
        {


            //AppService
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


            //Services
            services.AddScoped<IProdutoService, ProdutoService>();

            //Repositorios
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }


    }
}
