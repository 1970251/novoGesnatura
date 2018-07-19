namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offNomePercurso_PercursoComentario : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PercursoComentarios", "NomePercurso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PercursoComentarios", "NomePercurso", c => c.String());
        }
    }
}
