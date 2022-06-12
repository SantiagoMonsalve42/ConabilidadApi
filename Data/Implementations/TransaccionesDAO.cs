using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Common;
using DTO.Transport.TransaccionesDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class TransaccionesDAO : ITransaccionesDAO
    {
        #region props
        private readonly IRepository<Transaccione> RepoTransaccion;
        #endregion
        #region ctor
        public TransaccionesDAO(IRepository<Transaccione> repoTransaccion)
        {
            RepoTransaccion = repoTransaccion ?? throw new ArgumentNullException(nameof(repoTransaccion));
        }
        #endregion
        public async Task<TransaccionCreateDTO> create(TransaccionCreateDTO request)
        {
            Transaccione saver = request.Clone<TransaccionCreateDTO, Transaccione>();
            saver.EsPositivo = (request.ValorTransaccion > 0) ? true : false;
            Transaccione create = await RepoTransaccion.CreateAsync(saver);
            if (create == null)
            {
                return null;
            }
            return create.Clone<Transaccione, TransaccionCreateDTO>();
        }

        public async Task<bool> delete(TransaccionesByIdRequestDTO request)
        {
            Transaccione exists = await RepoTransaccion.Entity.Select(x => x).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (exists == null) return false;
            await RepoTransaccion.Delete(exists);
            return true;
        }

        public async Task<PaginationDTO<TransaccionesGetDto>> getAllByAccountId(TransaccionesByAccountIdRequestDTO request)
        {
            ICollection<Transaccione> existes =  await RepoTransaccion.Entity.Select(x => x).Where(x => x.IdCuenta == request.IdCuenta).ToListAsync();
            if (existes == null) return null;
            ICollection<TransaccionesGetDto> toQueryable = existes.Clone<Transaccione,TransaccionesGetDto>();
            
            PaginationDTO<TransaccionesGetDto> response= await PaginationService.GetPagination(toQueryable.AsQueryable(), request.page,request.orderBy,request.orderByDesc,request.pageSize);
            return response;
        }

        public async Task<TransaccionesGetDto> getById(TransaccionesByIdRequestDTO request)
        {
            Transaccione exists = await RepoTransaccion.Entity.Select(x => x).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return exists == null ? null : exists.Clone<Transaccione, TransaccionesGetDto>();
        }

        public async Task<TransaccionPutDTO> put(TransaccionPutDTO request)
        {
            Transaccione exists = await RepoTransaccion.Entity.Select(x => x).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (exists == null) return null;
            exists.Descripcion = request.Descripcion;
            exists.IdTipoTransaccion = request.IdTipoTransaccion;
            exists.ValorTransaccion = request.ValorTransaccion;
            exists.EsPositivo = (request.ValorTransaccion > 0) ? true : false;
            exists.Fecha = request.Fecha;
            Transaccione saver = await RepoTransaccion.Put(exists);
            return saver.Clone<Transaccione, TransaccionPutDTO>();
        }
    }
}
