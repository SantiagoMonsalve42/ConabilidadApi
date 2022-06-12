using DTO.Transport.TelefonosDTO;

namespace Data.Interfaces
{
    public interface ITelefonosDAO
    {
        Task<ICollection<TelefonosDTO>> getAll();
        Task<bool> put(EditarTelefonoDTO request);
        Task<ICollection<AgregarTelefonoDTO>> addTelefonos(ICollection<AgregarTelefonoDTO> request, long IdPersona);
    }
}
