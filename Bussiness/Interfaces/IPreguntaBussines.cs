using Data.ModelData;

namespace Bussiness.Interfaces
{
    public interface IPreguntaBussines
    {
        Task<ICollection<PreguntasSeguridad>> getAll();
    }
}
