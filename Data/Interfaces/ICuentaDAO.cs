using DTO.Transport.CuentaDTO;

namespace Data.Interfaces
{
    public interface ICuentaDAO
    {
        Task<CuentaDTO> create(CuentaDTO request);
        Task<CuentaDTO> get(CuentaByIdDTO request);
        Task<SaldoCuentaDTO> SaldosCuenta(CuentaByIdDTO request);
        Task<bool> Delete(CuentaByIdDTO request);
    }
}
