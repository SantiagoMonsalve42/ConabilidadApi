using Data.ModelData;
using DTO.Common;
using DTO.Transport.TransaccionesDTO;

namespace Bussiness.Interfaces
{
    public interface ITransaccionesBussines
    {
        Task<TransaccionCreateDTO> create(TransaccionCreateDTO request);
        Task<TransaccionPutDTO> put(TransaccionPutDTO request);
        Task<TransaccionesGetDto> getById(TransaccionesByIdRequestDTO request);
        Task<PaginationDTO<TransaccionesGetDto>> getAllByAccountId(TransaccionesByAccountIdRequestDTO request);
        Task<bool> delete(TransaccionesByIdRequestDTO request);
    }
}
