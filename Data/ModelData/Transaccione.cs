using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    public partial class Transaccione
    {
        [Key]
        public long Id { get; set; }
        public long IdCuenta { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal ValorTransaccion { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Url { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public bool EsPositivo { get; set; }

        [ForeignKey("IdCuenta")]
        [InverseProperty("Transacciones")]
        public virtual Cuentum IdCuentaNavigation { get; set; } = null!;
    }
}
