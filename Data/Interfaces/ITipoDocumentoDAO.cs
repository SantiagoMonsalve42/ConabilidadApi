using DTO.Transport.TiposDocumentosDTO;

namespace Data.Interfaces
{
    public interface ITipoDocumentoDAO
    {
        Task<ICollection<TiposDocumentosDTO>> getAll();
    }
}
