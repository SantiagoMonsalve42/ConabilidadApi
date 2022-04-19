using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string NumeroCuenta { get; set; } = null!;
        public long PersonaId { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal SaldoTotal { get; set; }

        [ForeignKey("PersonaId")]
        [InverseProperty("Cuenta")]
        public virtual Persona Persona { get; set; } = null!;
        [InverseProperty("IdCuentaNavigation")]
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
