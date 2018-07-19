namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nomePercurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursoComentarios", "NomePercurso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursoComentarios", "NomePercurso");
        }
    }
}
