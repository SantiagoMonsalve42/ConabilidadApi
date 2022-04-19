using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Table("Tipos_documentos")]
    public partial class TiposDocumento
    {
        public TiposDocumento()
        {
            Personas = new HashSet<Persona>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string TipoDocumento { get; set; } = null!;

        [InverseProperty("IdTipoDocumentoNavigation")]
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
