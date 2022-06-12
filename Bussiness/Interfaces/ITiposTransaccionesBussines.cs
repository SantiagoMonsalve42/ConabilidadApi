using DTO.Transport.TiposTransaccionesDTO;

namespace Bussiness.Interfaces
{
    public interface ITiposTransaccionesBussines
    {
        Task<ICollection<TiposTransaccionesDTO>> getAll();
    }
}
