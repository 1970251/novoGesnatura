namespace GesNaturaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUtilizadorToClient : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PercursosPercorridos", name: "UtilizadorID", newName: "Utilizador_Id");
            RenameIndex(table: "dbo.PercursosPercorridos", name: "IX_UtilizadorID", newName: "IX_Utilizador_Id");
            AddColumn("dbo.PercursosPercorridos", "ClientID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PercursosPercorridos", "ClientID");
            RenameIndex(table: "dbo.PercursosPercorridos", name: "IX_Utilizador_Id", newName: "IX_UtilizadorID");
            RenameColumn(table: "dbo.PercursosPercorridos", name: "Utilizador_Id", newName: "UtilizadorID");
        }
    }
}
