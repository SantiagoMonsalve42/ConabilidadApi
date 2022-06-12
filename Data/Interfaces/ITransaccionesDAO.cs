using Data.ModelData;
using DTO.Common;
using DTO.Transport.TransaccionesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITransaccionesDAO
    {
        Task<TransaccionCreateDTO> create(TransaccionCreateDTO request);
        Task<TransaccionPutDTO> put(TransaccionPutDTO request);
        Task<TransaccionesGetDto> getById(TransaccionesByIdRequestDTO request);
        Task<PaginationDTO<TransaccionesGetDto>> getAllByAccountId(TransaccionesByAccountIdRequestDTO request);
        Task<bool> delete(TransaccionesByIdRequestDTO request);
    }
}
