using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Transport.TiposTransaccionesDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class TiposTransaccionesDAO : ITiposTransaccionesDAO
    {
        #region props
        private readonly IRepository<TiposTransaccione> RepoTiposTransacciones;
        #endregion
        #region ctor
        public TiposTransaccionesDAO(IRepository<TiposTransaccione> repoTiposTransacciones)
        {
            RepoTiposTransacciones = repoTiposTransacciones ?? throw new ArgumentNullException(nameof(repoTiposTransacciones));
        }
        #endregion
        public async Task<ICollection<TiposTransaccionesDTO>> getAll()
        {
            ICollection<TiposTransaccione> response = await RepoTiposTransacciones.Entity.Select(x => x).ToListAsync();
            return response.Clone<TiposTransaccione, TiposTransaccionesDTO>();
        }
    }
}
