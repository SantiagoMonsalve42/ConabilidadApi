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

        public async Task<PersonaDTO> create(PersonaDTO request)
        {
            Persona createObject = request.Clone<PersonaDTO,Persona>();
            Persona createdObject = await Repo.CreateAsync(createObject);
            PersonaDTO response = createdObject.Clone<Persona,PersonaDTO>();
            return response;
        }

        public async Task<bool> Delete(PersonaByIdDTO request)
        {
            Persona rowExists = (from row in Repo.Entity  where row.Id == request.Id select row).FirstOrDefault();
            if(rowExists == null)
                return false;
            await Repo.Delete(rowExists);
            return true;
        }

        public async Task<PersonaDTO> get(PersonaByIdDTO request)
        {
            Persona rowExists =  (from row in Repo.Entity where row.Id == request.Id select row).FirstOrDefault();
            PersonaDTO response = rowExists.Clone<Persona, PersonaDTO>();
            return response;
        }

        public async Task<ICollection<PersonaDTO>> getAll()
        {
            ICollection<Persona> items =  (from rows in Repo.Entity select rows).ToList();
            ICollection<PersonaDTO> response = items.Clone<Persona, PersonaDTO>();
            return response;
        }

        public async Task<PersonaDTO> update(PersonaPutPhotoDTO request)
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
                PersonaDTO response = responseToClone.Clone<Persona, PersonaDTO>();
                return response;
            }
        }
    }
}
