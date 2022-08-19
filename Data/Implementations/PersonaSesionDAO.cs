
using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Transport.PersonaDTO;
using DTO.Transport.SessionDTO;
using Microsoft.EntityFrameworkCore;
namespace Data.Implementations
{
    public class PersonaSesionDAO : IPersonaSesionDAO
    {
        #region props
        private readonly IRepository<PersonaSesion> Repo;
        #endregion
        #region ctor
        public PersonaSesionDAO(IRepository<PersonaSesion> repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<SessionGetDto> get(long id)
        {
            PersonaSesion exists = await Repo.Entity.Select(x=>x).Where(x=>x.IdPersona == id).FirstOrDefaultAsync();
            return exists.Clone<PersonaSesion,SessionGetDto>();
        }

        public async Task<RefreshTokenResponseDTO> save(RefreshTokenRequestDTO request,long personId)
        {
            PersonaSesion createObject = request.Clone<RefreshTokenRequestDTO, PersonaSesion>();
            createObject.Hora = Util.getCurrentDate();
            createObject.IdPersona = personId;
            PersonaSesion createdObject = await Repo.CreateAsync(createObject);
            return createdObject.Clone<PersonaSesion,RefreshTokenResponseDTO>();
        }
        #endregion
        #region METHODS
        public async Task<RefreshTokenResponseDTO> validateSession(RefreshTokenRequestDTO request,long PersonaId)
        {
            PersonaSesion exists = await Repo.Entity
                .Select(element => element)
                .Where(x => x.IdPersona== PersonaId &&
                             x.Token512 == request.Token512)
                .FirstOrDefaultAsync();
            if(exists != null)
            {
                string token512 = Util.GetSHA256(request.Email + Util.getCurrentDateString());
                string tokenSesion = JwtUtils.GenerateToken(request.Email);
                PersonaSesion created = await Repo.CreateAsync(new PersonaSesion
                {
                    Hora = Util.getCurrentDate(),
                    IdPersona = PersonaId,
                    Token512 = token512,
                    TokenSesion = tokenSesion
                });
                return created.Clone<PersonaSesion, RefreshTokenResponseDTO>();
            }
            
            return null;
        }
        #endregion
    }
}
