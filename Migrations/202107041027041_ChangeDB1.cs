namespace LabBigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureId" });
            AddColumn("dbo.Courses", "Lecturer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false));
            CreateIndex("dbo.Courses", "Lecturer_Id");
            AddForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            AlterColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Courses", "Lecturer_Id");
            CreateIndex("dbo.Courses", "LectureId");
            AddForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
