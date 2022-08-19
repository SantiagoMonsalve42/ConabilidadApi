using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;

namespace Bussiness.Implementations
{
    public class PersonaSesionBussines : IPersonaSesionBussines
    {
        private readonly IPersonaSesionDAO PersonaSesionDAO;
        private readonly IPersonaDAO PersonaDAO;
        public PersonaSesionBussines(IPersonaSesionDAO personaSesionDAO, IPersonaDAO personaDAO)
        {
            PersonaSesionDAO = personaSesionDAO ?? throw new ArgumentNullException(nameof(personaSesionDAO));
            PersonaDAO = personaDAO ?? throw new ArgumentNullException(nameof(personaDAO));
        }

        public async Task<RefreshTokenResponseDTO> validateSession(RefreshTokenRequestDTO request)
        {
            PersonaBasicDTO exists = await PersonaDAO.getByEmail(new PersonaByEmailDTO { Email = request.Email });
            if (exists == null)
            {
                return null;
            }
            RefreshTokenResponseDTO refreshToken= await PersonaSesionDAO.validateSession(request,exists.Id);
            return refreshToken;
        }
    }
}

