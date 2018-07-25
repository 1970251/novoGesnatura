namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_PercursoPercorrido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PercursosPercorridos", "TempoGasto", c => c.Single(nullable: false));
            AddColumn("dbo.PercursosPercorridos", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursosPercorridos", "Data");
            DropColumn("dbo.PercursosPercorridos", "TempoGasto");
        }
    }
}
