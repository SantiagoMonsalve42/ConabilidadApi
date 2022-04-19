using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Table("Persona")]
    public partial class Persona
    {
        public Persona()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        [Key]
        public long Id { get; set; }
        [Column("Nombre_1")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre1 { get; set; } = null!;
        [Column("Nombre_2")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Nombre2 { get; set; }
        [Column("Apellido_1")]
        [StringLength(50)]
        [Unicode(false)]
        public string Apellido1 { get; set; } = null!;
        [Column("Apellido_2")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Apellido2 { get; set; }
        [Column("Id_TipoDocumento")]
        public long IdTipoDocumento { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string NumeroDocumento { get; set; } = null!;
        [StringLength(200)]
        [Unicode(false)]
        public string? UrlFoto { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Unicode(false)]
        public string Password { get; set; } = null!;

        [ForeignKey("IdTipoDocumento")]
        [InverseProperty("Personas")]
        public virtual TiposDocumento IdTipoDocumentoNavigation { get; set; } = null!;
        [InverseProperty("Persona")]
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
