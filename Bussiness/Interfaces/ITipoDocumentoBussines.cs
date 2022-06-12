using DTO.Transport.TiposDocumentosDTO;

namespace Bussiness.Interfaces
{
    public interface ITipoDocumentoBussines
    {
        Task<ICollection<TiposDocumentosDTO>> getAll();
    }
}
