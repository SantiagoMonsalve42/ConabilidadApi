using Contabilidad_api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.App_Start
{
    public static class FiltersConfig
    {
        public static void RegisterFiltersConfig(this IServiceCollection services)
        {
            //Disable validation model for default
            services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);
            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidateModelAttribute());
            });
        }
    }
}

