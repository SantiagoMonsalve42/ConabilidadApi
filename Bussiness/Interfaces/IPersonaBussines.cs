using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;

namespace Bussiness.Interfaces
{
    public interface IPersonaBussines
    {
        Task<ICollection<PersonaBasicDTO>> getAll(); 
        Task<PersonaBasicDTO> get(PersonaByIdDTO request);
        Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request);
        Task<bool> Delete(PersonaByIdDTO request);
        Task<PersonaBasicDTO> create(PersonaCreateDTO request);
        Task<RefreshTokenResponseDTO> login(LoginDTO request);
        Task<RefreshTokenResponseDTO> refreshToken(RefreshTokenRequestDTO request);
    }
}
