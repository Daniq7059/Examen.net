using System.Data.Entity;
using MatriculaApp.Models;

namespace MatriculaApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=cnx") // Cadena de conexión en App.config
        {
        }

        public DbSet<Instituto> Institutos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Apoderado> Apoderados { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<DetalleMatricula> DetallesMatricula { get; set; }
        public DbSet<MedioPago> MediosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<HistorialAcademico> HistorialesAcademicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carrera>()
                .HasRequired(c => c.Instituto)
                .WithMany(i => i.Carreras)
                .HasForeignKey(c => c.InstitutoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasRequired(c => c.Carrera)
                .WithMany(ca => ca.Cursos)
                .HasForeignKey(c => c.CarreraId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasRequired(e => e.Carrera)
                .WithMany(ca => ca.Estudiantes)
                .HasForeignKey(e => e.CarreraId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasOptional(e => e.Apoderado)
                .WithMany(a => a.Estudiantes)
                .HasForeignKey(e => e.ApoderadoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
                .HasRequired(m => m.Periodo)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(m => m.PeriodoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
                .HasRequired(m => m.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(m => m.EstudianteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetalleMatricula>()
                .HasRequired(d => d.Matricula)
                .WithMany(m => m.Detalles)
                .HasForeignKey(d => d.MatriculaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetalleMatricula>()
                .HasRequired(d => d.Curso)
                .WithMany(c => c.DetallesMatricula)
                .HasForeignKey(d => d.CursoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pago>()
                .HasRequired(p => p.Matricula)
                .WithMany(m => m.Pagos)
                .HasForeignKey(p => p.MatriculaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pago>()
                .HasRequired(p => p.MedioPago)
                .WithMany(mp => mp.Pagos)
                .HasForeignKey(p => p.MedioPagoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HistorialAcademico>()
                .HasRequired(h => h.Estudiante)
                .WithMany(e => e.Historiales)
                .HasForeignKey(h => h.EstudianteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HistorialAcademico>()
                .HasRequired(h => h.Curso)
                .WithMany(c => c.Historiales)
                .HasForeignKey(h => h.CursoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioId);

            modelBuilder.Entity<Estudiante>().ToTable("Estudiantes");
            modelBuilder.Entity<Apoderado>().ToTable("Apoderados");
            modelBuilder.Entity<Carrera>().ToTable("Carreras");
            modelBuilder.Entity<Instituto>().ToTable("Institutos");
            modelBuilder.Entity<Curso>().ToTable("Cursos");
            modelBuilder.Entity<Periodo>().ToTable("Periodos");
            modelBuilder.Entity<Matricula>().ToTable("Matriculas");
            modelBuilder.Entity<DetalleMatricula>().ToTable("DetalleMatricula");
            modelBuilder.Entity<Pago>().ToTable("Pagos");
            modelBuilder.Entity<MedioPago>().ToTable("MediosPago");
            modelBuilder.Entity<HistorialAcademico>().ToTable("HistorialAcademico");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        }
    }
}
