using Data.ModelData;
using Microsoft.EntityFrameworkCore;

namespace Data.Common
{
    public partial class SpDbContext : DbContext
    {
        public SpDbContext()
        {
        }

        public SpDbContext(DbContextOptions<SpDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<PreguntasRespuesta> PreguntasRespuestas { get; set; } = null!;
        public virtual DbSet<PreguntasSeguridad> PreguntasSeguridads { get; set; } = null!;
        public virtual DbSet<TelefonosPersona> TelefonosPersonas { get; set; } = null!;
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; } = null!;
        public virtual DbSet<TiposTelefono> TiposTelefonos { get; set; } = null!;
        public virtual DbSet<Transaccione> Transacciones { get; set; } = null!;
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=contabilidad;User Id=sa; Password=123456;");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Tipos_documentos");
            });

            modelBuilder.Entity<PreguntasRespuesta>(entity =>
            {
                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preguntas_Respuestas_Persona");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preguntas_Respuestas_PreguntasSeguridad");
            });

            modelBuilder.Entity<TelefonosPersona>(entity =>
            {
                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefonos_persona_Persona");

                entity.HasOne(d => d.IdTipoTelefonoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTipoTelefono)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefonos_persona_Tipos_Telefonos");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Cuenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
