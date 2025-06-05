namespace MatriculaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarModelo : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.MediosPago", "Descripcion");
        }
    }
}
