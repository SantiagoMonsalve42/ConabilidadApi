using Bussiness.Interfaces;
using DTO.Transport.TelefonosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class TelefonoController: BaseController
    {
        private readonly ITelefonoBussines TelefonoBussines;

        public TelefonoController(ITelefonoBussines telefonoBussines)
        {
            TelefonoBussines = telefonoBussines ?? throw new ArgumentNullException(nameof(telefonoBussines));
        }
        [HttpPost]
        public async Task<ActionResult> getTypes()
        {
            return await GetReponseAnswer(await TelefonoBussines.getAll(),null);
        }
        [HttpPut]
        public async Task<ActionResult> put(EditarTelefonoDTO request)
        {
            return await GetReponseAnswer(await TelefonoBussines.put(request));
        }

    }
}
