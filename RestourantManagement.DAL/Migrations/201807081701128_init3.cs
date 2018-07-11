namespace RestourantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Job", "jobType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Job", "jobType", c => c.String());
        }
    }
}
