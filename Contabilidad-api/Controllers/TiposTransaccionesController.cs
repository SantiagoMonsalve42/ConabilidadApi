using Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class TiposTransaccionesController: BaseController
    {
        private readonly ITiposTransaccionesBussines TiposTransaccionesBussines;

        public TiposTransaccionesController(ITiposTransaccionesBussines tiposTransaccionesBussines)
        {
            TiposTransaccionesBussines = tiposTransaccionesBussines ?? throw new ArgumentNullException(nameof(tiposTransaccionesBussines));
        }
        [HttpPost]
        public async Task<ActionResult> getAll()
        {
            return await GetReponseAnswer(await TiposTransaccionesBussines.getAll());
        }
    }
}
