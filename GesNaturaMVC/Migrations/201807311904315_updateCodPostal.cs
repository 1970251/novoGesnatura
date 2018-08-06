namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCodPostal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Percursoes", "CodPostal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Percursoes", "CodPostal");
        }
    }
}
