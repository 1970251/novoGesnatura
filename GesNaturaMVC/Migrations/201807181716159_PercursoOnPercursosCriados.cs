namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercursoOnPercursosCriados : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PercursosCriados", "PercursoID");
            AddForeignKey("dbo.PercursosCriados", "PercursoID", "dbo.Percursoes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PercursosCriados", "PercursoID", "dbo.Percursoes");
            DropIndex("dbo.PercursosCriados", new[] { "PercursoID" });
        }
    }
}
