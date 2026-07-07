namespace EcoRewards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionEvents",
                c => new
                    {
                        CollectionEventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 100),
                        EventDate = c.DateTime(nullable: false),
                        Location = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionEventId);
            
            CreateTable(
                "dbo.DropOffPoints",
                c => new
                    {
                        DropOffPointId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        City = c.String(maxLength: 100),
                        PostalCode = c.String(maxLength: 20),
                        ContactNumber = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DropOffPointId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        MaterialTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        PointsPerKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CO2PerKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.RecyclingEntries",
                c => new
                    {
                        RecyclingEntryId = c.Int(nullable: false, identity: true),
                        MaterialTypeId = c.Int(nullable: false),
                        DropOffPointId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubmissionDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        Notes = c.String(maxLength: 500),
                        ResidentId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RecyclingEntryId)
                .ForeignKey("dbo.DropOffPoints", t => t.DropOffPointId, cascadeDelete: true)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.MaterialTypeId)
                .Index(t => t.DropOffPointId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PointsHistories",
                c => new
                    {
                        PointsHistoryId = c.Int(nullable: false, identity: true),
                        RecyclingEntryId = c.Int(nullable: false),
                        PointsEarned = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAwarded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PointsHistoryId)
                .ForeignKey("dbo.RecyclingEntries", t => t.RecyclingEntryId, cascadeDelete: true)
                .Index(t => t.RecyclingEntryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Verifications",
                c => new
                    {
                        VerificationId = c.Int(nullable: false, identity: true),
                        RecyclingEntryId = c.Int(nullable: false),
                        VerificationDate = c.DateTime(nullable: false),
                        Verificationstatus = c.Int(nullable: false),
                        Comments = c.String(maxLength: 300),
                        OfficerId = c.String(),
                    })
                .PrimaryKey(t => t.VerificationId)
                .ForeignKey("dbo.RecyclingEntries", t => t.RecyclingEntryId, cascadeDelete: true)
                .Index(t => t.RecyclingEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verifications", "RecyclingEntryId", "dbo.RecyclingEntries");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecyclingEntries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PointsHistories", "RecyclingEntryId", "dbo.RecyclingEntries");
            DropForeignKey("dbo.RecyclingEntries", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.RecyclingEntries", "DropOffPointId", "dbo.DropOffPoints");
            DropIndex("dbo.Verifications", new[] { "RecyclingEntryId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PointsHistories", new[] { "RecyclingEntryId" });
            DropIndex("dbo.RecyclingEntries", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RecyclingEntries", new[] { "DropOffPointId" });
            DropIndex("dbo.RecyclingEntries", new[] { "MaterialTypeId" });
            DropTable("dbo.Verifications");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PointsHistories");
            DropTable("dbo.RecyclingEntries");
            DropTable("dbo.MaterialTypes");
            DropTable("dbo.DropOffPoints");
            DropTable("dbo.CollectionEvents");
        }
    }
}
