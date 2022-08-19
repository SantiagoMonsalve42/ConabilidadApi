using Bussiness.Interfaces;
using Common.Utilities;
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
        private readonly IPersonaSesionDAO PersonaSesionDAO;
        private readonly ITelefonosDAO TelefonosDAO;
        public PersonaBussines(IPersonaDAO personaDAO, ITelefonosDAO telefonosDAO, IPersonaSesionDAO personaSesionDAO)
        {
            TelefonosDAO = telefonosDAO ?? throw new ArgumentNullException(nameof(telefonosDAO));
            PersonaDAO = personaDAO ?? throw new ArgumentNullException(nameof(personaDAO));
            PersonaSesionDAO = personaSesionDAO ?? throw new ArgumentNullException(nameof(personaSesionDAO));
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
       
        public async Task<RefreshTokenResponseDTO> login(LoginDTO request)
        {
            bool exist= await PersonaDAO.login(request);
            if (exist)
            {
                string token512 = Util.GetSHA256(request.email+Util.getCurrentDateString());
                string tokenSesion = JwtUtils.GenerateToken(request.email);
                PersonaBasicDTO entity= await PersonaDAO.getByEmail(new PersonaByEmailDTO { Email = request.email });
                await PersonaSesionDAO.save(new RefreshTokenRequestDTO
                {
                    Email = request.email,
                    Token512 = token512, 
                    TokenSesion = tokenSesion
                }, entity.Id);
                return new RefreshTokenResponseDTO
                {
                    Token512 = token512,
                    TokenSesion = tokenSesion,
                };
            }
            return null;
        }

        public Task<RefreshTokenResponseDTO> refreshToken(RefreshTokenRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonaBasicDTO> update(PersonaPutPhotoDTO request)
        {
            PersonaBasicDTO response = await PersonaDAO.update(request);
            return response;
        }
    }
}

