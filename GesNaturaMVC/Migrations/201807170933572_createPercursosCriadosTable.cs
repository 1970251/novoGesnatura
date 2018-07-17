namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPercursosCriadosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PercursosCriados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.String(),
                        PercursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Percursoes", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Percursoes", "UserName", c => c.String());
            DropTable("dbo.PercursosCriados");
        }
    }
}
