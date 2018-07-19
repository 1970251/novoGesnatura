namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offNomePercurso_PercursoCriado : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PercursosCriados", "NomePercurso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PercursosCriados", "NomePercurso", c => c.String());
        }
    }
}
