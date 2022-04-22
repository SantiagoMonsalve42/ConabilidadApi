using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PreguntasDAO : IPreguntasDAO
    {
        private readonly IRepository<PreguntasSeguridad> Repository;

        public PreguntasDAO(IRepository<PreguntasSeguridad> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ICollection<PreguntasSeguridad>> getAll()
        {
            ICollection<PreguntasSeguridad> response = await (from row in Repository.Entity select row).ToListAsync();
            return response;
        }
    }
}
