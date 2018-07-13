namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercPerc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PercursosPercorridos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.String(),
                        PercursoID = c.Int(nullable: false),
                        Utilizador_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Percursoes", t => t.PercursoID, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_Id)
                .Index(t => t.PercursoID)
                .Index(t => t.Utilizador_Id);
            
            AddColumn("dbo.Percursoes", "ClientID", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PercursosPercorridos", "Utilizador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.PercursosPercorridos", "PercursoID", "dbo.Percursoes");
            DropIndex("dbo.PercursosPercorridos", new[] { "Utilizador_Id" });
            DropIndex("dbo.PercursosPercorridos", new[] { "PercursoID" });
            DropColumn("dbo.Percursoes", "ClientID");
            DropTable("dbo.PercursosPercorridos");
        }
    }
}
