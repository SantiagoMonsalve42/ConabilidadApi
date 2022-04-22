using System.ComponentModel.DataAnnotations;

namespace DTO.Transport.CuentaDTO
{
    public class SaldoCuentaDTO
    {
        [Key]
        public int id { get; set; }
        public decimal total { get; set; }
        public decimal activos { get; set; }
        public decimal pasivos { get; set; }
    }
}
