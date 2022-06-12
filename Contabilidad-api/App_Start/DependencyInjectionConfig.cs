using Bussiness.Implementations;
using Bussiness.Interfaces;
using Common.Utilities;
using Data.Common;
using Data.Implementations;
using Data.Interfaces;
using Data.ModelData;

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
            services.AddScoped(typeof(ICuentaBussines), typeof(CuentaBussines));
            services.AddScoped(typeof(IPreguntaBussines), typeof(PreguntaBussines));
            services.AddScoped(typeof(ITipoDocumentoBussines), typeof(TipoDocumentoBussines));
            services.AddScoped(typeof(ITelefonoBussines), typeof(TelefonoBussines));
            services.AddScoped(typeof(ITiposTransaccionesBussines), typeof(TiposTransaccionesBussines));
            services.AddScoped(typeof(ITransaccionesBussines), typeof(TransaccionesBussines));
            //DATA ACCESS OBJECTS
            services.AddScoped(typeof(IPersonaDAO), typeof(PersonaDAO));
            services.AddScoped(typeof(ICuentaDAO), typeof(CuentaDAO));
            services.AddScoped(typeof(IPreguntasDAO), typeof(PreguntasDAO));
            services.AddScoped(typeof(ITipoDocumentoDAO), typeof(TipoDocumentoDAO));
            services.AddScoped(typeof(ITelefonosDAO), typeof(TelefonosDAO));
            services.AddScoped(typeof(ITiposTransaccionesDAO), typeof(TiposTransaccionesDAO));
            services.AddScoped(typeof(ITransaccionesDAO), typeof(TransaccionesDAO));
        }
    }
}
