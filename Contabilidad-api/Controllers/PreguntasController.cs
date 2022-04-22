using Bussiness.Interfaces;
using Data.ModelData;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class PreguntasController: BaseController
    {
        private readonly IPreguntaBussines PreguntaBussines;

        public PreguntasController(IPreguntaBussines preguntaBussines)
        {
            PreguntaBussines = preguntaBussines?? throw new ArgumentNullException(nameof(preguntaBussines));
        }
        [HttpPost]
        public async Task<ActionResult> getAll()
        {
            ICollection<PreguntasSeguridad> response = await PreguntaBussines.getAll();
            return await  GetReponseAnswer(response);
        }
    }
}
