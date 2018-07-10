namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNamePercurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Percursoes", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Percursoes", "UserName");
        }
    }
}
