namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoradaPercurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Percursoes", "Morada", c => c.String());
            DropColumn("dbo.Percursoes", "Localidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Percursoes", "Localidade", c => c.String());
            DropColumn("dbo.Percursoes", "Morada");
        }
    }
}
