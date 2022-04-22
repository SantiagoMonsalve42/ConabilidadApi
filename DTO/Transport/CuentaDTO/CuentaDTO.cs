namespace DTO.Transport.CuentaDTO
{
    public class CuentaDTO
    {
        public long Id { get; set; }
        public string NumeroCuenta { get; set; }
        public long PersonaId { get; set; }
        public decimal SaldoTotal { get; set; }
        public DateTime FechaApertura { get; set; }
    }
}
