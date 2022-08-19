using Common.Utilities;
using DTO.Common;
using DTO.Transport.PersonaDTO;
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
        protected RefreshTokenResponseDTO? Token 
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
                    return new RefreshTokenResponseDTO
                    {
                        TokenSesion = JwtUtils.ValidateToken(value),
                        Token512 = JwtUtils.GetSaltedEmailHash(value),
                    };
                }
                
            }
            set { }
        }
        protected async Task<ObjectResult> GetReponseAnswer(dynamic? response, dynamic? token=null)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto { Data = response!=null? response :null,Token = token !=null?token:null})
                    { StatusCode = (int)HttpStatusCode.OK };
                });
        }

    }
}
