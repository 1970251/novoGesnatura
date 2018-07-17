namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistanciaInPercPerc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursosPercorridos", "Distancia", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursosPercorridos", "Distancia");
        }
    }
}
