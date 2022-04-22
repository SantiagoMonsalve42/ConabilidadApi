using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelData
{
    [Table("PreguntasSeguridad")]
    public partial class PreguntasSeguridad
    {
        public PreguntasSeguridad()
        {
            PreguntasRespuesta = new HashSet<PreguntasRespuesta>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string Pregunta { get; set; } = null!;

        [InverseProperty("IdPreguntaNavigation")]
        public virtual ICollection<PreguntasRespuesta> PreguntasRespuesta { get; set; }
    }
}
