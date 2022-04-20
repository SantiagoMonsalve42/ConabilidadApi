using DTO.Common.PersonaDTO;

namespace Data.Interfaces
{
    public interface IPersonaDAO
    {
        Task<ICollection<PersonaDTO>> getAll();
        Task<PersonaDTO> get(PersonaByIdDTO request);
        Task<PersonaDTO> update(PersonaPutPhotoDTO request);
        Task<bool> Delete(PersonaByIdDTO request);
        Task<PersonaDTO> create(PersonaDTO request);
    }
}
 