using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;

namespace Bussiness.Implementations
{
    public class PersonaBussines : IPersonaBussines
    {
        private readonly IPersonaDAO PersonaDAO;

        public PersonaBussines(IPersonaDAO personaDAO)
        {
            PersonaDAO = personaDAO ?? throw new ArgumentNullException(nameof(personaDAO)); ;
        }

        public async Task<PersonaBasicDTO> create(PersonaCreateDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.create(request);
            return response;
        }

        public async Task<bool> Delete(PersonaByIdDTO request)
        {
            bool response = await PersonaDAO.Delete(request);
            return response;
        }

        public async Task<PersonaBasicDTO> get(PersonaByIdDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.get(request);
            return response;
        }

        public async Task<ICollection<PersonaBasicDTO>> getAll()
        {
            ICollection<PersonaBasicDTO> response = await PersonaDAO.getAll();
            return response;
        }

        public async Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.update(request);
            return response;
        }
    }
}
