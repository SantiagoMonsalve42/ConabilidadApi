using Microsoft.OpenApi.Models;

namespace Contabilidad_api.App_Start
{
    public static class SwaggerConfig
    {
        public static void SwaggerConfigurationServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bancolombia.Garantias.Api", Version = "v1" });
               /* c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });*/
            });
        }
    }
}
