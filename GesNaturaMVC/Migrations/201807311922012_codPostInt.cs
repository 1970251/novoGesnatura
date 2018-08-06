namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codPostInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Percursoes", "CodPostal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Percursoes", "CodPostal", c => c.Single(nullable: false));
        }
    }
}
