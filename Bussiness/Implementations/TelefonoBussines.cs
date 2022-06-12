using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Transport.TelefonosDTO;

namespace Bussiness.Implementations
{
    public class TelefonoBussines : ITelefonoBussines
    {
        private readonly ITelefonosDAO TelefonosDAO;

        public TelefonoBussines(ITelefonosDAO telefonosDAO)
        {
            TelefonosDAO = telefonosDAO ?? throw new ArgumentNullException(nameof(telefonosDAO)); 
        }
        public async Task<ICollection<TelefonosDTO>> getAll()
        {
            return await TelefonosDAO.getAll();
        }

        public async Task<bool> put(EditarTelefonoDTO request)
        {
            return await TelefonosDAO.put(request);
        }
    }
}
