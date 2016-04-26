namespace EFDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class churchseedadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HouseKeeping_DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_DateLastModified = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChurchAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        AddressType = c.Int(nullable: false),
                        Zip = c.String(maxLength: 10),
                        State = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.ChurchMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        HouseKeeping_DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_DateLastModified = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_IsActive = c.Boolean(nullable: false),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        DateOfBirth = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.ChurchMemberAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchMemberId = c.Int(nullable: false),
                        AddressType = c.Int(nullable: false),
                        Zip = c.String(maxLength: 10),
                        State = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChurchMembers", t => t.ChurchMemberId, cascadeDelete: true)
                .Index(t => t.ChurchMemberId);
            
            CreateTable(
                "dbo.ChurchMemberEmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchMemberId = c.Int(nullable: false),
                        EmailAddressType = c.Int(nullable: false),
                        Email_Address = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChurchMembers", t => t.ChurchMemberId, cascadeDelete: true)
                .Index(t => t.ChurchMemberId);
            
            CreateTable(
                "dbo.Ministries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        HouseKeeping_DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_DateLastModified = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_IsActive = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 500),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.PrayerRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        HouseKeeping_DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_DateLastModified = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_IsActive = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Request = c.String(nullable: false, maxLength: 500),
                        PermissionGranted = c.Boolean(nullable: false),
                        EndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.PrayerRequestUpdates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrayerRequestId = c.Int(nullable: false),
                        HouseKeeping_DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_DateLastModified = c.DateTimeOffset(nullable: false, precision: 7),
                        HouseKeeping_IsActive = c.Boolean(nullable: false),
                        PermissionGranted = c.Boolean(nullable: false),
                        UpdateInformation = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrayerRequests", t => t.PrayerRequestId, cascadeDelete: true)
                .Index(t => t.PrayerRequestId);
            
            CreateTable(
                "dbo.ChurchMemberPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchMemberId = c.Int(nullable: false),
                        PhoneNumberType = c.Int(nullable: false),
                        Number = c.String(maxLength: 10),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChurchMembers", t => t.ChurchMemberId, cascadeDelete: true)
                .Index(t => t.ChurchMemberId);
            
            CreateTable(
                "dbo.ChurchEmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        EmailAddressType = c.Int(nullable: false),
                        Email_Address = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.ChurchPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChurchId = c.Int(nullable: false),
                        PhoneNumberType = c.Int(nullable: false),
                        Number = c.String(maxLength: 10),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Churches", t => t.ChurchId, cascadeDelete: true)
                .Index(t => t.ChurchId);
            
            CreateTable(
                "dbo.MinistryChurchMembers",
                c => new
                    {
                        Ministry_Id = c.Int(nullable: false),
                        ChurchMember_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ministry_Id, t.ChurchMember_Id })
                .ForeignKey("dbo.Ministries", t => t.Ministry_Id)
                .ForeignKey("dbo.ChurchMembers", t => t.ChurchMember_Id)
                .Index(t => t.Ministry_Id)
                .Index(t => t.ChurchMember_Id);
            
            CreateTable(
                "dbo.PrayerRequestMinistries",
                c => new
                    {
                        PrayerRequest_Id = c.Int(nullable: false),
                        Ministry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrayerRequest_Id, t.Ministry_Id })
                .ForeignKey("dbo.PrayerRequests", t => t.PrayerRequest_Id)
                .ForeignKey("dbo.Ministries", t => t.Ministry_Id)
                .Index(t => t.PrayerRequest_Id)
                .Index(t => t.Ministry_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChurchPhoneNumbers", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.ChurchEmailAddresses", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.ChurchMemberPhoneNumbers", "ChurchMemberId", "dbo.ChurchMembers");
            DropForeignKey("dbo.PrayerRequestUpdates", "PrayerRequestId", "dbo.PrayerRequests");
            DropForeignKey("dbo.PrayerRequestMinistries", "Ministry_Id", "dbo.Ministries");
            DropForeignKey("dbo.PrayerRequestMinistries", "PrayerRequest_Id", "dbo.PrayerRequests");
            DropForeignKey("dbo.PrayerRequests", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.MinistryChurchMembers", "ChurchMember_Id", "dbo.ChurchMembers");
            DropForeignKey("dbo.MinistryChurchMembers", "Ministry_Id", "dbo.Ministries");
            DropForeignKey("dbo.Ministries", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.ChurchMemberEmailAddresses", "ChurchMemberId", "dbo.ChurchMembers");
            DropForeignKey("dbo.ChurchMembers", "ChurchId", "dbo.Churches");
            DropForeignKey("dbo.ChurchMemberAddresses", "ChurchMemberId", "dbo.ChurchMembers");
            DropForeignKey("dbo.ChurchAddresses", "ChurchId", "dbo.Churches");
            DropIndex("dbo.PrayerRequestMinistries", new[] { "Ministry_Id" });
            DropIndex("dbo.PrayerRequestMinistries", new[] { "PrayerRequest_Id" });
            DropIndex("dbo.MinistryChurchMembers", new[] { "ChurchMember_Id" });
            DropIndex("dbo.MinistryChurchMembers", new[] { "Ministry_Id" });
            DropIndex("dbo.ChurchPhoneNumbers", new[] { "ChurchId" });
            DropIndex("dbo.ChurchEmailAddresses", new[] { "ChurchId" });
            DropIndex("dbo.ChurchMemberPhoneNumbers", new[] { "ChurchMemberId" });
            DropIndex("dbo.PrayerRequestUpdates", new[] { "PrayerRequestId" });
            DropIndex("dbo.PrayerRequests", new[] { "ChurchId" });
            DropIndex("dbo.Ministries", new[] { "ChurchId" });
            DropIndex("dbo.ChurchMemberEmailAddresses", new[] { "ChurchMemberId" });
            DropIndex("dbo.ChurchMemberAddresses", new[] { "ChurchMemberId" });
            DropIndex("dbo.ChurchMembers", new[] { "ChurchId" });
            DropIndex("dbo.ChurchAddresses", new[] { "ChurchId" });
            DropTable("dbo.PrayerRequestMinistries");
            DropTable("dbo.MinistryChurchMembers");
            DropTable("dbo.ChurchPhoneNumbers");
            DropTable("dbo.ChurchEmailAddresses");
            DropTable("dbo.ChurchMemberPhoneNumbers");
            DropTable("dbo.PrayerRequestUpdates");
            DropTable("dbo.PrayerRequests");
            DropTable("dbo.Ministries");
            DropTable("dbo.ChurchMemberEmailAddresses");
            DropTable("dbo.ChurchMemberAddresses");
            DropTable("dbo.ChurchMembers");
            DropTable("dbo.ChurchAddresses");
            DropTable("dbo.Churches");
        }
    }
}
