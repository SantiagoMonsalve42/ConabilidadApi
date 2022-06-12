using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Transport.TiposTransaccionesDTO;

namespace Bussiness.Implementations
{
    public class TiposTransaccionesBussines : ITiposTransaccionesBussines
    {
        private readonly ITiposTransaccionesDAO TiposTransaccionesDAO;

        public TiposTransaccionesBussines(ITiposTransaccionesDAO tiposTransaccionesDAO)
        {
            TiposTransaccionesDAO = tiposTransaccionesDAO ?? throw new ArgumentNullException(nameof(tiposTransaccionesDAO));
        }
        public async Task<ICollection<TiposTransaccionesDTO>> getAll()
        {
            return await TiposTransaccionesDAO.getAll();
        }
    }
}
