namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuserpropertyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "name", c => c.String());
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "positionName", c => c.String());
            AddColumn("dbo.AspNetUsers", "address", c => c.String());
            AddColumn("dbo.AspNetUsers", "cellPhone", c => c.String());
            AddColumn("dbo.AspNetUsers", "birthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "picPath", c => c.String());
            AddColumn("dbo.AspNetUsers", "ManagerId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Manager_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "email", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Manager_Id");
            AddForeignKey("dbo.AspNetUsers", "Manager_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Manager_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Manager_Id" });
            AlterColumn("dbo.AspNetUsers", "email", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Manager_Id");
            DropColumn("dbo.AspNetUsers", "ManagerId");
            DropColumn("dbo.AspNetUsers", "picPath");
            DropColumn("dbo.AspNetUsers", "gender");
            DropColumn("dbo.AspNetUsers", "birthDate");
            DropColumn("dbo.AspNetUsers", "cellPhone");
            DropColumn("dbo.AspNetUsers", "address");
            DropColumn("dbo.AspNetUsers", "positionName");
            DropColumn("dbo.AspNetUsers", "lastName");
            DropColumn("dbo.AspNetUsers", "name");
        }
    }
}
