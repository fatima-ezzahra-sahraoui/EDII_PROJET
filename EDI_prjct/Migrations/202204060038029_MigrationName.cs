namespace EDI_prjct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fichier_EDI",
                c => new
                    {
                        Id_ficierEDI = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Formaat = c.String(),
                        Date_Recap = c.DateTime(nullable: false),
                        Date_Traitement = c.DateTime(nullable: false),
                        Etat = c.String(),
                        Envoyeur_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Id_ficierEDI)
                .ForeignKey("dbo.Utilisateurs", t => t.Envoyeur_UserID)
                .Index(t => t.Envoyeur_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fichier_EDI", "Envoyeur_UserID", "dbo.Utilisateurs");
            DropIndex("dbo.Fichier_EDI", new[] { "Envoyeur_UserID" });
            DropTable("dbo.Fichier_EDI");
        }
    }
}
