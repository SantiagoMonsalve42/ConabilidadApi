using DTO.Common.PersonaDTO;

namespace Bussiness.Interfaces
{
    public interface IPersonaBussines
    {
        Task<ICollection<PersonaDTO>> getAll(); 
        Task<PersonaDTO> get(PersonaByIdDTO request);
        Task<PersonaDTO> update(PersonaPutPhotoDTO request);
        Task<bool> Delete(PersonaByIdDTO request);
        Task<PersonaDTO> create(PersonaDTO request);
    }
}
