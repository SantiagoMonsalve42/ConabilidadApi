namespace DTO.Transport.TransaccionesDTO
{
    public class TransaccionCreateDTO
    {
        public long IdCuenta { get; set; }
        public decimal ValorTransaccion { get; set; }
        public string? Url { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public long IdTipoTransaccion { get; set; }
    }
}
