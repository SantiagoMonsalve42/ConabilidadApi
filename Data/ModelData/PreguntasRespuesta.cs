using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Keyless]
    [Table("Preguntas_Respuestas")]
    public partial class PreguntasRespuesta
    {
        public long IdPregunta { get; set; }
        public long IdPersona { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Respuesta { get; set; } = null!;

        [ForeignKey("IdPersona")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        [ForeignKey("IdPregunta")]
        public virtual PreguntasSeguridad IdPreguntaNavigation { get; set; } = null!;
    }
}
