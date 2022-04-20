using Common.Utilities;
using Data.Common;
using Data.Interfaces;
using Data.ModelData;
using DTO.Common.PersonaDTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PersonaDAO : IPersonaDAO
    {
        private readonly IRepository<Persona> Repo;

        public PersonaDAO(IRepository<Persona> repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<PersonaBasicDTO> create(PersonaDTO request)
        {
            Persona rowExists = (from row in Repo.Entity where row.Email == request.Email  select row).FirstOrDefault();
            if(rowExists != null)
            {
                throw new Exception("El usuario ya existe");
            }
            Persona createObject = request.Clone<PersonaDTO,Persona>();
            createObject.Password = Util.GetSHA256(createObject.Password);
            Persona createdObject = await Repo.CreateAsync(createObject);
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
    }
}
