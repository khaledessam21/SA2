namespace Trip_Reservation_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverName = c.String(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        TimeFrom = c.Time(nullable: false, precision: 7),
                        TimeTo = c.Time(nullable: false, precision: 7),
                        LineId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        BusTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusTypes", t => t.BusTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId)
                .Index(t => t.BusTypeId);
            
            CreateTable(
                "dbo.BusTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocFrom = c.String(),
                        LocTo = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DayNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 10),
                        ConfirmPassword = c.String(nullable: false),
                        Adress = c.String(nullable: false, maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        SSN = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        Wallet = c.Single(nullable: false),
                        Block = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDay = c.DateTime(nullable: false),
                        LocFrom = c.String(),
                        LocTo = c.String(),
                        BusId = c.Int(nullable: false),
                        TimeFrom = c.Time(nullable: false, precision: 7),
                        TimeTo = c.Time(nullable: false, precision: 7),
                        TotalPrice = c.Single(nullable: false),
                        PaymentType = c.String(),
                        PassengerId = c.Int(nullable: false),
                        NumberOfseats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passengers", t => t.PassengerId, cascadeDelete: true)
                .Index(t => t.PassengerId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailsbleSeats = c.Int(nullable: false),
                        ReservedSeats = c.Int(nullable: false),
                        FullDate = c.DateTime(nullable: false),
                        BusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .Index(t => t.BusId);
            
        
            
          
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Trips", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Tickets", "PassengerId", "dbo.Passengers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Buses", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Buses", "BusTypeId", "dbo.BusTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Trips", new[] { "BusId" });
            DropIndex("dbo.Tickets", new[] { "PassengerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Buses", new[] { "BusTypeId" });
            DropIndex("dbo.Buses", new[] { "LineId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Trips");
            DropTable("dbo.Tickets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Passengers");
            DropTable("dbo.Days");
            DropTable("dbo.Lines");
            DropTable("dbo.BusTypes");
            DropTable("dbo.Buses");
        }
    }
}
