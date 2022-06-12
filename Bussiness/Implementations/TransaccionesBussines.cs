using Bussiness.Interfaces;
using Data.Interfaces;
using Data.ModelData;
using DTO.Common;
using DTO.Transport.TransaccionesDTO;

namespace Bussiness.Implementations
{
    public class TransaccionesBussines : ITransaccionesBussines
    {
        private readonly ITransaccionesDAO TransaccionesDAO;

        public TransaccionesBussines(ITransaccionesDAO transaccionesDAO)
        {
            TransaccionesDAO = transaccionesDAO ?? throw new ArgumentNullException(nameof(transaccionesDAO));
        }
        public async Task<TransaccionCreateDTO> create(TransaccionCreateDTO request)
        {
            return await TransaccionesDAO.create(request);
        }

        public async Task<bool> delete(TransaccionesByIdRequestDTO request)
        {
            return await TransaccionesDAO.delete(request);
        }

        public async Task<PaginationDTO<TransaccionesGetDto>> getAllByAccountId(TransaccionesByAccountIdRequestDTO request)
        {
            return await TransaccionesDAO.getAllByAccountId(request);
        }

        public async Task<TransaccionesGetDto> getById(TransaccionesByIdRequestDTO request)
        {
            return await TransaccionesDAO.getById(request);
        }

        public async Task<TransaccionPutDTO> put(TransaccionPutDTO request)
        {
            return await TransaccionesDAO.put(request);
        }
    }
}
