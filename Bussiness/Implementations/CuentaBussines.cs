using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Transport.CuentaDTO;

namespace Bussiness.Implementations
{
    public class CuentaBussines : ICuentaBussines
    {
        private readonly ICuentaDAO CuentaDAO;

        public CuentaBussines(ICuentaDAO cuentaDAO)
        {
            CuentaDAO = cuentaDAO ?? throw new ArgumentNullException(nameof(cuentaDAO)); ;
        }
        public async Task<CuentaDTO> create(CuentaDTO request)
        {
            CuentaDTO response = await CuentaDAO.create(request);
            return response;
        }

        public async Task<bool> Delete(CuentaByIdDTO request)
        {
           bool response = await CuentaDAO.Delete(request);
            return response;
        }

        public async Task<CuentaDTO> get(CuentaByIdDTO request)
        {
            CuentaDTO response = await CuentaDAO.get(request);
            return response;
        }

        public async Task<SaldoCuentaDTO> SaldosCuenta(CuentaByIdDTO request)
        {
            SaldoCuentaDTO response = await CuentaDAO.SaldosCuenta(request);
            return response;
        }
    }
}
