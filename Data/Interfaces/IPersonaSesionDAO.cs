using DTO.Transport.PersonaDTO;
using DTO.Transport.SessionDTO;

namespace Data.Interfaces
{
    public interface IPersonaSesionDAO
    {
        Task<RefreshTokenResponseDTO> validateSession(RefreshTokenRequestDTO request , long PersonaId);
        Task<RefreshTokenResponseDTO> save(RefreshTokenRequestDTO request,long personId);
        Task<SessionGetDto> get(long id);

    }
}
