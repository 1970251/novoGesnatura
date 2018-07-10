namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientesNovos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Percursoes", "Cliente_ID", "dbo.Clientes");
            DropIndex("dbo.Percursoes", new[] { "Cliente_ID" });
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClientID = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Percursoes", "Utilizador_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserRoles", "Utilizador_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Utilizador_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Utilizador_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserClaims", "Utilizador_Id");
            CreateIndex("dbo.AspNetUserLogins", "Utilizador_Id");
            CreateIndex("dbo.Percursoes", "Utilizador_Id");
            CreateIndex("dbo.AspNetUserRoles", "Utilizador_Id");
            AddForeignKey("dbo.AspNetUserClaims", "Utilizador_Id", "dbo.Utilizadors", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Utilizador_Id", "dbo.Utilizadors", "Id");
            AddForeignKey("dbo.Percursoes", "Utilizador_Id", "dbo.Utilizadors", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Utilizador_Id", "dbo.Utilizadors", "Id");
            DropColumn("dbo.Percursoes", "Cliente_ID");
            DropTable("dbo.Clientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.String(),
                        IdPercurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Percursoes", "Cliente_ID", c => c.Int());
            DropForeignKey("dbo.AspNetUserRoles", "Utilizador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.Percursoes", "Utilizador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.AspNetUserLogins", "Utilizador_Id", "dbo.Utilizadors");
            DropForeignKey("dbo.AspNetUserClaims", "Utilizador_Id", "dbo.Utilizadors");
            DropIndex("dbo.AspNetUserRoles", new[] { "Utilizador_Id" });
            DropIndex("dbo.Percursoes", new[] { "Utilizador_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Utilizador_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Utilizador_Id" });
            DropColumn("dbo.AspNetUserLogins", "Utilizador_Id");
            DropColumn("dbo.AspNetUserClaims", "Utilizador_Id");
            DropColumn("dbo.AspNetUserRoles", "Utilizador_Id");
            DropColumn("dbo.Percursoes", "Utilizador_Id");
            DropTable("dbo.Utilizadors");
            CreateIndex("dbo.Percursoes", "Cliente_ID");
            AddForeignKey("dbo.Percursoes", "Cliente_ID", "dbo.Clientes", "ID");
        }
    }
}
