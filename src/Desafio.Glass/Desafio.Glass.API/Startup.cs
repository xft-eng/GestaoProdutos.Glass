using Desafio.Glass.API.Settings;
using Desafio.Glass.Application.Validators;
using Desafio.Glass.Infrastructure.Data.DbContexts;
using Desafio.Glass.Infrastructure.IoC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Desafio.Glass.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
               .AddFluentValidation(fv =>
               {
                   fv.RegisterValidatorsFromAssemblyContaining<ProdutoModelValidator>();
               });

            services.AddResponseCaching();

            services.AddOptions();

            services.AddCors();

            services.AddMemoryCache();

            var ConnectionStrings = Configuration.GetConnectionString("GestaoProduto");
            services.AddDbContext<GestaoProdutoDbContext>(options => options
            .UseSqlServer(ConnectionStrings, x => x.EnableRetryOnFailure())
            .EnableSensitiveDataLogging(Environment.IsDevelopment())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddSwagger();

            services.AddAutoMapper();

            services.RegisterDependencyInjectionServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/api/erros");
            }

            app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
