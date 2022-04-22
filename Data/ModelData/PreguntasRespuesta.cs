using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Table("Preguntas_Respuestas")]
    public partial class PreguntasRespuesta
    {
        public long IdPregunta { get; set; }
        public long IdPersona { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Respuesta { get; set; } = null!;
        [Key]
        public long Id { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("PreguntasRespuesta")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        [ForeignKey("IdPregunta")]
        [InverseProperty("PreguntasRespuesta")]
        public virtual PreguntasSeguridad IdPreguntaNavigation { get; set; } = null!;
    }
}
