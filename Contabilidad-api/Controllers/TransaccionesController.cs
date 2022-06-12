using Bussiness.Interfaces;
using DTO.Transport.TransaccionesDTO;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class TransaccionesController: BaseController
    {
        private readonly ITransaccionesBussines TransaccionesBussines;

        public TransaccionesController(ITransaccionesBussines transaccionesBussines)
        {
            TransaccionesBussines = transaccionesBussines ?? throw new ArgumentNullException(nameof(transaccionesBussines));
        }
        [HttpPost]
        public async Task<ActionResult> create(TransaccionCreateDTO request)
        {
            return await GetReponseAnswer(await TransaccionesBussines.create(request));
        }
        [HttpPost]
        public async Task<ActionResult> getById(TransaccionesByIdRequestDTO request)
        {
            return await GetReponseAnswer(await TransaccionesBussines.getById(request));
        }
        [HttpPost]
        public async Task<ActionResult> getAllByAccountId(TransaccionesByAccountIdRequestDTO request)
        {
            return await GetReponseAnswer(await TransaccionesBussines.getAllByAccountId(request));
        }
        [HttpDelete]
        public async Task<ActionResult> delete(TransaccionesByIdRequestDTO request)
        {
            return await GetReponseAnswer(await TransaccionesBussines.delete(request));
        }
        [HttpPut]
        public async Task<ActionResult> put(TransaccionPutDTO request)
        {
            return await GetReponseAnswer(await TransaccionesBussines.put(request));
        }
    }
}
