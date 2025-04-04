using MelodyMetrics.Domain.Configurations;
using MelodyMetrics.Infrastructure.Data.MongoDB;
using MelodyMetrics.Infrastructure.Data.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;


namespace MelodyMetrics.Api.Startup
{
    public class Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        public IConfiguration Configuration { get; } = configuration;
        private readonly IConfigurationRoot _appConfiguration = env.GetAppConfiguration();

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://esscaeu.sharepoint.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            //Ajout du contexte default de BDD au Projet
            services.AddDbContext<MelodyMetricsPostgreDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL:Default"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MelodyMetricsAPI",
                    Version = "v1",
                });
            });

            services.AddSingleton<MelodyMetricsMongoDbContext>();

            services.Configure<HostOptions>(x =>
            {
                x.ServicesStartConcurrently = true;
                x.ServicesStopConcurrently = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(_appConfiguration["Swagger:SwaggerEndpoint"], "MelodyMetrics V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapSwagger();
                endpoints.MapControllers();
            });
        }
    }

}