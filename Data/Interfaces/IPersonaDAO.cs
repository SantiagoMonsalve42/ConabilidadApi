using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;

namespace Data.Interfaces
{
    public interface IPersonaDAO
    {
        Task<ICollection<PersonaBasicDTO>> getAll();
        Task<PersonaBasicDTO> get(PersonaByIdDTO request);
        Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request);
        Task<bool> Delete(PersonaByIdDTO request);
        Task<PersonaBasicDTO> create(PersonaCreateDTO request);
        Task<bool> login(LoginDTO request);
    }
}
 