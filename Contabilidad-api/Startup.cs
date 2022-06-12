using Common.Utilities;
using Contabilidad_api.App_Start;

namespace Contabilidad_api
{
    public class Startup
    {
        private string _MyCors = "MyCorsPolicyCustomable";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(op =>
           {
               op.AddPolicy(_MyCors, builder =>
               {
                   builder.WithOrigins(HelperConfiguration.GetParam("corsOrigin"))
                       .AllowAnyMethod()
                       .AllowAnyHeader();
               });
           });
            services.SwaggerConfigurationServices();
            services.RegisterDependecyInjectionConfig(Configuration);
            services.JwtConfiguration();
            services.RegisterFiltersConfig();
        }
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env, IExceptionHandle exceptionHandle)
        {
            app.UseWebSockets();
            app.ConfigureExceptionHandler(exceptionHandle);
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bancolombia.Garantias.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_MyCors);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
