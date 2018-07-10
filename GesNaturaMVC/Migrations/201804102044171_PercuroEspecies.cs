namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PercuroEspecies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ReinoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reinoes", t => t.ReinoID, cascadeDelete: true)
                .Index(t => t.ReinoID);
            
            CreateTable(
                "dbo.Reinoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NomeCientifico = c.String(),
                        GeneroID = c.Int(nullable: false),
                        Descricao = c.String(),
                        Calendario = c.String(),
                        Abundancia = c.String(),
                        PercursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Generoes", t => t.GeneroID, cascadeDelete: true)
                .ForeignKey("dbo.Percursoes", t => t.PercursoID, cascadeDelete: true)
                .Index(t => t.GeneroID)
                .Index(t => t.PercursoID);
            
            CreateTable(
                "dbo.FotoAtlas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EspecieID = c.Int(nullable: false),
                        Caminho = c.String(),
                        Aprovado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Especies", t => t.EspecieID, cascadeDelete: true)
                .Index(t => t.EspecieID);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        FamiliaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Familias", t => t.FamiliaID, cascadeDelete: true)
                .Index(t => t.FamiliaID);
            
            CreateTable(
                "dbo.Familias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        OrdemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ordems", t => t.OrdemID, cascadeDelete: true)
                .Index(t => t.OrdemID);
            
            CreateTable(
                "dbo.Ordems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ClasseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClasseID, cascadeDelete: true)
                .Index(t => t.ClasseID);
            
            CreateTable(
                "dbo.FotoPercursos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PercursoID = c.Int(nullable: false),
                        Caminho = c.String(),
                        GPS_Lat = c.Single(nullable: false),
                        GPS_Long = c.Single(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Percursoes", t => t.PercursoID, cascadeDelete: true)
                .Index(t => t.PercursoID);
            
            CreateTable(
                "dbo.PercursoComentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PercursoID = c.Int(nullable: false),
                        Comentario = c.String(),
                        Classificacao = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Percursoes", t => t.PercursoID, cascadeDelete: true)
                .Index(t => t.PercursoID);
            
            CreateTable(
                "dbo.FotoPois",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PoiID = c.Int(nullable: false),
                        Caminho = c.String(),
                        Aprovado = c.Boolean(nullable: false),
                        POI_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.POIs", t => t.PoiID, cascadeDelete: true)
                .ForeignKey("dbo.POIs", t => t.POI_ID)
                .Index(t => t.PoiID)
                .Index(t => t.POI_ID);
            
            AddColumn("dbo.Percursoes", "Localidade", c => c.String());
            AddColumn("dbo.Percursoes", "Aprovado", c => c.Boolean(nullable: false));
            AddColumn("dbo.POIs", "Descricao", c => c.String(nullable: false));
            AddColumn("dbo.POIs", "FotoPoi_ID", c => c.Int());
            AlterColumn("dbo.Percursoes", "Distancia", c => c.Single(nullable: false));
            AlterColumn("dbo.Percursoes", "DuracaoAproximada", c => c.Single(nullable: false));
            AlterColumn("dbo.Percursoes", "KmlPath", c => c.String());
            CreateIndex("dbo.POIs", "FotoPoi_ID");
            AddForeignKey("dbo.POIs", "FotoPoi_ID", "dbo.FotoPois", "ID");
            DropColumn("dbo.POIs", "Localizacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.POIs", "Localizacao", c => c.String(nullable: false));
            DropForeignKey("dbo.Especies", "PercursoID", "dbo.Percursoes");
            DropForeignKey("dbo.FotoPois", "POI_ID", "dbo.POIs");
            DropForeignKey("dbo.POIs", "FotoPoi_ID", "dbo.FotoPois");
            DropForeignKey("dbo.FotoPois", "PoiID", "dbo.POIs");
            DropForeignKey("dbo.PercursoComentarios", "PercursoID", "dbo.Percursoes");
            DropForeignKey("dbo.FotoPercursos", "PercursoID", "dbo.Percursoes");
            DropForeignKey("dbo.Especies", "GeneroID", "dbo.Generoes");
            DropForeignKey("dbo.Generoes", "FamiliaID", "dbo.Familias");
            DropForeignKey("dbo.Familias", "OrdemID", "dbo.Ordems");
            DropForeignKey("dbo.Ordems", "ClasseID", "dbo.Classes");
            DropForeignKey("dbo.FotoAtlas", "EspecieID", "dbo.Especies");
            DropForeignKey("dbo.Classes", "ReinoID", "dbo.Reinoes");
            DropIndex("dbo.FotoPois", new[] { "POI_ID" });
            DropIndex("dbo.FotoPois", new[] { "PoiID" });
            DropIndex("dbo.POIs", new[] { "FotoPoi_ID" });
            DropIndex("dbo.PercursoComentarios", new[] { "PercursoID" });
            DropIndex("dbo.FotoPercursos", new[] { "PercursoID" });
            DropIndex("dbo.Ordems", new[] { "ClasseID" });
            DropIndex("dbo.Familias", new[] { "OrdemID" });
            DropIndex("dbo.Generoes", new[] { "FamiliaID" });
            DropIndex("dbo.FotoAtlas", new[] { "EspecieID" });
            DropIndex("dbo.Especies", new[] { "PercursoID" });
            DropIndex("dbo.Especies", new[] { "GeneroID" });
            DropIndex("dbo.Classes", new[] { "ReinoID" });
            AlterColumn("dbo.Percursoes", "KmlPath", c => c.String(nullable: false));
            AlterColumn("dbo.Percursoes", "DuracaoAproximada", c => c.String(nullable: false));
            AlterColumn("dbo.Percursoes", "Distancia", c => c.Int(nullable: false));
            DropColumn("dbo.POIs", "FotoPoi_ID");
            DropColumn("dbo.POIs", "Descricao");
            DropColumn("dbo.Percursoes", "Aprovado");
            DropColumn("dbo.Percursoes", "Localidade");
            DropTable("dbo.FotoPois");
            DropTable("dbo.PercursoComentarios");
            DropTable("dbo.FotoPercursos");
            DropTable("dbo.Ordems");
            DropTable("dbo.Familias");
            DropTable("dbo.Generoes");
            DropTable("dbo.FotoAtlas");
            DropTable("dbo.Especies");
            DropTable("dbo.Reinoes");
            DropTable("dbo.Classes");
        }
    }
}
