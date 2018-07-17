namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePercursoCriados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursosCriados", "NomePercurso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursosCriados", "NomePercurso");
        }
    }
}
