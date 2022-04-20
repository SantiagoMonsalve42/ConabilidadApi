﻿using Bussiness.Interfaces;
using DTO.Common.PersonaDTO;
using Microsoft.AspNetCore.Mvc;

namespace Contabilidad_api.Controllers
{
    
    public class PersonaController: BaseController
    {
        private readonly IPersonaBussines PersonaBussines;

        public PersonaController(IPersonaBussines personaBussines)
        {
            PersonaBussines = personaBussines ?? throw new ArgumentNullException(nameof(personaBussines)); ;
        }

        [HttpPost]
        public async Task<ActionResult> getAll()
        {
            ICollection<PersonaDTO> response = await PersonaBussines.getAll();
            return await GetReponseAnswer(response);
        }
        [HttpPost]
        public async Task<ActionResult> get(PersonaByIdDTO request)
        {
            PersonaDTO response = await PersonaBussines.get(request);
            return await GetReponseAnswer(response);
        }
        [HttpPost]
        public async Task<ActionResult> create(PersonaDTO request)
        {
            PersonaDTO response = await PersonaBussines.create(request);
            return await GetReponseAnswer(response);
        }
        [HttpPut]
        public async Task<ActionResult> put(PersonaPutPhotoDTO request,long id)
        {
            if(id != request.Id)
            {
                return BadRequest("Los ids no coinciden");
            }
            PersonaDTO response = await PersonaBussines.update(request);
            return await GetReponseAnswer(response);
        }
        [HttpDelete]
        public async Task<ActionResult> delete(PersonaByIdDTO request)
        {
            bool response = await PersonaBussines.Delete(request);
            return await GetReponseAnswer(response);
        }
    }
}