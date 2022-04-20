using DTO.Common.PersonaDTO;

namespace Data.Interfaces
{
    public interface IPersonaDAO
    {
        Task<ICollection<PersonaBasicDTO>> getAll();
        Task<PersonaBasicDTO> get(PersonaByIdDTO request);
        Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request);
        Task<bool> Delete(PersonaByIdDTO request);
        Task<PersonaBasicDTO> create(PersonaDTO request);
    }
}
 