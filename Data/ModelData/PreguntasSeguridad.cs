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
        [Key]
        public long Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string Pregunta { get; set; } = null!;
    }
}
