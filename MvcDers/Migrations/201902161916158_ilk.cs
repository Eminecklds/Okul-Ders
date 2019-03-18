namespace MvcDers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OgrenciDers", "OgretmenID", "dbo.Ogretmen");
            DropIndex("dbo.OgrenciDers", new[] { "OgretmenID" });
            RenameColumn(table: "dbo.OgrenciDers", name: "OgretmenID", newName: "Ogretmen_OgretmenID");
            AlterColumn("dbo.OgrenciDers", "Ogretmen_OgretmenID", c => c.Int());
            CreateIndex("dbo.OgrenciDers", "Ogretmen_OgretmenID");
            AddForeignKey("dbo.OgrenciDers", "Ogretmen_OgretmenID", "dbo.Ogretmen", "OgretmenID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciDers", "Ogretmen_OgretmenID", "dbo.Ogretmen");
            DropIndex("dbo.OgrenciDers", new[] { "Ogretmen_OgretmenID" });
            AlterColumn("dbo.OgrenciDers", "Ogretmen_OgretmenID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.OgrenciDers", name: "Ogretmen_OgretmenID", newName: "OgretmenID");
            CreateIndex("dbo.OgrenciDers", "OgretmenID");
            AddForeignKey("dbo.OgrenciDers", "OgretmenID", "dbo.Ogretmen", "OgretmenID", cascadeDelete: true);
        }
    }
}
