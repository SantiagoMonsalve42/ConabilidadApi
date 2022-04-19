using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Keyless]
    [Table("Telefonos_persona")]
    public partial class TelefonosPersona
    {
        public long IdPersona { get; set; }
        public long IdTipoTelefono { get; set; }

        [ForeignKey("IdPersona")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        [ForeignKey("IdTipoTelefono")]
        public virtual TiposTelefono IdTipoTelefonoNavigation { get; set; } = null!;
    }
}
