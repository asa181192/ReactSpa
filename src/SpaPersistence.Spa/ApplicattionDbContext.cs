using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpaModel.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpaModel
{
    public partial class ApplicattionDbContext : DbContext
    {
        public ApplicattionDbContext()
        {
        }

        public ApplicattionDbContext(DbContextOptions<ApplicattionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoInstructor> CursoInstructor { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SpaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPerfil)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Comentario1)
                    .HasColumnName("Comentario")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Alumno");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Curso");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");

                entity.Property(e => e.FotoPortada)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursoInstructor>(entity =>
            {
                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.CursoInstructor)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInstructor_Curso");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.CursoInstructor)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInstructor_Instructor");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPerfil)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Grado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.Property(e => e.PrecioActual).HasColumnType("numeric(14, 2)");

                entity.Property(e => e.Promocion).HasColumnType("numeric(14, 2)");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Precio)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Precio_Curso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
