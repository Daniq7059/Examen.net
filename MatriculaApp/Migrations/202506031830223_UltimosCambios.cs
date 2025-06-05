namespace MatriculaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UltimosCambios : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cursoes", newName: "Cursos");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            CreateTable(
                "dbo.Apoderados",
                c => new
                    {
                        ApoderadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.ApoderadoId);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Duracion = c.Int(nullable: false),
                        InstitutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarreraId)
                .ForeignKey("dbo.Institutos", t => t.InstitutoId)
                .Index(t => t.InstitutoId);
            
            CreateTable(
                "dbo.DetalleMaticula",
                c => new
                    {
                        DetalleMatriculaId = c.Int(nullable: false, identity: true),
                        MatriculaId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleMatriculaId)
                .ForeignKey("dbo.Cursos", t => t.CursoId)
                .ForeignKey("dbo.Matriculas", t => t.MatriculaId)
                .Index(t => t.MatriculaId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Pagos",
                c => new
                    {
                        PagoId = c.Int(nullable: false, identity: true),
                        MatriculaId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedioPagoId = c.Int(nullable: false),
                        Estado = c.String(),
                        ComprobanteUrl = c.String(),
                    })
                .PrimaryKey(t => t.PagoId)
                .ForeignKey("dbo.Matriculas", t => t.MatriculaId)
                .ForeignKey("dbo.MediosPago", t => t.MedioPagoId)
                .Index(t => t.MatriculaId)
                .Index(t => t.MedioPagoId);
            
            CreateTable(
                "dbo.MediosPago",
                c => new
                    {
                        MedioPagoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.MedioPagoId);
            
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        PeriodoId = c.Int(nullable: false, identity: true),
                        Anio = c.Int(nullable: false),
                        Ciclo = c.String(),
                    })
                .PrimaryKey(t => t.PeriodoId);
            
            CreateTable(
                "dbo.HistorialAcademico",
                c => new
                    {
                        HistorialAcademicoId = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        NotaFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.HistorialAcademicoId)
                .ForeignKey("dbo.Cursos", t => t.CursoId)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId)
                .Index(t => t.EstudianteId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Institutos",
                c => new
                    {
                        InstitutoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.InstitutoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        ContraseñaHash = c.String(),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            AddColumn("dbo.Cursos", "Ciclo", c => c.Int(nullable: false));
            AddColumn("dbo.Cursos", "CarreraId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "PeriodoId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "FechaRegistro", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matriculas", "Estado", c => c.String());
            AddColumn("dbo.Estudiantes", "DNI", c => c.String());
            AddColumn("dbo.Estudiantes", "CarreraId", c => c.Int(nullable: false));
            AddColumn("dbo.Estudiantes", "ApoderadoId", c => c.Int());
            CreateIndex("dbo.Estudiantes", "CarreraId");
            CreateIndex("dbo.Estudiantes", "ApoderadoId");
            CreateIndex("dbo.Cursos", "CarreraId");
            CreateIndex("dbo.Matriculas", "PeriodoId");
            AddForeignKey("dbo.Estudiantes", "ApoderadoId", "dbo.Apoderados", "ApoderadoId");
            AddForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras", "CarreraId");
            AddForeignKey("dbo.Matriculas", "PeriodoId", "dbo.Periodos", "PeriodoId");
            AddForeignKey("dbo.Estudiantes", "CarreraId", "dbo.Carreras", "CarreraId");
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "EstudianteId");
            DropColumn("dbo.Matriculas", "CursoId");
            DropColumn("dbo.Matriculas", "Fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matriculas", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matriculas", "CursoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.Estudiantes", "CarreraId", "dbo.Carreras");
            DropForeignKey("dbo.Carreras", "InstitutoId", "dbo.Institutos");
            DropForeignKey("dbo.HistorialAcademico", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.HistorialAcademico", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.DetalleMaticula", "MatriculaId", "dbo.Matriculas");
            DropForeignKey("dbo.Matriculas", "PeriodoId", "dbo.Periodos");
            DropForeignKey("dbo.Pagos", "MedioPagoId", "dbo.MediosPago");
            DropForeignKey("dbo.Pagos", "MatriculaId", "dbo.Matriculas");
            DropForeignKey("dbo.DetalleMaticula", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras");
            DropForeignKey("dbo.Estudiantes", "ApoderadoId", "dbo.Apoderados");
            DropIndex("dbo.HistorialAcademico", new[] { "CursoId" });
            DropIndex("dbo.HistorialAcademico", new[] { "EstudianteId" });
            DropIndex("dbo.Pagos", new[] { "MedioPagoId" });
            DropIndex("dbo.Pagos", new[] { "MatriculaId" });
            DropIndex("dbo.Matriculas", new[] { "PeriodoId" });
            DropIndex("dbo.DetalleMaticula", new[] { "CursoId" });
            DropIndex("dbo.DetalleMaticula", new[] { "MatriculaId" });
            DropIndex("dbo.Cursos", new[] { "CarreraId" });
            DropIndex("dbo.Carreras", new[] { "InstitutoId" });
            DropIndex("dbo.Estudiantes", new[] { "ApoderadoId" });
            DropIndex("dbo.Estudiantes", new[] { "CarreraId" });
            DropColumn("dbo.Estudiantes", "ApoderadoId");
            DropColumn("dbo.Estudiantes", "CarreraId");
            DropColumn("dbo.Estudiantes", "DNI");
            DropColumn("dbo.Matriculas", "Estado");
            DropColumn("dbo.Matriculas", "FechaRegistro");
            DropColumn("dbo.Matriculas", "PeriodoId");
            DropColumn("dbo.Cursos", "CarreraId");
            DropColumn("dbo.Cursos", "Ciclo");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Institutos");
            DropTable("dbo.HistorialAcademico");
            DropTable("dbo.Periodos");
            DropTable("dbo.MediosPago");
            DropTable("dbo.Pagos");
            DropTable("dbo.DetalleMaticula");
            DropTable("dbo.Carreras");
            DropTable("dbo.Apoderados");
            CreateIndex("dbo.Matriculas", "CursoId");
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "EstudianteId", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes", "CursoId", cascadeDelete: true);
            RenameTable(name: "dbo.Cursos", newName: "Cursoes");
        }
    }
}
