using Common.Utilities;
using DTO.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Contabilidad_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    [EnableCors("MyCorsPolicyCustomable")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController: Controller
    {
        private readonly string _bearerDef = "Bearer ";
        protected string? Token 
        {
            get 
            {
                string value = HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(value))
                {
                    return null;
                }
                else
                {
                    value = value.Replace(_bearerDef, "");
                    return JwtUtils.ValidateToken(value);
                }
                
            }
            set { }
        }
        protected async Task<ObjectResult> GetReponseAnswer<T>(T response, string? token=null)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto<T> { Data = response,Token = (token!= null)?token: this.Token })
                    { StatusCode = (int)HttpStatusCode.OK };
                });
        }

    }
}
