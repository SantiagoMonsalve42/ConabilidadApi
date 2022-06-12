using Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class TiposDocumentosController: BaseController
    {
        private readonly ITipoDocumentoBussines TipoDocumentoBussines;

        public TiposDocumentosController(ITipoDocumentoBussines tipoDocumentoBussines)
        {
            TipoDocumentoBussines = tipoDocumentoBussines ?? throw new ArgumentNullException(nameof(tipoDocumentoBussines));
        }
        [HttpPost]
        public async Task<ActionResult> getAll()
        {
            return await GetReponseAnswer(await TipoDocumentoBussines.getAll());
        }
    }
}
