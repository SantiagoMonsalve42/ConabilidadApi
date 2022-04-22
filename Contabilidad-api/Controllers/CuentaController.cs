using Bussiness.Interfaces;
using DTO.Transport.CuentaDTO;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class CuentaController: BaseController
    {
        private readonly ICuentaBussines CuentaBussines;

        public CuentaController(ICuentaBussines cuentaBussines)
        {
            CuentaBussines = cuentaBussines ?? throw new ArgumentNullException(nameof(cuentaBussines));
        }
        [HttpPost]
        public async Task<ActionResult> create(CuentaDTO request)
        {
            CuentaDTO response = await CuentaBussines.create(request);
            return await GetReponseAnswer(response);
        }
        [HttpPost]
        public async Task<ActionResult> get(CuentaByIdDTO request)
        {
            CuentaDTO response = await CuentaBussines.get(request);
            return await GetReponseAnswer(response);
        }
        [HttpPost]
        public async Task<ActionResult> getSaldo(CuentaByIdDTO request)
        {
            SaldoCuentaDTO response = await CuentaBussines.SaldosCuenta(request);
            return await GetReponseAnswer(response);
        }
        [HttpDelete]
        public async Task<ActionResult> delete(CuentaByIdDTO request)
        {
            bool response = await CuentaBussines.Delete(request);
            return await GetReponseAnswer(response); 
        }
    }
}
