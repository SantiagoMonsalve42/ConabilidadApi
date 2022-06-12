using DTO.Common;

namespace DTO.Transport.TransaccionesDTO
{
    public class TransaccionesGetDto
    {
        public long Id { get; set; }
        public long IdCuenta { get; set; }
        public decimal ValorTransaccion { get; set; }
        public string? Url { get; set; }
        [Sortable(OrderBy = "Fecha")]
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public long IdTipoTransaccion { get; set; }
    }
}
