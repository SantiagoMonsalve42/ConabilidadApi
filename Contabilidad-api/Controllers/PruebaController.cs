using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    
    public class PruebaController: BaseController
    {
        [HttpGet]
        public async Task<ActionResult> helloWord()
        {
            return await GetReponseAnswer("SISAS");
        }
    }
}
