using Bussiness.Interfaces;
using Data.Interfaces;
using Data.ModelData;

namespace Bussiness.Implementations
{
    public class PreguntaBussines : IPreguntaBussines
    {
        private readonly IPreguntasDAO PreguntasDAO;

        public PreguntaBussines(IPreguntasDAO preguntasDAO)
        {
            PreguntasDAO = preguntasDAO ?? throw new ArgumentNullException(nameof(preguntasDAO));
        }

        public async Task<ICollection<PreguntasSeguridad>> getAll()
        {
            ICollection<PreguntasSeguridad> response = await PreguntasDAO.getAll();
            return response;
        }
    }
}
