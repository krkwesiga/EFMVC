namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        SavedBy = c.String(),
                        SavedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.CashRequisitions",
                c => new
                    {
                        CashRequisitionId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purpose = c.String(nullable: false),
                        Activity = c.String(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RequisitionStatus = c.String(nullable: false),
                        SavedDate = c.DateTime(nullable: false),
                        DeleteStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashRequisitionId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        ProjectDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CashRequisitions", new[] { "UserId" });
            DropIndex("dbo.CashRequisitions", new[] { "ProjectId" });
            DropForeignKey("dbo.CashRequisitions", "UserId", "dbo.Users");
            DropForeignKey("dbo.CashRequisitions", "ProjectId", "dbo.Projects");
            DropTable("dbo.Projects");
            DropTable("dbo.CashRequisitions");
            DropTable("dbo.Users");
        }
    }
}
