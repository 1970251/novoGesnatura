namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameComentario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursoComentarios", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursoComentarios", "UserName");
        }
    }
}
