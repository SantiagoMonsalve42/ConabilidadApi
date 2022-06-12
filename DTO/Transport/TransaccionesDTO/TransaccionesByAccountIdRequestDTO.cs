using DTO.Common;

namespace DTO.Transport.TransaccionesDTO
{
    public class TransaccionesByAccountIdRequestDTO: PaginationRequestDTO
    {
        public long IdCuenta { get; set; }
    }
}
