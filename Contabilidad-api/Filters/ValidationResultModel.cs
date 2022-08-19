using DTO.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Contabilidad_api.Filters
{
    public class ValidationResultModel : HttpResponseDto
    {
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Error = "Modelo invalido";
            Data = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

        }
    }
}
