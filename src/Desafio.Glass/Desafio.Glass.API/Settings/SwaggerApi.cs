using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Desafio.Glass.API.Settings
{
    /// <summary>
    /// Adiciona e configura os serviços da aplicação relacionados ao Swagger
    /// </summary>
    public static class SwaggerApi
    {
        private const string URLContact = "https://github.com/xft-eng";
        private const string URLLicence = "https://github.com/xft-eng";

        /// <summary>
        /// Adiciona o serviço do Swagger
        /// </summary>
        /// <param name="services">Coleção de serviços</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Gestão de Produtos",
                        Version = "v1",
                        Description = "Web API Gestão de Produtos em .net5.0",
                        Contact = new OpenApiContact
                        {
                            Name = "Tiago Xavier",
                            Email = "tiago.f.xavier014@gmail.com",
                            Url = new Uri(URLContact)
                        },
                        License = new OpenApiLicense
                        {
                            Name = "TFXAVIER",
                            Url = new Uri(URLLicence)
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(i => i.FullName);
            });
        }

        /// <summary>
        /// Configura o serviço do Swagger
        /// </summary>
        /// <param name="app">Aplicação</param>
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.DisplayRequestDuration();
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Gestão de Produtos API");
            });
        }
    }
}
