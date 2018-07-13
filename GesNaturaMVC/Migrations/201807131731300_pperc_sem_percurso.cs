namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pperc_sem_percurso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PercursosPercorridos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Duracao = c.Single(nullable: false),
                        UtilizadorID = c.String(maxLength: 128),
                        PercursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Percursoes", t => t.PercursoID, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.UtilizadorID)
                .Index(t => t.UtilizadorID)
                .Index(t => t.PercursoID);
            
            AddColumn("dbo.Utilizadors", "UtilizadorID", c => c.String());
            DropColumn("dbo.Utilizadors", "ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilizadors", "ClientID", c => c.String());
            DropForeignKey("dbo.PercursosPercorridos", "UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.PercursosPercorridos", "PercursoID", "dbo.Percursoes");
            DropIndex("dbo.PercursosPercorridos", new[] { "PercursoID" });
            DropIndex("dbo.PercursosPercorridos", new[] { "UtilizadorID" });
            DropColumn("dbo.Utilizadors", "UtilizadorID");
            DropTable("dbo.PercursosPercorridos");
        }
    }
}
