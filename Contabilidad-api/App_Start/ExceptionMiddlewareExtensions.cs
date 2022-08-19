using Common.Utilities;
using DTO.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Contabilidad_api.App_Start
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IExceptionHandle exceptionHandle)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    HttpResponseDto httpResponseErrorDto = exceptionHandle.GenericException(contextFeature.Error);
                    HttpStatusCode Code = HttpStatusCode.InternalServerError;
                    if (Enum.IsDefined(typeof(HttpStatusCode), contextFeature.Error.HResult)) Code = (HttpStatusCode)contextFeature.Error.HResult;
                    context.Response.StatusCode = (int)Code;
                    await context.Response.WriteAsync(httpResponseErrorDto.Serialize());
                });
            });
        }
    }
}
