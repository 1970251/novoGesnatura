namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursosCriados", "IDCliente", c => c.String());
            DropColumn("dbo.PercursosCriados", "ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PercursosCriados", "ClientID", c => c.String());
            DropColumn("dbo.PercursosCriados", "IDCliente");
        }
    }
}
