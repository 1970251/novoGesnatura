namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercursoComentarioClientID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursoComentarios", "ClientID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursoComentarios", "ClientID");
        }
    }
}
