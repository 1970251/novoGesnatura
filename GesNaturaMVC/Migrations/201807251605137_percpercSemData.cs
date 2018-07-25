namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class percpercSemData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PercursosPercorridos", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PercursosPercorridos", "Data", c => c.DateTime(nullable: false));
        }
    }
}
