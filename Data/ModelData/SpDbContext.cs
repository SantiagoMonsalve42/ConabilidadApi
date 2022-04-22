using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.ModelData
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
                    .WithMany(p => p.PreguntasRespuesta)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preguntas_Respuestas_Persona");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.PreguntasRespuesta)
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
