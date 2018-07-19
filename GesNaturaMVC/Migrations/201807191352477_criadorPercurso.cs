namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criadorPercurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursoComentarios", "CriadorPercurso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursoComentarios", "CriadorPercurso");
        }
    }
}
