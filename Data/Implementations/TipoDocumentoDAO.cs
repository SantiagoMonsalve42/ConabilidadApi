using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Transport.TiposDocumentosDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class TipoDocumentoDAO : ITipoDocumentoDAO
    {
        #region props
        private readonly IRepository<TiposDocumento> RepoTiposDocumento;
        #endregion
        #region ctor
        public TipoDocumentoDAO(IRepository<TiposDocumento> repoTiposDocumento)
        {
            RepoTiposDocumento = repoTiposDocumento ?? throw new ArgumentNullException(nameof(repoTiposDocumento));
        }
        #endregion
        #region methods
        public async Task<ICollection<TiposDocumentosDTO>> getAll()
        {
            ICollection<TiposDocumento> exists = await RepoTiposDocumento.Entity.Select(x => x).ToListAsync();
            ICollection<TiposDocumentosDTO> response = exists.Clone<TiposDocumento,TiposDocumentosDTO>();
            return response;
        }
        #endregion
    }
}
