namespace RestourantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            
            
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemEatTypeId = c.Int(),
                        ItemDesc = c.String(),
                        Cost = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.eatType", t => t.ItemEatTypeId)
                .Index(t => t.ItemEatTypeId);
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "jobId", "dbo.Job");
            DropForeignKey("dbo.Menu", "ItemEatTypeId", "dbo.eatType");
            DropIndex("dbo.Employee", new[] { "jobId" });
            DropIndex("dbo.Menu", new[] { "ItemEatTypeId" });
            DropTable("dbo.Reservation");
            DropTable("dbo.Job");
            DropTable("dbo.Employee");
            DropTable("dbo.Menu");
            DropTable("dbo.eatType");
            DropTable("dbo.Comment");
        }
    }
}
