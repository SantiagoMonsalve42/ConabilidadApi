using DTO.Transport.PersonaDTO;

namespace Bussiness.Interfaces
{
    public interface IPersonaSesionBussines
    {
        Task<RefreshTokenResponseDTO> validateSession(RefreshTokenRequestDTO request);
    }
}
