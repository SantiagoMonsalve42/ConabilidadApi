using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Transport.TiposDocumentosDTO;

namespace Bussiness.Implementations
{
    public class TipoDocumentoBussines : ITipoDocumentoBussines
    {
        private readonly ITipoDocumentoDAO TipoDocumentoDAO;

        public TipoDocumentoBussines(ITipoDocumentoDAO cuentaDAO)
        {
            TipoDocumentoDAO = cuentaDAO ?? throw new ArgumentNullException(nameof(cuentaDAO)); ;
        }

        public async Task<ICollection<TiposDocumentosDTO>> getAll()
        {
            return await TipoDocumentoDAO.getAll();
        }
    }
}
