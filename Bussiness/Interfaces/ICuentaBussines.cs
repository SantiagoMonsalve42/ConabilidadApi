using DTO.Transport.CuentaDTO;

namespace Bussiness.Interfaces
{
    public interface ICuentaBussines
    {
        Task<CuentaDTO> create(CuentaDTO request);
        Task<CuentaDTO> get(CuentaByIdDTO request);
        Task<SaldoCuentaDTO> SaldosCuenta(CuentaByIdDTO request);
        Task<bool> Delete(CuentaByIdDTO request);
    }
}
