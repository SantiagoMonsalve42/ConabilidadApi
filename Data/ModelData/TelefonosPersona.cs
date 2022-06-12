using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Table("Telefonos_persona")]
    public partial class TelefonosPersona
    {
        [Key]
        public long IdPersona { get; set; }
        [Key]
        public long IdTipoTelefono { get; set; }
        [StringLength(25)]
        [Unicode(false)]
        public string Telefono { get; set; } = null!;

        [ForeignKey("IdPersona")]
        [InverseProperty("TelefonosPersonas")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        [ForeignKey("IdTipoTelefono")]
        [InverseProperty("TelefonosPersonas")]
        public virtual TiposTelefono IdTipoTelefonoNavigation { get; set; } = null!;
    }
}
