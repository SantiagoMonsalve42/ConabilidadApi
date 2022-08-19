using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;
using DTO.Transport.PreguntasDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PersonaDAO : IPersonaDAO
    {
        #region props
        private readonly IRepository<Persona> Repo;
        private readonly IRepository<PreguntasRespuesta> RepoRespuestas;
        private readonly IRepository<PersonaSesion> RepoSesion;
        #endregion
        #region ctor
        public PersonaDAO(IRepository<Persona> repo, IRepository<PreguntasRespuesta> repoRespuestas, IRepository<PersonaSesion> repoSesion)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
            RepoRespuestas = repoRespuestas ?? throw new ArgumentNullException(nameof(repoRespuestas));
            RepoSesion = repoSesion ?? throw new ArgumentNullException(nameof(repoSesion));
        }
        #endregion
        #region METHODS
        public async Task<PersonaBasicDTO> create(PersonaCreateDTO request)
        {
            Persona rowExists = (from row in Repo.Entity where row.Email == request.Email  select row).FirstOrDefault();
            if(rowExists != null)
            {
                throw new Exception("El usuario ya existe");
            }
            Persona createObject = request.Clone<PersonaCreateDTO, Persona>();
            createObject.Password = Util.GetSHA256(createObject.Password);
            Persona createdObject = await Repo.CreateAsync(createObject);
            foreach (RespuestasPreguntasCreateDTO pregunta in request.Preguntas)
            {
                PreguntasRespuesta ask = new PreguntasRespuesta() { IdPersona = createdObject.Id, IdPregunta = pregunta.IdPregunta, Respuesta = pregunta.Respuesta };
                await RepoRespuestas.CreateAsync(ask);
            }
            PersonaBasicDTO response = createdObject.Clone<Persona, PersonaBasicDTO>();
            return response;
        }

        public async Task<bool> Delete(PersonaByIdDTO request)
        {
            Persona rowExists = (from row in Repo.Entity where row.Id == request.Id select row).FirstOrDefault();
            if(rowExists == null)
                return false;
            await Repo.Delete(rowExists);
            return true;
        }

        public async Task<PersonaBasicDTO> get(PersonaByIdDTO request)
        {
            Persona rowExists =  (from row in Repo.Entity where row.Id == request.Id select row).FirstOrDefault();
            PersonaBasicDTO response = rowExists.Clone<Persona, PersonaBasicDTO>();
            return response;
        }

        public async Task<ICollection<PersonaBasicDTO>> getAll()
        {
            ICollection<Persona> items =  (from rows in Repo.Entity select rows).ToList();
            ICollection<PersonaBasicDTO> response = items.Clone<Persona, PersonaBasicDTO>();
            return response;
        }

        public async Task<PersonaBasicDTO> getByEmail(PersonaByEmailDTO request)
        {
            Persona rowExists = (from row in Repo.Entity where row.Email == request.Email select row).FirstOrDefault();
            PersonaBasicDTO response = rowExists.Clone<Persona, PersonaBasicDTO>();
            return response;
        }

        public async Task<bool> login(LoginDTO request)
        {
            request.password = Util.GetSHA256(request.password);
            Persona exist = await Repo.Entity.Select(x => x).Where(x => x.Email == request.email && x.Password == request.password).FirstOrDefaultAsync();
            if (exist != null)
            {
                PersonaSesion existsFirstLog = await RepoSesion.Entity.Select(x => x).Where(x => x.IdPersona == exist.Id ).FirstOrDefaultAsync();
                if(existsFirstLog == null)
                {
                    PersonaSesion firstLog = await RepoSesion.CreateAsync(new PersonaSesion
                    {
                        IdPersona = exist.Id,
                        Hora = DateTime.Now,
                        Token512 = "init",
                        TokenSesion = "init",
                    });
                }
                else
                {
                    PersonaSesion firstLog = await RepoSesion.CreateAsync(new PersonaSesion
                    {
                        IdPersona = exist.Id,
                        Hora = DateTime.Now,
                        Token512 = Util.GetSHA256(exist.Email+Util.getCurrentDateString()),
                        TokenSesion = JwtUtils.GenerateToken(exist.Email),
                    });
                }
                return true;
            }
            return false;
        }

        public async Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request)
        {
            Persona rowExists = (from row in Repo.Entity where row.Id == request.Id select row).FirstOrDefault();
            if(rowExists == null)
            {
                throw new Exception("El registro no existe");
            }
            else
            {
                rowExists.UrlFoto = request.UrlFoto;
                Persona responseToClone = await Repo.Put(rowExists);
                PersonaBasicDTO response = responseToClone.Clone<Persona, PersonaBasicDTO>();
                return response;
            }
        }
        #endregion
    }
}

