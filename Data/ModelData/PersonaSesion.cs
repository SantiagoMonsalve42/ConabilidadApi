using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.ModelData
{
    [Table("PersonaSesion")]
    public partial class PersonaSesion
    {
        public long IdPersona { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string TokenSesion { get; set; } = null!;
        [Unicode(false)]
        public string Token512 { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Hora { get; set; }
        [Key]
        public long IdSesion { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("PersonaSesions")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
    }
}
