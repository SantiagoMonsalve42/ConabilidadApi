using DTO.Transport.TiposTransaccionesDTO;

namespace Data.Interfaces
{
    public interface ITiposTransaccionesDAO
    {
        Task<ICollection<TiposTransaccionesDTO>> getAll();
    }
}
