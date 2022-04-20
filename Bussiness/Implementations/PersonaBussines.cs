using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Common.PersonaDTO;

namespace Bussiness.Implementations
{
    public class PersonaBussines : IPersonaBussines
    {
        private readonly IPersonaDAO PersonaDAO;

        public PersonaBussines(IPersonaDAO personaDAO)
        {
            PersonaDAO = personaDAO ?? throw new ArgumentNullException(nameof(personaDAO)); ;
        }

        public async Task<PersonaDTO> create(PersonaDTO request)
        {
            PersonaDTO response = await PersonaDAO.create(request);
            return response;
        }

        public async Task<bool> Delete(PersonaByIdDTO request)
        {
            bool response = await PersonaDAO.Delete(request);
            return response;
        }

        public async Task<PersonaDTO> get(PersonaByIdDTO request)
        {
            PersonaDTO response = await PersonaDAO.get(request);
            return response;
        }

        public async Task<ICollection<PersonaDTO>> getAll()
        {
            ICollection<PersonaDTO> response = await PersonaDAO.getAll();
            return response;
        }

        public async Task<PersonaDTO> update(PersonaPutPhotoDTO request)
        {
            PersonaDTO response = await PersonaDAO.update(request);
            return response;
        }
    }
}
