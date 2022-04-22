using Data.ModelData;

namespace Data.Interfaces
{
    public interface IPreguntasDAO
    {
        Task<ICollection<PreguntasSeguridad>> getAll();
    }
}
