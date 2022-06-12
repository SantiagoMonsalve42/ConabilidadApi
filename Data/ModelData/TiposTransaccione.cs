using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    public partial class TiposTransaccione
    {
        public TiposTransaccione()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string TipoTransaccion { get; set; } = null!;

        [InverseProperty("IdTipoTransaccionNavigation")]
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
