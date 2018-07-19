namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offPercursoProps_PercursoPercorrido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PercursosPercorridos", "Nome");
            DropColumn("dbo.PercursosPercorridos", "Duracao");
            DropColumn("dbo.PercursosPercorridos", "Distancia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PercursosPercorridos", "Distancia", c => c.Single(nullable: false));
            AddColumn("dbo.PercursosPercorridos", "Duracao", c => c.Single(nullable: false));
            AddColumn("dbo.PercursosPercorridos", "Nome", c => c.String());
        }
    }
}
