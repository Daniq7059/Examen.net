namespace MatriculaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculaId = c.Int(nullable: false, identity: true),
                        EstudianteId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MatriculaId)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiantes", t => t.EstudianteId, cascadeDelete: true)
                .Index(t => t.EstudianteId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.EstudianteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Cursoes");
        }
    }
}
