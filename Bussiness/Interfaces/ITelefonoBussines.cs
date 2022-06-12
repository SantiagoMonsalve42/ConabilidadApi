using DTO.Transport.TelefonosDTO;

namespace Bussiness.Interfaces
{
    public interface ITelefonoBussines
    {
        Task<ICollection<TelefonosDTO>> getAll(); 
        Task<bool> put(EditarTelefonoDTO request);
    }
}
