namespace StudDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Smark = c.Int(nullable: false),
                        SubjectId = c.Int(),
                        StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Course = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Salary = c.Int(nullable: false),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.Marks", new[] { "SubjectId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
        }
    }
}
