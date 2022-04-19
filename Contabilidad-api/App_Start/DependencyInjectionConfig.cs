using Common.Utilities;
using Data.Common;
using Data.ModelData;

namespace Contabilidad_api.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependecyInjectionConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            HelperConfiguration.Configuration = Configuration;

            services.AddScoped<Data.Common.SpDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ILoggerSp<>), typeof(LoggerSp<>));
            services.AddScoped(typeof(IExceptionHandle), typeof(ExceptionHandle));



            //Business

            //Data

        }
    }
}
