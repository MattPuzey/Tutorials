namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Foremname = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAuthorised = c.Boolean(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TimeSheetEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TimeSpent = c.Int(nullable: false),
                        TimeCode_Id = c.Int(),
                        TimeSheet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeCodes", t => t.TimeCode_Id)
                .ForeignKey("dbo.TimeSheets", t => t.TimeSheet_Id)
                .Index(t => t.TimeCode_Id)
                .Index(t => t.TimeSheet_Id);
            
            CreateTable(
                "dbo.TimeCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheets", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.TimeSheetEntries", "TimeSheet_Id", "dbo.TimeSheets");
            DropForeignKey("dbo.TimeSheetEntries", "TimeCode_Id", "dbo.TimeCodes");
            DropIndex("dbo.TimeSheetEntries", new[] { "TimeSheet_Id" });
            DropIndex("dbo.TimeSheetEntries", new[] { "TimeCode_Id" });
            DropIndex("dbo.TimeSheets", new[] { "Employee_Id" });
            DropTable("dbo.TimeCodes");
            DropTable("dbo.TimeSheetEntries");
            DropTable("dbo.TimeSheets");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
