using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstudiantesITLA.Models
{
    public partial class ITLAContext : DbContext
    {
        public ITLAContext()
        {
        }

        public ITLAContext(DbContextOptions<ITLAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-L4MO65IR\\SQLEXPRESS;Database=ITLA;persist security info=True;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => e.CodCarrera)
                    .HasName("CodCarrera");

                entity.Property(e => e.NomCarrera)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("Matricula");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCarreraNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CodCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rel_Estudiantes_Carreras");
            });
        }
    }
}
