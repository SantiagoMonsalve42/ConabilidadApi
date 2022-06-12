using Bussiness.Interfaces;
using Data.Interfaces;
using DTO.Common.PersonaDTO;
using DTO.Transport.PersonaDTO;
using DTO.Transport.TelefonosDTO;
using System.Collections.Generic;

namespace Bussiness.Implementations
{
    public class PersonaBussines : IPersonaBussines
    {
        private readonly IPersonaDAO PersonaDAO;
        private readonly ITelefonosDAO TelefonosDAO;
        public PersonaBussines(IPersonaDAO personaDAO, ITelefonosDAO telefonosDAO)
        {
            TelefonosDAO = telefonosDAO ?? throw new ArgumentNullException(nameof(telefonosDAO));
            PersonaDAO = personaDAO ?? throw new ArgumentNullException(nameof(personaDAO)); ;
        }

        public async Task<PersonaBasicDTO> create(PersonaCreateDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.create(request);
            ICollection<AgregarTelefonoDTO> phones = await TelefonosDAO.addTelefonos(request.Telefonos, response.Id);
            if (phones.Any())
            {
                response.Telefonos = phones;
            }
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

        public async Task<bool> login(LoginDTO request)
        {
            return await PersonaDAO.login(request);
        }

        public async Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.update(request);
            return response;
        }
    }
}
