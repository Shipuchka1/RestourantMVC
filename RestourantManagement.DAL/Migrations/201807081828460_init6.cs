namespace RestourantManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "FullName", c => c.String(maxLength: 250));
            AddColumn("dbo.Reservation", "TimeOfReservation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservation", "Email", c => c.String());
            AddColumn("dbo.Reservation", "status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reservation", "guestName");
            DropColumn("dbo.Reservation", "noofguest");
            DropColumn("dbo.Reservation", "typeId");
            DropColumn("dbo.Reservation", "guestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "guestId", c => c.Int());
            AddColumn("dbo.Reservation", "typeId", c => c.Int());
            AddColumn("dbo.Reservation", "noofguest", c => c.String(maxLength: 250));
            AddColumn("dbo.Reservation", "guestName", c => c.String(maxLength: 250));
            DropColumn("dbo.Reservation", "status");
            DropColumn("dbo.Reservation", "Email");
            DropColumn("dbo.Reservation", "TimeOfReservation");
            DropColumn("dbo.Reservation", "FullName");
        }
    }
}
