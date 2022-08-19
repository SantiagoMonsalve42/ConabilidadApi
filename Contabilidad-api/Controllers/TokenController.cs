using Bussiness.Interfaces;
using DTO.Transport.PersonaDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    public class TokenController: BaseController
    {
        private readonly IPersonaSesionBussines PersonaSesionBussines;

        public TokenController(IPersonaSesionBussines personaSesionBussines)
        {
            PersonaSesionBussines = personaSesionBussines ?? throw new ArgumentNullException(nameof(personaSesionBussines));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> refresh(RefreshTokenRequestDTO request)
        {
            return await GetReponseAnswer(null, await PersonaSesionBussines.validateSession(request));
                
        }
    }
}
