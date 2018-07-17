namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePercursosCriados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursosCriados", "NomeCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursosCriados", "NomeCliente");
        }
    }
}
