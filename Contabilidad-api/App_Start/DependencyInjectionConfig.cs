using Bussiness.Implementations;
using Bussiness.Interfaces;
using Common.Utilities;
using Data.Common;
using Data.Implementations;
using Data.Interfaces;

namespace Contabilidad_api.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependecyInjectionConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            HelperConfiguration.Configuration = Configuration;

            services.AddScoped<SpDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ILoggerSp<>), typeof(LoggerSp<>));
            services.AddScoped(typeof(IExceptionHandle), typeof(ExceptionHandle));



            //FACADE OBJECTS
            services.AddScoped(typeof(IPersonaBussines), typeof(PersonaBussines));
            //DATA ACCESS OBJECTS
            services.AddScoped(typeof(IPersonaDAO), typeof(PersonaDAO));
        }
    }
}
