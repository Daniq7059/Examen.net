namespace MatriculaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaHistorialAcademico : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DetalleMaticula", newName: "DetalleMatricula");
            AddColumn("dbo.DetalleMatricula", "Nota", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DetalleMatricula", "Estado", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleMatricula", "Estado");
            DropColumn("dbo.DetalleMatricula", "Nota");
            RenameTable(name: "dbo.DetalleMatricula", newName: "DetalleMaticula");
        }
    }
}
