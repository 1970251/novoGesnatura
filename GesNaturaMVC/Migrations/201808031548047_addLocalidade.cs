namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLocalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Percursoes", "Localidade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Percursoes", "Localidade");
        }
    }
}
