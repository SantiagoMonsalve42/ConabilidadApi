using DTO.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Contabilidad_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    [EnableCors("MyCorsPolicyCustomable")]
    
    public class BaseController: Controller
    {
        protected async Task<ObjectResult> GetReponseAnswer<T>(T response)
        {
            return await Task.Run(
                () =>
                {
                    return new ObjectResult(new HttpResponseDto<T> { Data = response})
                    { StatusCode = (int)HttpStatusCode.OK };
                });
        }
    }
}
